using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace lesson_12_11.Models;

public record Person
{
    // [Key]
    // [ReadOnly(true)]
    // public int Id { get; set; }
    [Required(ErrorMessage = "Укажите E-Mail адрес")]
    [EmailAddress(ErrorMessage = "Некорректный Email адрес")]
    [Remote(action: "IsEmailInUse", controller: "Home", ErrorMessage = "Email уже используется")]
    public string Email { get; set; }
    
    [Display(Name = "Имя")]
    [Required(ErrorMessage = "Имя обязательно для заполнения!")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Укажите имя длинной от 2-ух до 100 символов")]
    [PersonName(new string[] {"Admin", "Guest"}, ErrorMessage = "Недоступное имя!")]
    public string Name { get; set; }
    
    // [Display(Name = "Возраст")]
    // [Required(ErrorMessage = "Возраст обязателен для заполнения!")]
    // [Range(minimum: 1, maximum: 110, ErrorMessage = "Укажите возраст в промежутке от 1 до 110")]
    // public int? Age { get; set; }
    
    // [Display(Name = "Зарплата")]
    // [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Укажите заработную плату от 0")]
    // [Required(ErrorMessage = "Зарплата обязательна для заполнения!")]
    // public decimal? Salary { get; set; }
    //
    // [DataType(DataType.Password)]
    // public string Password { get; set; }
    //
    // [Compare("Password", ErrorMessage = "Пароль не совпадают")]
    // [DataType(DataType.Password)]
    // public string PasswordConfirm { get; set; }
    
    // [Required(ErrorMessage = "Укажите адрес сайта")]
    // [Url(ErrorMessage = "Неккоректный адресс сайта")]
    // public string SireUrl { get; set; }
    
    // [RegularExpression(@"(1)|(3)|(7)", ErrorMessage = "Не верно")]
    // public int AreaCode { get; set; }
    
    // [CustomValidation(typeof(ValidationContext), "IsValid")] -- не до конца правильно
    // public bool IsVisible { get; set; }
}