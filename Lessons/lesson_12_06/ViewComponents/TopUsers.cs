using Microsoft.AspNetCore.Mvc;

namespace lesson_12_06.ViewComponents;

public class TopUsersViewComponent : ViewComponent
{
    private List<string> users;
    public TopUsersViewComponent()
    {
        users = new List<string>()
        {
            "Tom", "Kim", "Sem", "Alex", "Alisa", "Misha", "Ivan", "Petro", "Sasha", "Gleb"
        };
    }

    public IViewComponentResult Invoke()
    {
        return View("TopUsers",users.Take(10));
    }
}