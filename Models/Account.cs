
using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class Account
{
    [Key]
    public int AccountId { get; set; }
    public string PlayerCode { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Player Player { get; set; }
    
}