using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using lesson_11_22.Models;
using lesson_11_22.Util;
using Microsoft.Extensions.FileProviders.Physical;

namespace lesson_11_22.Controllers;

public class HomeController : Controller
{
    
    public IActionResult Index()
    {
        // https://localhost:7035/home?name=Alex&age=18&weight=50&ratings[0]=1&ratings[1]=5
        string name = Request.Query["name"];
        int age = int.Parse(Request.Query["age"]);
        int weight = int.Parse(Request.Query["weight"]);
        string[] arrayRatings = Request.Query["ratings"];
        
        StringBuilder str = new StringBuilder();
        str.Append(name);
        str.Append(age);
        str.Append(weight);
        str.Append(String.Join(" ", arrayRatings));

        return Content(str.ToString());
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult Contact()
    {
        return View();
    }
    
    
    // public IActionResult Index()
    // {
    //     ITimeService timeService = HttpContext.RequestServices.GetService<ITimeService>();
    //
    //     return Content(timeService.Time);
    // }
    
    // private readonly IWebHostEnvironment _appEnvironment;

    // public HomeController(IWebHostEnvironment appEnvironment)
    // {
        // _appEnvironment = appEnvironment;
    // }

    // private readonly ITimeService _timeService;
    // public HomeController(ITimeService timeService)
    // {
    //     _timeService = timeService;
    // }
    
    // public IActionResult Index([FromServices] ITimeService _timeService)
    // {
        // return Content(_timeService.Time);


        // string file_path = _appEnvironment.WebRootPath + "/files/1.png";
        // string file_type = "application/pdf";
        // string file_name = "3.png";

        // только из wwwroot
        // return PhysicalFile(file_path, file_type, file_name);

        // FileStream fs = new FileStream(file_path, FileMode.Open);
        // return File(fs, file_type, file_name);

        // return new HtmlResult("Hello");
        // return View();
        // return Json(new Person("", 30));
        // return Redirect("~/home/about");
        // return RedirectToAction("About");
        // return RedirectToAction("About", "Company", new {name = "Alex", age=30});
    // }

    // public IActionResult About() => Content("About");

    
    
    
    // public string GetUser(Person person)
    // {
    //     return person.ToString();
    // }

    // https://localhost:7035/home/getarray?array=1&array=2
    // public string GetArray(int[] array)
    // {
    //     return $"Array: {String.Join(" ", array)}";
    // }
    //
    // // https://localhost:7035/home/getarray?people.name=Alex&people.age=2
    // public string GetArrayPerson(Person[] people)
    // {
    //     var st = new StringBuilder();
    //     st.Append("All people: \n");
    //     foreach (var person in people)
    //     {
    //         st.Append($"{people}\n");
    //     }
    //
    //     return st.ToString();
    // }
}

// public interface ITimeService
// {
//     string Time { get; }
// }
// public class SimpleTimeService : ITimeService
// {
//     public SimpleTimeService()
//     {
//         Time = DateTime.Now.ToString("hh:mm:ss");
//     }
//     public string Time { get; }
// }