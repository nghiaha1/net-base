using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Data;

public class Book
{
    [Key] public int Id { get; set; }
    [MaxLength(100)] public string Title { get; set; }
    public string Description { get; set; }
    [Range(0, double.MaxValue)] public double Price { get; set; }
    [Range(0, 100)] public int Quantity { get; set; }
}