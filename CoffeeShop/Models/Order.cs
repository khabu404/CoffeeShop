namespace CoffeeShop.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public List<OrderItem> Items { get; set; } = new();
    public decimal Total => Items.Sum(x => x.Total);
}
