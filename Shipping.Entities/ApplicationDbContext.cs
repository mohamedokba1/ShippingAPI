using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;

namespace Shipping.Entities;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Trader> Traders { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SalesRepresentative> SalesRepresentatives { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Goverment> Goverments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SpecialPackage> SpecialPackages { get; set; }
    public DbSet<Branch> Branches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("Users");

        #region Data Seed
        modelBuilder.Entity<ApplicationUserRole>().HasData(
            new ApplicationUserRole
            {
                Id = "1",
                Name = "admin",
                NormalizedName = "ADMIN",
               // Date = DateTime.Now,
            },
            new ApplicationUserRole
            {
                Id = "2",
                Name = "trader",
                NormalizedName = "TRADER",
                //Date = DateTime.Now,
            },
            new ApplicationUserRole
            {
                 Id = "3",
                 Name = "employee",
                 NormalizedName = "EMPLOYEE",
                // Date = DateTime.Now,
            },
            new ApplicationUserRole
            {
                Id = "4",
                Name = "salesrepresentative",
                NormalizedName = "SALESREPRESENTATIVE",
               // Date = DateTime.Now,
            }
          );
        modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(
            #region Admin Claims
             new IdentityRoleClaim<string>()
             {
                 Id = 1,
                 ClaimType = "permission.goverments.add",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 2,
                 ClaimType = "permission.goverments.update",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 3,
                 ClaimType = "permission.goverments.delete",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 4,
                 ClaimType = "permission.goverments.read",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 5,
                 ClaimType = "permission.cities.add",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 6,
                 ClaimType = "permission.cities.update",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 7,
                 ClaimType = "permission.cities.delete",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 8,
                 ClaimType = "permission.cities.read",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 9,
                 ClaimType = "permission.traders.add",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 10,
                 ClaimType = "permission.traders.delete",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 11,
                 ClaimType = "permission.traders.update",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 12,
                 ClaimType = "permission.traders.read",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 13,
                 ClaimType = "permission.employees.add",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 14,
                 ClaimType = "permission.employees.delete",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 15,
                 ClaimType = "permission.employees.update",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 16,
                 ClaimType = "permission.employees.read",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 17,
                 ClaimType = "permission.branches.add",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 18,
                 ClaimType = "permission.branches.delete",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 19,
                 ClaimType = "permission.branches.update",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 20,
                 ClaimType = "permission.branches.read",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 21,
                 ClaimType = "permission.sales.add",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 22,
                 ClaimType = "permission.sales.update",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 23,
                 ClaimType = "permission.sales.delete",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 24,
                 ClaimType = "permission.sales.read",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 25,
                 ClaimType = "permission.orders.add",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 26,
                 ClaimType = "permission.orders.update",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 27,
                 ClaimType = "permission.orders.delete",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 28,
                 ClaimType = "permission.orders.read",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             #endregion

            #region Trader Claims
             new IdentityRoleClaim<string>()
             {
                 Id = 29,
                 ClaimType = "permission.orders.add",
                 ClaimValue = "true",
                 RoleId = "2",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 30,
                 ClaimType = "permission.orders.update",
                 ClaimValue = "true",
                 RoleId = "2",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 31,
                 ClaimType = "permission.orders.delete",
                 ClaimValue = "true",
                 RoleId = "2",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 32,
                 ClaimType = "permission.orders.read",
                 ClaimValue = "true",
                 RoleId = "2",
             },
        #endregion

            #region Employee Claims
             new IdentityRoleClaim<string>()
             {
                 Id = 33,
                 ClaimType = "permission.orders.update",
                 ClaimValue = "true",
                 RoleId = "3",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 34,
                 ClaimType = "permission.orders.read",
                 ClaimValue = "true",
                 RoleId = "3",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 35,
                 ClaimType = "permission.branches.read",
                 ClaimValue = "true",
                 RoleId = "3",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 36,
                 ClaimType = "permission.cities.read",
                 ClaimValue = "true",
                 RoleId = "3",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 37,
                 ClaimType = "permission.cities.update",
                 ClaimValue = "true",
                 RoleId = "3",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 38,
                 ClaimType = "permission.cities.add",
                 ClaimValue = "true",
                 RoleId = "3",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 39,
                 ClaimType = "permission.goverments.read",
                 ClaimValue = "true",
                 RoleId = "3",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 40,
                 ClaimType = "permission.goverments.update",
                 ClaimValue = "true",
                 RoleId = "3",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 41,
                 ClaimType = "permission.goverments.add",
                 ClaimValue = "true",
                 RoleId = "3",
             },
             #endregion

            #region Sales Claims
             new IdentityRoleClaim<string>()
             {
                 Id = 42,
                 ClaimType = "permission.orders.update",
                 ClaimValue = "true",
                 RoleId = "4",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 43,
                 ClaimType = "permission.orders.read",
                 ClaimValue = "true",
                 RoleId = "4",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 44,
                 ClaimType = "permission.branches.read",
                 ClaimValue = "true",
                 RoleId = "4",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 45,
                 ClaimType = "permission.cities.read",
                 ClaimValue = "true",
                 RoleId = "4",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 46,
                 ClaimType = "permission.goverments.read",
                 ClaimValue = "true",
                 RoleId = "4",
             }
             #endregion

          );

        modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = "1",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "Admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PhoneNumber = "01234567890",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Admin@123"),
            }
            );
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>()
            {
                RoleId = "1",
                UserId = "1",
            }
            );
        #endregion
    }
}
