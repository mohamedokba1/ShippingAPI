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
                Date = DateTime.Now.ToString(),
            },
            new ApplicationUserRole
            {
                Id = "2",
                Name = "trader",
                NormalizedName = "TRADER",
                Date = DateTime.Now.ToString()
            },
            new ApplicationUserRole
            {
                Id = "3",
                Name = "employee",
                NormalizedName = "EMPLOYEE",
                Date = DateTime.Now.ToString()
            },
            new ApplicationUserRole
            {
                Id = "4",
                Name = "salesrepresentative",
                NormalizedName = "SALESREPRESENTATIVE",
                Date = DateTime.Now.ToString()
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
             new IdentityRoleClaim<string>()
             {
                 Id = 47,
                 ClaimType = "permission.permissions.read",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 48,
                 ClaimType = "permission.permissions.update",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 49,
                 ClaimType = "permission.permissions.add",
                 ClaimValue = "true",
                 RoleId = "1",
             },
             new IdentityRoleClaim<string>()
             {
                 Id = 50,
                 ClaimType = "permission.permissions.delete",
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
            },
            new ApplicationUser
            {
                Id = "2",
                UserName = "trader1",
                NormalizedUserName = "TRADER1",
                Email = "trader1@example.com",
                NormalizedEmail = "TRADER1@EXAMPLE.COM",
                PhoneNumber = "01278555861",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Trader@123"),
            },
            new ApplicationUser
            {
                Id = "3",
                UserName = "employee1",
                NormalizedUserName = "EMPLOYEE1",
                Email = "employee1@example.com",
                NormalizedEmail = "EMPLOYEE1@EXAMPLE.COM",
                PhoneNumber = "01033325256",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Employee1@123")
            },
            new ApplicationUser
            {
                Id = "4",
                UserName = "sales1",
                NormalizedUserName = "SALES1",
                Email = "sales1@example.com",
                NormalizedEmail = "SALES1@EXAMPLE.COM",
                PhoneNumber = "01033325256",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Sales@123")
            },
            new ApplicationUser
            {
                Id = "5",
                UserName = "employee2",
                NormalizedUserName = "EMPLOYEE2",
                Email = "employee2@example.com",
                NormalizedEmail = "EMPLOYEE2@EXAMPLE.COM",
                PhoneNumber = "01033325256",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Employee2@123")
            }
            );
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>()
            {
                RoleId = "1",
                UserId = "1",
            },
            new IdentityUserRole<string>()
            {
                RoleId = "2",
                UserId = "2",
            },
            new IdentityUserRole<string>()
            {
                RoleId = "3",
                UserId = "3",
            },
            new IdentityUserRole<string>()
            {
                RoleId = "4",
                UserId = "4",
            }
            );

        modelBuilder.Entity<Branch>().HasData(
                new Branch
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    BranchName = "Cairo",
                    State = true,
                },
                new Branch
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    BranchName = "Giza",
                    State = true,
                },
                new Branch
                {
                    Id = 3,
                    CreatedAt = DateTime.Now,
                    BranchName = "Alexandria",
                    State = true,
                },
                new Branch
                {
                    Id = 4,
                    CreatedAt = DateTime.Now,
                    BranchName = "Sharqia",
                    State = false,
                }
            );
        modelBuilder.Entity<Trader>().HasData(
            new Trader
            {
                TraderId = 1,
                Email = "trader1@example.com",
                UserName = "trader1",
                Address = "Cairo",
                CostPerRefusedOrder = 1,
                PhoneNumber = "01278555861",
                UserId = "2",
                CompanyBranch = "Cairo"
            }
            );
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 1,
                Email = "employee1@example.com",
                IsActive = true,
                PhoneNumber = "01033325256",
                UserName = "employee1",
                Name = "Ahmed Mohamed",
                Password = "Employee@123",
                BranchId = 1,
                UserId = "3",
            },
            new Employee
            {
                EmployeeId = 2,
                Email = "employee2@example.com",
                IsActive = false,
                PhoneNumber = "01033325256",
                UserName = "employee2",
                Name = "Sayed Sameh",
                Password = "Employee@123",
                BranchId = 2,
                UserId = "5",
            }
            );

        modelBuilder.Entity<SalesRepresentative>().HasData(
            new SalesRepresentative
            {
                SalesRepresentativeId = 1,
                Email = "sales1@example.com",
                Address = "Cairo",
                DiscountType = DiscountType.FixedValue,
                IsActive = true,
                Name = "Mohamed Khaled",
                Password = "Sales@123",
                CompanyPercentage = 60,
                UserName = "sales1",
                UserId = "4"
            }
            );

        modelBuilder.Entity<Goverment>().HasData(
            new Goverment
            {
                Goverment_Id = 1,
                GovermentName = "Cairo",
                State = true
            },
            new Goverment
            {
                Goverment_Id = 2,
                GovermentName = "Alexandria",
                State = true
            },
            new Goverment
            {
                Goverment_Id = 3,
                GovermentName = "Giza",
                State = true
            },
            new Goverment
            {
                Goverment_Id = 4,
                GovermentName = "Dakahlia",
                State = false
            },
            new Goverment
            {
                Goverment_Id = 5,
                GovermentName = "Sharqia",
                State = false
            }
            );

        modelBuilder.Entity<City>().HasData(
            #region Cairo Citites
            new City
            {
                City_Id = 1,
                CityName = "Cairo",
                NormalShippingCost = 30,
                PickupShippingCost = 10,
                GovermentId = 1,
            },
            new City
            {
                City_Id = 2,
                CityName = "Giza",
                NormalShippingCost = 15,
                PickupShippingCost = 5,
                GovermentId = 1,
            },
            new City
            {
                City_Id = 3,
                CityName = "Shubra El-Kheima",
                NormalShippingCost = 20,
                PickupShippingCost = 15,
                GovermentId = 1,
            },
            new City
            {
                City_Id = 4,
                CityName = "Cairo",
                NormalShippingCost = 30,
                PickupShippingCost = 10,
                GovermentId = 1,
            },
            new City
            {
                City_Id = 5,
                CityName = "Helwan",
                NormalShippingCost = 35,
                PickupShippingCost = 20,
                GovermentId = 1,
            },
        #endregion

            #region Alexandria Citites
            new City
            {
                City_Id = 6,
                CityName = "Alexandria",
                NormalShippingCost = 30,
                PickupShippingCost = 10,
                GovermentId = 2,
            },
            new City
            {
                City_Id = 7,
                CityName = "Borg El Arab",
                NormalShippingCost = 15,
                PickupShippingCost = 5,
                GovermentId = 2,
            },
            new City
            {
                City_Id = 8,
                CityName = "Abu Qir",
                NormalShippingCost = 20,
                PickupShippingCost = 15,
                GovermentId = 2,
            },
            new City
            {
                City_Id = 9,
                CityName = "Montaza",
                NormalShippingCost = 30,
                PickupShippingCost = 10,
                GovermentId = 2,
            },
            new City
            {
                City_Id = 10,
                CityName = "Miami",
                NormalShippingCost = 35,
                PickupShippingCost = 20,
                GovermentId = 2,
            },
        #endregion

            #region Giza Cities
            new City
            {
                City_Id = 11,
                CityName = "Giza",
                NormalShippingCost = 30,
                PickupShippingCost = 10,
                GovermentId = 3,
            },
            new City
            {
                City_Id = 12,
                CityName = "Al Haram",
                NormalShippingCost = 15,
                PickupShippingCost = 5,
                GovermentId = 3,
            },
            new City
            {
                City_Id = 13,
                CityName = "Sheikh Zayed City",
                NormalShippingCost = 20,
                PickupShippingCost = 15,
                GovermentId = 3,
            },
            new City
            {
                City_Id = 14,
                CityName = "6th of October City",
                NormalShippingCost = 30,
                PickupShippingCost = 10,
                GovermentId = 3,
            },
            new City
            {
                City_Id = 15,
                CityName = "Bulaq ad Dakrur",
                NormalShippingCost = 35,
                PickupShippingCost = 20,
                GovermentId = 3,
            },
        #endregion

            #region Dakahlia Cities
            new City
            {
                City_Id = 16,
                CityName = "Mansoura",
                NormalShippingCost = 30,
                PickupShippingCost = 10,
                GovermentId = 4,
            },
            new City
            {
                City_Id = 17,
                CityName = "Talkha",
                NormalShippingCost = 15,
                PickupShippingCost = 5,
                GovermentId = 4,
            },
            new City
            {
                City_Id = 18,
                CityName = "Mit Ghamr",
                NormalShippingCost = 20,
                PickupShippingCost = 15,
                GovermentId = 4,
            },
            new City
            {
                City_Id = 19,
                CityName = "Aga",
                NormalShippingCost = 30,
                PickupShippingCost = 10,
                GovermentId = 4,
            },
            new City
            {
                City_Id = 20,
                CityName = "Sherbin",
                NormalShippingCost = 35,
                PickupShippingCost = 20,
                GovermentId = 4,
            },
        #endregion

            #region Sharqia Cities
            new City
            {
                City_Id = 21,
                CityName = "Zagazig",
                NormalShippingCost = 30,
                PickupShippingCost = 10,
                GovermentId = 5,
            },
            new City
            {
                City_Id = 22,
                CityName = "Belbeis",
                NormalShippingCost = 15,
                PickupShippingCost = 5,
                GovermentId = 5,
            },
            new City
            {
                City_Id = 23,
                CityName = "Abu Hammad",
                NormalShippingCost = 20,
                PickupShippingCost = 15,
                GovermentId = 5,
            },
            new City
            {
                City_Id = 24,
                CityName = "Abu Kebir",
                NormalShippingCost = 30,
                PickupShippingCost = 10,
                GovermentId = 5,
            },
            new City
            {
                City_Id = 25,
                CityName = "Kafr Saqr",
                NormalShippingCost = 35,
                PickupShippingCost = 20,
                GovermentId = 5,
            }
            #endregion
        );
        #endregion
    }
}
