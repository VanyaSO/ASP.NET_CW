using lesson_11_22.Models;
using Microsoft.AspNetCore.Mvc;

namespace lesson_11_22.Controllers;

public class CompanyController : Controller
{
    public IActionResult Index()
    {
        
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Clients()
    {
        return View();
    }
}