
using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class PlayerMount
{
    [Key]
    public int PlayerMountId { get; set; } 
    public int PlayerId { get; set; }
    public int MountId { get; set; }
    public DateTime DateAcquired { get; set; } 
}