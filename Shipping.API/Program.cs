using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Shipping", p => p.AllowAnyHeader().
                AllowAnyMethod().
                AllowAnyOrigin().
                WithOrigins("http://localhost:4200").
                WithMethods("PUT", "POST", "DELETE"));
            });

            #region CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowedOrigins",
                    builder => builder.WithOrigins("", "*"));

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
            .AddJwtBearer("Dev", options =>
            {
                var secretKeyString = builder.Configuration.GetValue<string>("SecretKey");
                var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
            });
            #endregion

            #region Register repositories and services

            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            builder.Services.AddScoped<IOrderService,OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<IPrivellageService,PrivellageService>();
            builder.Services.AddScoped<IPrivellageRepository, PrivellgeRepository>();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IGovermentRepository,GovernmentRepository>();

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

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("Shipping");
            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseCors("AllowedOrigins");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}