using System.ComponentModel.DataAnnotations.Schema;

namespace GraphNet.Entities.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int CategoryId { get; set; }
}