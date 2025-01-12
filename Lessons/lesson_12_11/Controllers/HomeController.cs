using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lesson_12_11.Models;
using Microsoft.AspNetCore.Authorization;

namespace lesson_12_11.Controllers;

public class HomeController : Controller
{
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Person person)
    {
        if (ModelState.IsValid)
        {
            if (person.Email.Equals("admin@gmail.com"))
            {
                ModelState.AddModelError("Email", "Email error");
                // ModelState.AddModelError("", "Email error");
                return View(person);
            }
            
            return Content($"{person.ToString()}");
        }
        return View(person);
    }
    
    

    [AllowAnonymous]
    public IActionResult IsEmailInUse(string email)
    {
        if (email.Equals("admin@gmail.com"))
        {
            return Json(false);
        }
    
        return Json(true);
    }
}