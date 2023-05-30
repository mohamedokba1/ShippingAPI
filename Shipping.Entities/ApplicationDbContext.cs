using Microsoft.EntityFrameworkCore;
using Shipping.Entities.Models;

namespace Shipping.Entities;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    public ApplicationDbContext() { }
    public DbSet<Trader> Traders { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SalesRepresentative> SalesRepresentatives { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Goverment> Goverments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PrivellgeDto> Privellges { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
