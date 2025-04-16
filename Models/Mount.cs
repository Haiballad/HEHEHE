
using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class Mount
{
    [Key]
    public int MountId { get; set; }
    public string Name { get; set; }
    public float Speed { get; set; }
    public string Description { get; set; }
}