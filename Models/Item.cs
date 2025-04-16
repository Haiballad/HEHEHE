
using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class Item
{
    [Key]
    public int ItemId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string ImageUrl { get; set; }
    public int XPPrice { get; set; } 
    public string Description { get; set; }
}