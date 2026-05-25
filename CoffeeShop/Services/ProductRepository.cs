using CoffeeShop.Models;

namespace CoffeeShop.Services;

public class ProductRepository
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Cà phê đen", Description = "Cà phê rang xay đậm vị, phù hợp cho người thích vị mạnh.", Price = 25000, Category = "Coffee", ImageUrl = "https://images.unsplash.com/photo-1514432324607-a09d9b4aefdd?auto=format&fit=crop&w=800&q=80" },
        new Product { Id = 2, Name = "Cà phê sữa", Description = "Cà phê truyền thống kết hợp sữa đặc thơm béo.", Price = 30000, Category = "Coffee", ImageUrl = "https://images.unsplash.com/photo-1461023058943-07fcbe16d735?auto=format&fit=crop&w=800&q=80" },
        new Product { Id = 3, Name = "Bạc xỉu", Description = "Thức uống nhẹ nhàng với nhiều sữa và hương cà phê dịu.", Price = 32000, Category = "Coffee", ImageUrl = "https://images.unsplash.com/photo-1517701604599-bb29b565090c?auto=format&fit=crop&w=800&q=80" },
        new Product { Id = 4, Name = "Latte", Description = "Espresso hòa quyện cùng sữa tươi tạo vị béo nhẹ.", Price = 45000, Category = "Coffee", ImageUrl = "https://images.unsplash.com/photo-1570968915860-54d5c301fa9f?auto=format&fit=crop&w=800&q=80" },
        new Product { Id = 5, Name = "Cappuccino", Description = "Lớp bọt sữa mịn, hương cà phê thơm và cân bằng.", Price = 45000, Category = "Coffee", ImageUrl = "https://images.unsplash.com/photo-1534778101976-62847782c213?auto=format&fit=crop&w=800&q=80" },
        new Product { Id = 6, Name = "Mocha", Description = "Cà phê kết hợp chocolate thơm ngọt hấp dẫn.", Price = 49000, Category = "Coffee", ImageUrl = "https://images.unsplash.com/photo-1579888071069-c107a6f79d82?auto=format&fit=crop&w=800&q=80" },
        new Product { Id = 7, Name = "Trà đào cam sả", Description = "Trà trái cây thanh mát với đào, cam và sả.", Price = 39000, Category = "Tea", ImageUrl = "https://images.unsplash.com/photo-1556679343-c7306c1976bc?auto=format&fit=crop&w=800&q=80" },
        new Product { Id = 8, Name = "Trà sữa truyền thống", Description = "Trà sữa thơm béo, vị ngọt dễ uống.", Price = 35000, Category = "Tea", ImageUrl = "https://images.unsplash.com/photo-1558857563-b371033873b8?auto=format&fit=crop&w=800&q=80" },
        new Product { Id = 9, Name = "Matcha đá xay", Description = "Matcha mát lạnh, béo nhẹ và thơm mùi trà xanh.", Price = 52000, Category = "Ice Blended", ImageUrl = "https://images.unsplash.com/photo-1515823064-d6e0c04616a7?auto=format&fit=crop&w=800&q=80" },
        new Product { Id = 10, Name = "Chocolate đá xay", Description = "Chocolate ngọt dịu, đá xay mịn, phù hợp ngày nóng.", Price = 52000, Category = "Ice Blended", ImageUrl = "https://images.unsplash.com/photo-1541658016709-82535e94bc69?auto=format&fit=crop&w=800&q=80" },
        new Product { Id = 11, Name = "Bánh tiramisu", Description = "Bánh mềm thơm vị cà phê và kem béo.", Price = 42000, Category = "Cake", ImageUrl = "https://images.unsplash.com/photo-1571877227200-a0d98ea607e9?auto=format&fit=crop&w=800&q=80" },
        new Product { Id = 12, Name = "Bánh croissant", Description = "Bánh sừng bò giòn thơm, dùng kèm cà phê rất hợp.", Price = 35000, Category = "Cake", ImageUrl = "https://images.unsplash.com/photo-1555507036-ab1f4038808a?auto=format&fit=crop&w=800&q=80" }
    };

    public List<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(x => x.Id == id);
    }
}
