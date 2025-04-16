
using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class GameMode
{
    [Key]
    public int ModeId { get; set; }
    public string ModeName { get; set; }
    public string Description { get; set; }
}