using System.ComponentModel.DataAnnotations.Schema;

namespace GraphNet.Entities.Models;

public class Product
{
    public int Id { get; set; }
    public int Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int CategoryId { get; set; }
}