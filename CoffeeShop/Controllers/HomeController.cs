using CoffeeShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers;

public class HomeController : Controller
{
    private readonly ProductRepository _productRepository;

    public HomeController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        var products = _productRepository.GetAll().Take(6).ToList();
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
