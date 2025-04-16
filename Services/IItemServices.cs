using ASM.Models;

namespace ASM.Services
{
    public interface IItemServices
    {
        // 1. lấy tất cả tài nguyên
        IEnumerable<Item> GetAllItems();
        // 2. Lấy thông tin tất cả người chơi theo từng chế độ chơi (thông tin chế độ chơi sẽ do người dùng truyền lên API, ví dụ: 'Sinh tồn')
        Task<List<Player>> GetPlayersByGameModeAsync(string gameMode);
        // 3. lấy tất cả các vũ khí có trên 100 điểm kinh nghiệm
        Task<List<Item>> GetWeaponsWithExperienceAsync(int experience);
        // 4. Lấy thông tin các item mà người chơi có thể mua với số điểm kinh nghiệm tích lũy hiện tại của họ.
        Task<List<Item>> GetPurchasableItemsForPlayerAsync(int playerId);
        // 5. Lấy thông tin các item có tên chứa từ 'kim cương' và có giá trị dưới 500 điểm kinh nghiệm
        Task<List<Item>> GetItemsWithNameAndPriceAsync(string name, int maxPrice);
        // 6. Lấy thông tin tất cả các giao dịch mua item sắp xếp theo thứ tự thời gian 
        List<PlayerItem> GetPlayerItemHistory(int playerId);
        // 7. Thêm thông tin của một item mới
        List<Item> AddItem(Item item);
        // 8. Cập nhật mật khẩu của acount
        Account ChangePassword(int accountId, string currentPassword, string newPassword);
        // 9. Lấy danh sách các item được mua nhiều nhất
        List<Item> GetMostPurchasedItems(int topN);
        // 10. Lấy danh sách người chơi và số lần họ đã mua hàng
        List<PlayerItem> GeAlltPlayerAndPurchaseCounts();
    }
}