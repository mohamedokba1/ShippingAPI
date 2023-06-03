using Shipping.Entities.Models;
using System.ComponentModel.DataAnnotations;


namespace Shipping.Services.Dtos;

public class AddProductDto
{
    [Required]
    public Guid Product_Id { get; set; }
    [Required]
    [StringLength(50)]
    public string ProductName { get; set; } = string.Empty;
    [Required]

    public double Weight { get; set; }
    [Required]
    public double Price { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    //public Product ToProduct()
    //{
    //    return new Product
    //    {
    //        Product_Id = Product_Id,
    //        ProductName = ProductName,
    //        Weight = Weight,
    //        Price = Price,
    //        Orders = Orders
    //    };

    }
