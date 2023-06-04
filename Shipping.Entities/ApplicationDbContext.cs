using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shipping.Entities.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Identity;

namespace Shipping.Entities;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
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
    public DbSet<Privellge> Privellges { get; set; }
    public DbSet<SpecialPackage> SpecialPackages { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("Users");
    }
}
