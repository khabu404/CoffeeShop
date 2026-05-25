using CoffeeShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

public class ProductsController : Controller
{
    private readonly ProductRepository _productRepository;

    public ProductsController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IActionResult Index(string? category)
    {
        var products = _productRepository.GetAll();

        if (!string.IsNullOrWhiteSpace(category))
        {
            products = products
                .Where(x => x.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        ViewBag.CurrentCategory = category;
        ViewBag.Categories = _productRepository.GetAll()
            .Select(x => x.Category)
            .Distinct()
            .ToList();

        return View(products);
    }

    public IActionResult Shop(string? category)
    {
        var products = _productRepository.GetAll();

        if (!string.IsNullOrWhiteSpace(category))
        {
            products = products
                .Where(x => x.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        ViewBag.CurrentCategory = category;
        ViewBag.Categories = _productRepository.GetAll()
            .Select(x => x.Category)
            .Distinct()
            .ToList();

        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    public IActionResult Detail(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return NotFound();
        }

        return View("Details", product);
    }
}
