using System.ComponentModel.DataAnnotations;

namespace lesson_12_04.Models;

public enum DayTime
{
    [Display(Name = "Утро")]
    Morning,
    [Display(Name = "День")]
    Afternoon,
    [Display(Name = "Вечер")]
    Evening,
    [Display(Name = "Ночь")]
    Night
}


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string? Hobby { get; set; }
    public DayTime DayTime { get; set; }
 
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}
