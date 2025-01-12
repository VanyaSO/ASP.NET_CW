using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace lesson_11_29.Models;

public class User
{
    [BindNever]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    [Range(8,16)]
    public string Password { get; set; }
}