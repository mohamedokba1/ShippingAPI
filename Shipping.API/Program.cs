using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Repositories.Contracts;
using Shipping.Repositories.Repos;

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
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingDB")));
            
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #region register repositories
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IPrivellageRepository, PrivellgeRepository>();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IGovermentRepository,GovernmentRepository>();
            #endregion 

            builder.Services.AddAutoMapper(typeof(Program));
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}