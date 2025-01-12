using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lesson_12_18.Models;
using Microsoft.AspNetCore.Authorization;

namespace lesson_12_18.Controllers;

public class HomeController : Controller
{
    [Authorize]
    // [AllowAnonymous]
    public IActionResult Index()
    {
        // HttpContext.User 
            
        return View();
    }
}