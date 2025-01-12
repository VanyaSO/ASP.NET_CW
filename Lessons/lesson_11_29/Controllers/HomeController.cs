using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using lesson_11_29.Models;
using lesson_11_29.Services;
using lesson_11_29.ViewModels;

namespace lesson_11_29.Controllers;

public class HomeController : Controller
{
    private readonly PhoneService _phoneService;
    public HomeController(PhoneService phoneService)
    {
        _phoneService = phoneService;
    }
 
    private List<CompanyViewModel> GetCompanies()
    {
        List<CompanyViewModel> compModels = _phoneService.GetCompanies()
            .Select(c => new CompanyViewModel { Id = c.Id, Name = c.Name })
            .ToList();
 
 
        compModels.Insert(0, new CompanyViewModel { Id = 0, Name = "Все" });
        return compModels;
    }
 
 
    public IActionResult Index(int? companyId)
    {
        IndexViewModel ivm = new IndexViewModel { Companies = GetCompanies(), Phones = _phoneService.GetPhones() };
 
        if (companyId != null && companyId > 0)
        {
            ivm.SelectedCompanyId = companyId;
            ivm.Phones = _phoneService.GetPhones().Where(p => p.Manufacturer.Id == companyId);
        }
        return View(ivm);
    }
    
    
    public IActionResult CreatePhone()
    {
        ViewBag.Companies = GetCompanies();
        return View();
    }
 
    [HttpPost]
    public IActionResult CreatePhone(PhoneViewModel phone)
    {
        var st = new StringBuilder();
        foreach (var value in ModelState.Values)
        {
            foreach (var error in value.Errors)
            {
                st.Append(error.ErrorMessage + "<br />");
            }
        }
        phone.Errors = st.ToString();
 
        ViewBag.Companies = GetCompanies();
        return View(phone);
    }
}
