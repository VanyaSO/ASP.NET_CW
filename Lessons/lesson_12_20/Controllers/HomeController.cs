using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using lesson_12_20.Filters;
using Microsoft.AspNetCore.Mvc;
using lesson_12_20.Models;

namespace lesson_12_20.Controllers;

public class HomeController : Controller
{
    // [SimpleResourceFilter(30, "tokeeen")]
    // [ServiceFilter(typeof(SimpleResourceFilter))]
    // [FakeNotFountResourceFilter]
    // [FeatureEnabled]

    // [CheckFilter]

    [ServiceFilter(typeof(LeadTimeFilter))]
    // [TimeLastActionResourceFilter(todoTask, )]
    public async Task<IActionResult> Index(TodoTask todoTask)
    {
        await Task.Delay(5000);
        return View();
    }
}