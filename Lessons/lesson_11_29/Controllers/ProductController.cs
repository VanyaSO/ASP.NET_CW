using lesson_11_29.Models;
using lesson_11_29.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace lesson_11_29.Controllers;

public class ProductController : Controller
{
    private static List<Product> _products = new List<Product>
    {
        new Product { Id=1, Name = "Product 1", Count = 10, Price = 99.99m },
        new Product { Id=2, Name = "Product 2", Count = 5, Price = 149.50m },
        new Product { Id=3, Name = "Product 3", Count = 20, Price = 49.99m },
        new Product { Id=4, Name = "Product 4", Count = 15, Price = 199.99m },
        new Product { Id=5, Name = "Product 5", Count = 7, Price = 79.95m }
    };

    private static List<Cart> _cart = new List<Cart>()
    {
        new Cart(){ ProductId = 1, Quantity = 5}
    };
    
    public IActionResult Index()
    {
        List<ProductViewModel> productViewModels = _products
            .Select(p => new ProductViewModel
            {
                Id = p.Id, 
                Name = p.Name,
                Count = p.Count,
                Price = p.Price,
                QuantityInCart = _cart.FirstOrDefault(c => c.ProductId == p.Id)?.Quantity ?? 0
            })
            .ToList();
        
        return View(productViewModels);
    }
    
    [HttpPost]
    public IActionResult Index(int id)
    {
        Cart cart = _cart.FirstOrDefault(c => c.ProductId == id);
        if (cart is not null)
        {
            cart.Quantity += 1;
        }
        else
        {
         _cart.Add(new Cart(){ ProductId = id, Quantity = 1});   
        }
        return RedirectToAction("Index");
    }
}