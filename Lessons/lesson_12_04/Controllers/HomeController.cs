using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lesson_12_04.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lesson_12_04.Controllers;

public class HomeController : Controller
{
    // public IActionResult Register()
    // IEnumerable<Company> companies = new List<Company>
    // {
    //     new Company { Id = 1, Name = "Apple" },
    //     new Company { Id = 2, Name = "Samsung" },
    //     new Company { Id = 3, Name = "Google" }
    // };

    // public IActionResult Index(string name, int age)
    // {
    //     return Content($"{name}, {age}");
    // }
    
    public IActionResult Create()
    {
        return View(new List<User>()
        {
            new User(){Age = 1, Email = "email", Name = "name", Password = "pass"},
            new User(){Age = 1, Email = "email", Name = "name", Password = "pass"},
            new User(){Age = 1, Email = "email", Name = "name", Password = "pass"},
            new User(){Age = 1, Email = "email", Name = "name", Password = "pass"}
        });
    }
 
 
    // [HttpPost]
    // public string Create(Product product)
    // {
        // Company company = companies.FirstOrDefault(c => c.Id == product.CompanyId);
        // return $"Добавлен новый элемент: {product.Name} ({company?.Name})";
    // }
 
}