using CoffeeShop.Extensions;
using CoffeeShop.Models;
using CoffeeShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

public class CartController : Controller
{
    private const string CartKey = "CART";
    private readonly ProductRepository _productRepository;

    public CartController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        var cart = GetCart();
        return View(cart);
    }

    public IActionResult Add(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            TempData["errorMessage"] = "Không tìm thấy sản phẩm.";
            return RedirectToAction("Index", "Products");
        }

        var cart = GetCart();
        var item = cart.FirstOrDefault(x => x.ProductId == id);

        if (item == null)
        {
            cart.Add(new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1,
                ImageUrl = product.ImageUrl
            });
        }
        else
        {
            item.Quantity++;
        }

        SaveCart(cart);
        TempData["successMessage"] = "Đã thêm sản phẩm vào giỏ hàng.";

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(int productId, int quantity)
    {
        var cart = GetCart();
        var item = cart.FirstOrDefault(x => x.ProductId == productId);

        if (item != null)
        {
            if (quantity <= 0)
            {
                cart.Remove(item);
            }
            else
            {
                item.Quantity = quantity;
            }
        }

        SaveCart(cart);
        return RedirectToAction("Index");
    }

    public IActionResult Remove(int id)
    {
        var cart = GetCart();
        var item = cart.FirstOrDefault(x => x.ProductId == id);

        if (item != null)
        {
            cart.Remove(item);
            SaveCart(cart);
            TempData["successMessage"] = "Đã xóa sản phẩm khỏi giỏ hàng.";
        }

        return RedirectToAction("Index");
    }

    public IActionResult Clear()
    {
        HttpContext.Session.Remove(CartKey);
        TempData["successMessage"] = "Đã xóa toàn bộ giỏ hàng.";
        return RedirectToAction("Index");
    }

    private List<CartItem> GetCart()
    {
        return HttpContext.Session.GetObject<List<CartItem>>(CartKey) ?? new List<CartItem>();
    }

    private void SaveCart(List<CartItem> cart)
    {
        HttpContext.Session.SetObject(CartKey, cart);
    }
}
