
namespace ASM.Models.ViewModels
{
    public class ChangePasswordRequest
    {
        public int AccountId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}