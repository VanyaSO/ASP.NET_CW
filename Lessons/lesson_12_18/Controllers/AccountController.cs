using System.Security.Claims;
using lesson_12_18.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace lesson_12_18.Controllers;

public class AccountController : Controller
{
    private readonly UserService _users;

    public AccountController(UserService users)
    {
        _users = users;
    }
    
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(User user)
    {
        User? currentUser = _users.GetUser(user.Email);
        
        if (currentUser == null) return StatusCode(401);

        var claims = new List<Claim>() { new Claim(ClaimTypes.Name, user.Email) };
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookie");

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));
        
        Console.WriteLine("All Good");
        return View();
    }
}