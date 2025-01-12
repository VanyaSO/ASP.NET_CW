using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lesson_11_27.Models;

namespace lesson_11_27.Controllers;


public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(new List<string>(){"string", "string"});
    }
}

// public class HomeController : Controller
// {
//     [ViewData]
//     public string About { get; set; }
//     
//     public IActionResult Index()
//     {
//         ViewData["Welcome"] = "Hello world! view";
//         ViewData["User"] = new User() {Name = "User"};
//         About = "Some text";
//         ViewBag.Name = "My Name";
//         return View(new List<User>(){ new User() {Name = "User"}, new User() {Name = "Use1"}});
//     }
// }
//
// public class User
// {
//     public string Name { get; set; }
// }