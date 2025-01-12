using lesson_11_29.Models;
using lesson_11_29.Views.User;
using Microsoft.AspNetCore.Mvc;

namespace lesson_11_29.Controllers;

public class UserController : Controller
{
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Register(User user)
    {
        if (!ModelState.IsValid)
        {
            TempData["Result"] = "Произошла ошибка";
        }
        TempData["Result"] = "Вы успешно зарегистрировались";
        return RedirectToAction("Register");
    }
}