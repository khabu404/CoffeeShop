using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models;

public class CheckoutViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập họ tên")]
    [Display(Name = "Họ tên")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
    [Display(Name = "Số điện thoại")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
    [Display(Name = "Địa chỉ giao hàng")]
    public string Address { get; set; } = string.Empty;

    public List<CartItem> CartItems { get; set; } = new();
    public decimal Total => CartItems.Sum(x => x.Total);
}
