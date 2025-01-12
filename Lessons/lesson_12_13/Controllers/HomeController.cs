using System.Diagnostics;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using lesson_12_13.Models;

namespace lesson_12_13.Controllers;

public class HomeController : Controller
{
    
    // public IActionResult Index()
    // {
    //     Person person = new Person() { Name = "Alex", Age = 11 };
    //     if (HttpContext.Session.Keys.Contains("data"))
    //     {
    //         string json = HttpContext.Session.GetString("data");
    //         Person per = JsonSerializer.Deserialize<Person>(json);
    //         
    //         return Content(per.ToString());
    //     }
    //     else
    //     {
    //         string json = JsonSerializer.Serialize(person);
    //         HttpContext.Session.SetString("data", json);
    //         return Content("Session is null");
    //     }
    // }
    
    // public IActionResult Index()
    // {
    //     if (HttpContext.Session.Keys.Contains("data"))
    //     {
    //         return Content(HttpContext.Session.GetString("data"));
    //     }
    //     else
    //     {
    //         HttpContext.Session.SetString("data", "MyData");
    //         return Content("Session is null");
    //     }
    // }
    
    public IActionResult Index()
    {
        Cookie("hello", "how are you");
        return RedirectToAction(nameof(Privacy));
    }
    
    public IActionResult Privacy()
    {
        return Content(Cookie("hello"));
    }

    public string Cookie(string key)
    {
        if (HttpContext.Request.Cookies.ContainsKey(key))
        {
            return HttpContext.Request.Cookies[key];
        }

        return "Cookie is null";
    }
    
    public void Cookie(string key, string value)
    {
        if (!HttpContext.Request.Cookies.ContainsKey(key))
        {
            HttpContext.Response.Cookies.Append(key, value);
        }
    }

    
    
    
    // public IActionResult Index()
    // {
    //     // HttpContext.Items["username"] = "Alex";
    //
    //     if (HttpContext.Request.Cookies.ContainsKey("data"))
    //     {
    //         return Content(HttpContext.Request.Cookies["data"]);
    //     }
    //     else
    //     {
    //         CookieOptions cookieOptions = new CookieOptions()
    //         {
    //             Expires = DateTimeOffset.Now.AddDays(1), // устанавливаем время сколько будет жить кука
    //             SameSite = SameSiteMode.None, // ?
    //             Secure = true, // ?
    //             HttpOnly = true,
    //             Path = "/"
    //         };
    //         
    //         HttpContext.Response.Cookies.Append("data", "qwertyuiop");
    //         return Content("Cookie is null");
    //     }
    // }
    
}

