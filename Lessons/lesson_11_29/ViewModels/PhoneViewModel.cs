using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace lesson_11_29.ViewModels;

public class PhoneViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CompanyId { get; set; }
    public string? Errors { get; set; }
}