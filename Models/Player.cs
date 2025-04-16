
using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class Player
{
    [Key]
    public int PlayerId { get; set; }
    public int AccountId { get; set; }
    public string Name { get; set; }
    public string CurrentMod { get; set; }
    public float Health { get; set; }
    public float Hunger { get; set; }
    public int XP { get; set; }
}