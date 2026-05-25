using CoffeeShop.Extensions;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

public class OrdersController : Controller
{
    private const string CartKey = "CART";
    private static readonly List<Order> Orders = new();
    private static int _orderId = 1;

    public IActionResult Index()
    {
        return View(Orders.OrderByDescending(x => x.OrderDate).ToList());
    }

    public IActionResult Checkout()
    {
        var cart = GetCart();

        if (!cart.Any())
        {
            TempData["errorMessage"] = "Giỏ hàng đang trống. Vui lòng thêm sản phẩm trước khi đặt hàng.";
            return RedirectToAction("Index", "Cart");
        }

        var model = new CheckoutViewModel
        {
            CartItems = cart
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Checkout(CheckoutViewModel model)
    {
        var cart = GetCart();

        if (!cart.Any())
        {
            TempData["errorMessage"] = "Giỏ hàng đang trống.";
            return RedirectToAction("Index", "Cart");
        }

        model.CartItems = cart;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var order = new Order
        {
            Id = _orderId++,
            CustomerName = model.CustomerName,
            Phone = model.Phone,
            Address = model.Address,
            OrderDate = DateTime.Now,
            Items = cart.Select(x => new OrderItem
            {
                ProductName = x.ProductName,
                Price = x.Price,
                Quantity = x.Quantity
            }).ToList()
        };

        Orders.Add(order);
        HttpContext.Session.Remove(CartKey);

        TempData["successMessage"] = "Đặt hàng thành công!";
        return RedirectToAction("Success", new { id = order.Id });
    }

    public IActionResult Success(int id)
    {
        var order = Orders.FirstOrDefault(x => x.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    private List<CartItem> GetCart()
    {
        return HttpContext.Session.GetObject<List<CartItem>>(CartKey) ?? new List<CartItem>();
    }
}
