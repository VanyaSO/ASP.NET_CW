using lesson_12_06.Models;
using Microsoft.AspNetCore.Mvc;

namespace lesson_12_06.ViewComponents;

public class UserViewComponent : ViewComponent
{
    public string Invoke(User user)
    {
        return $"{user.Name}: {user.Age}";
    }
}