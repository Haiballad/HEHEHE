
using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class PlayerItem
{
    [Key]
    public int PlayerItemId { get; set; }
    public int PlayerId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public DateTime DateAcquired { get; set; }
}
