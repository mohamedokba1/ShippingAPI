using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using System.Security.Claims;

namespace Shipping.Entities;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

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

        //Data seeding
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        IServiceCollection services = new ServiceCollection();
        var serviceProvider = services.BuildServiceProvider();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationUserRole>>();
        var roles = new List<string>
        {
            "admin", "trader", "sales", "employee"
        };
        var adminClaims = new List<Claim>
        {
            new Claim("permission.goverments.add", "true"),
            new Claim("permission.goverments.update", "true"),
            new Claim("permission.goverments.delete", "true"),
            new Claim("permission.goverments.read", "true"),
            new Claim("permission.cities.add", "true"),
            new Claim("permission.cities.update", "true"),
            new Claim("permission.cities.delete", "true"),
            new Claim("permission.cities.read", "true"),
            new Claim("permission.traders.add", "true"),
            new Claim("permission.traders.update", "true"),
            new Claim("permission.traders.delete", "true"),
            new Claim("permission.traders.read", "true"),
            new Claim("permission.employees.add", "true"),
            new Claim("permission.employees.update", "true"),
            new Claim("permission.employees.delete", "true"),
            new Claim("permission.employees.read", "true"),
            new Claim("permission.branches.add", "true"),
            new Claim("permission.branches.update", "true"),
            new Claim("permission.branches.delete", "true"),
            new Claim("permission.branches.read", "true"),
            new Claim("permission.sales.add", "true"),
            new Claim("permission.sales.update", "true"),
            new Claim("permission.sales.delete", "true"),
            new Claim("permission.sales.read", "true"),
        };
        var traderClaims = new List<Claim>
        {
            new Claim("permission.orders.add", "true"),
            new Claim("permission.orders.update", "true"),
            new Claim("permission.orders.delete", "true"),
            new Claim("permission.orders.read", "true"),
        };
        var employeeClaims = new List<Claim>
        {
            new Claim("permission.orders.update", "true"),
            new Claim("permission.orders.read", "true"),
            new Claim("permission.branches.read", "true"),
            new Claim("permission.cities.read", "true"),
            new Claim("permission.cities.update", "true"),
            new Claim("permission.cities.add", "true"),
            new Claim("permission.goverments.read", "true"),
            new Claim("permission.goverments.update", "true"),
            new Claim("permission.goverments.add", "true"),
        };
        var salesClaims = new List<Claim>
        {
            new Claim("permission.orders.update", "true"),
            new Claim("permission.orders.read", "true"),
            new Claim("permission.branches.read", "true"),
            new Claim("permission.cities.read", "true"),
            new Claim("permission.goverments.read", "true"),
        };

        #region Roles
        foreach (var role in roles)
        {
            if (!roleManager.RoleExistsAsync(role).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new ApplicationUserRole
                {
                    Name = role,
                    Date = DateTime.Now
                });
            }
        }
        #endregion

        #region Traders
        var trader1 = userManager.CreateAsync(new ApplicationUser
        {
            Email = "trader1@example.com",
            PhoneNumber = "01234567891",
            UserName = "trader1"
        }, "123456").GetAwaiter().GetResult();
        if (trader1.Succeeded)
        {
            var newUser =  userManager.FindByEmailAsync("trader1@example.com").GetAwaiter().GetResult();
            if (newUser != null)
            {
                userManager.AddToRoleAsync(newUser, "trader");
                userManager.AddClaimsAsync(newUser, traderClaims);
                modelBuilder.Entity<Trader>().HasData(
                     new Trader
                     {
                         UserName = "trader1",
                         Address = "Cairo, Egypt",
                         CompanyBranch = "Helwan",
                         CostPerRefusedOrder = 10,
                         Email = "trader1@example.com",
                         PhoneNumber = "01234567891",
                         Orders = new[]
                         {
                        new Order
                        {
                            CompanyBranch = "Helwan",
                            DeliveredToVillage = false,
                            IsDeleted = false,
                            City = "Helwan",
                            ExtraWeightCost = 10,
                            Customer = new Customer
                            {
                                Name = "Ahmed Khaled",
                                Email = "ahmed@example.com",
                                Phone1 = "01255554886",
                                Phone2 = "01255554855",
                                City = "Tanta",
                                Goverment = "Gharbya"
                            },
                            ShippingType = ShippingType.Normal,
                            PaymentMethod = PaymentType.Cash,
                            Products = new[]
                            {
                                new Product
                                {
                                    ProductName = "P_10001",
                                    Price = 10,
                                    Weight = 2,
                                    Quantity = 1
                                },
                                new Product
                                {
                                    ProductName = "P_10002",
                                    Price = 20,
                                    Weight = 1,
                                    Quantity = 3
                                },
                                new Product
                                {
                                    ProductName = "P_10003",
                                    Price = 15,
                                    Weight = 3,
                                    Quantity = 2
                                }
                            },
                            TotalCost = 10,
                            Government = "Cairo",
                            State = OrderState.New,
                            TotalWeight = 11,
                            OrderDate = DateTime.Now,
                            SalesRepresentative = new SalesRepresentative
                            {
                                IsActive = true,
                                Name = "sales1",
                                DiscountType = DiscountType.FixedValue,
                                Address = "Cairo",
                                Branches = new List<Branch>
                                {
                                    new Branch { BranchName = "Cairo" },
                                    new Branch { BranchName = "Giza" },
                                    new Branch { BranchName = "Tanta" }
                                },
                            }
                        }
                         },
                         User = newUser
                     }
                 );
            }
        }
        #endregion

        #region Admins
        var admin =  userManager.CreateAsync(new ApplicationUser
        {
            Email = "admin@admin.com",
            PhoneNumber = "01234567891",
            UserName = "admin"
        }, "123456").GetAwaiter().GetResult();
        if (admin.Succeeded)
        {
            var newUser =  userManager.FindByEmailAsync("admin@admin.com").GetAwaiter().GetResult();
            if (newUser != null)
            {
                userManager.AddToRoleAsync(newUser, "admin");
                userManager.AddClaimsAsync(newUser, adminClaims);
            }
        }
        #endregion

        #region Employees
        var employee1 = userManager.CreateAsync(new ApplicationUser
        {
            Email = "employee1@example.com",
            PhoneNumber = "01234567891",
            UserName = "employee1"
        }, "123456").GetAwaiter().GetResult();
        if (employee1.Succeeded)
        {
            var newUser = userManager.FindByEmailAsync("employee1@example.com").GetAwaiter().GetResult();
            if (newUser != null)
            {
                userManager.AddToRoleAsync(newUser, "employee");
                userManager.AddClaimsAsync(newUser, employeeClaims);
                modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                     Email = "employee1@example.com",
                     IsActive = true,
                     Name = "Ahmed",
                     UserName = "employee1",
                     PhoneNumber = "01223522268",
                     User = newUser
            }
          );

            }
        }
        #endregion

        #region Sales
        var sales1 = userManager.CreateAsync(new ApplicationUser
        {
            Email = "sales1@example.com",
            PhoneNumber = "01234567891",
            UserName = "sales1"
        }, "123456").GetAwaiter().GetResult();
        if (sales1.Succeeded)
        {
            var newUser = userManager.FindByEmailAsync("sales1@example.com").GetAwaiter().GetResult();
            if (newUser != null)
            {
                userManager.AddToRoleAsync(newUser, "sales");
                userManager.AddClaimsAsync(newUser, salesClaims);
                modelBuilder.Entity<SalesRepresentative>().HasData(
                new SalesRepresentative
                {
                    Email = "sales1@example.com",
                    DiscountType = DiscountType.FixedValue,
                    CompanyPercentage = 10,
                    Branches = new[]
                    {
                        new Branch
                        {
                            BranchName = "Cairo",
                            CreatedAt = DateTime.Now,
                            State = true
                        }
                    },
                    IsActive = true,
                    Name = "Ahmed",
                    Address = "Cairo",
                    User = newUser
                }
                );
            }
        }
        #endregion

        #region Goverments and cities
        modelBuilder.Entity<Goverment>().HasData(
            new Goverment
            {
                GovermentName = "Gharbya",
                Cities = new List<City>
                {
                    new City {CityName = "Tanta"},
                    new City {CityName = "Smanoud"},
                    new City {CityName = "Mahalla El Kubra"},
                    new City {CityName = "Santa"},
                }
            },
            new Goverment
            {
                GovermentName = "Alexandria",
                Cities = new List<City>
                {
                    new City {CityName = "Borg El Arab"},
                    new City {CityName = "Alexandria"},
                    new City {CityName = "Abu Qir"},
                    new City {CityName = "Damanhur"},
                }
            },
            new Goverment
            {
                GovermentName = "Cairo",
                Cities = new List<City>
                {
                    new City {CityName = "Giza"},
                    new City {CityName = "Shubra El-Kheima"},
                    new City {CityName = "Helwan"},
                    new City {CityName = "6th of October City"},
                }
            },
            new Goverment
            {
                GovermentName = "Menofia",
                Cities = new List<City>
                {
                    new City {CityName = "Shibin El Kom"},
                    new City {CityName = "Menouf"},
                    new City {CityName = "Sadat City"},
                    new City {CityName = "Ashmoun"},
                }
            }
          );
        #endregion
    }
}
