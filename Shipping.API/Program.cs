using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shipping.API.ErrorHandling;
using Shipping.API.PoliciesProvider;
using Shipping.Entities;
using Shipping.Entities.Domain.Identity;
using Shipping.Repositories;
using Shipping.Repositories.Contracts;
using Shipping.Repositories.Repos;
using Shipping.Services.IServices;
using Shipping.Services.Services;
using System.Text;

namespace Shipping.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Shipping", p => p.AllowAnyHeader()
                .AllowAnyOrigin()
                .WithOrigins("http://localhost:4200")
                .WithMethods("PUT", "POST", "DELETE", "GET"));
            });
            #endregion

            #region Context Configuration
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingDB")));

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

            #region Policy Provider
            //builder.Services.AddSingleton<IAuthorizationPolicyProvider, PolicyProvider>();

            #endregion

            #region Authentication Scheme

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            })
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.
                        ASCII.GetBytes(builder.Configuration["SecretKey"]!)),
                    ClockSkew = TimeSpan.Zero
                };
            });
            #endregion

            #region Authorization
            builder.Services.AddAuthorization(
            options =>
            {
                options.AddPolicy("permission.orders.read", policy =>
                {
                    policy.RequireClaim("permission.orders.read", "true");
                });
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

            builder.Services.AddScoped<IPermissionService, PermissionService>();
            
            #endregion 

            #region Auto Mapper

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion

            

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<GlobalErrorHandling>();
            app.UseCors("Shipping");
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}