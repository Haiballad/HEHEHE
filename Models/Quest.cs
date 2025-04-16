
using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class Quest
{
    [Key]
    public int QuestId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int RewardXP { get; set; }
}