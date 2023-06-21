using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shipping.API.ErrorHandling;
using Shipping.Entities;
using Shipping.Entities.Domain.Identity;
using Shipping.Repositories;
using Shipping.Repositories.Contracts;
using Shipping.Repositories.Repos;
using Shipping.Services.IServices;
using Shipping.Services.Services;
using System.Security.Claims;
using System.Text;

namespace Shipping.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers(options =>
               options.Filters.Add<GlobalErrorHandling>());
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Shipping", p => p.AllowAnyHeader()
                .WithOrigins("http://localhost:4200")
                .WithMethods("PUT", "POST", "DELETE", "GET"));
            });
            #endregion

            #region Context Configuration
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingDB")));



            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #endregion

            #region Identity
            builder.Services.AddIdentity<ApplicationUser, ApplicationUserRole>(options =>
            {
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            #endregion

            #region Authentication Scheme

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Dev";
                options.DefaultChallengeScheme = "Dev";
            })
            .AddJwtBearer("Dev", _ =>
            {
                var secretKeyString = builder.Configuration.GetValue<string>("SecretKey");
                var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
            });
            #endregion

            #region Authorization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
                options.AddPolicy("TradersOnly", policy => policy.RequireRole("trader"));
                options.AddPolicy("EmployeesOnly", policy => policy.RequireRole("employee"));
                options.AddPolicy("salesrepresentativesOnly", policy => policy.RequireRole("salesrepresentative"));
            });
            #endregion

            #region Register repositories and services

            builder.Services.AddScoped<IBranchService, BranchService>();
            builder.Services.AddScoped<IBranchRepository, BranchRepository>();

            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<IPrivellageService, PrivellageService>();
            builder.Services.AddScoped<IPrivellageRepository, PrivellgeRepository>();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IGovermentRepository, GovernmentRepository>();

            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IGovernmentService, GovernmentService>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddScoped<ISalesService, SalesService>();
            builder.Services.AddScoped<ISalesRepresentativeRepository, SalesRepository>();

            builder.Services.AddScoped<ITraderRepository, TraderRepository>();
            builder.Services.AddScoped<ITraderService, TraderServices>();

            builder.Services.AddScoped<IBranchRepository, BranchRepository>();
            builder.Services.AddScoped<IBranchService, BranchService>();
            
            #endregion 

            #region Auto Mapper

            builder.Services.AddAutoMapper(typeof(Program));

            #endregion

            //builder.Services.AddHttpContextAccessor();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("Shipping");
            app.UseRouting();
            app.UseExceptionHandler("/error");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationUserRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                List<Claim> traderClaims = new List<Claim>()
                {
                    new Claim("addorder", "true"),
                    new Claim("updateorder", "true"),
                    new Claim("deleteorder", "true"),
                    new Claim("readorder", "true"),
                };
                List<Claim> salesClaims = new List<Claim>()
                {
                    new Claim("updateorder", "true"),
                    new Claim("readorder", "true"),
                };
                List<Claim> employeeClaims = new List<Claim>()
                {
                    new Claim("updateorder", "true"),
                    new Claim("readorder", "true"),
                };
                string userEmail = "Admin@admin.com";
                string password = "Test@admin12345";

                List<ApplicationUserRole> roles = new List<ApplicationUserRole>
                { 
                    new ApplicationUserRole {Name = "admin"},
                    new ApplicationUserRole {Name = "trader"},
                    new ApplicationUserRole {Name = "employee"},
                    new ApplicationUserRole {Name = "salesrepresentative"}
                };
                foreach (ApplicationUserRole role in roles)
                {
                    bool roleExist = await roleManager.RoleExistsAsync(role.Name);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(role);
                        if(role.Name == "trader")
                        {
                            foreach(var claim in traderClaims)
                            {
                                await roleManager.AddClaimAsync(role, claim);
                            }
                        }
                        else if(role.Name == "employee")
                        {
                            foreach (var claim in employeeClaims)
                            {
                                await roleManager.AddClaimAsync(role, claim);
                            }
                        }
                        else if (role.Name == "salesrepresentative")
                        {
                            foreach (var claim in salesClaims)
                            {
                                await roleManager.AddClaimAsync(role, claim);
                            }
                        }
                    } 
                }

                var checkUserIfExist = await userManager.FindByEmailAsync(userEmail);
                if (checkUserIfExist == null)
                {
                    var result = await userManager.CreateAsync(new ApplicationUser { Email = userEmail, UserName = "admin" }, password);
                    var adminUser = await userManager.FindByEmailAsync(userEmail);
                    if (adminUser != null)
                    {
                        await userManager.AddToRoleAsync(adminUser, "admin");
                    }
                }
            }
            app.Run();
        }
    }
}