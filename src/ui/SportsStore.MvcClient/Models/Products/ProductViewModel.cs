using System.ComponentModel.DataAnnotations;

namespace SportsStore.MvcClient.Models.Products;

public class ProductViewModel
{
    public int Id { get; set; }

    [Required]
    [MaxLength(70)]
    public string Name { get; set; }
    public string Description { get; set; }

    [Required]
    [MaxLength(70)]

    public string Category { get; set; }

    [Required]
    public  decimal Price { get; set; }
}
