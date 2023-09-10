namespace GraphNet.Entities.Models;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}