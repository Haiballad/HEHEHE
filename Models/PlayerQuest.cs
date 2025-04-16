
using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class PlayerQuest
{
    [Key]
    public int PlayerQuestId { get; set; }
    public int PlayerId { get; set; }
    public int QuestId { get; set; }
    public string Status { get; set; } // e.g., "In Progress", "Completed"
    public DateTime? CompletedAt { get; set; }
}
