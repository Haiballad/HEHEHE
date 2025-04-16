
namespace ASM.Models.ViewModels;

public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }

    public Item Item { get; set; }
}