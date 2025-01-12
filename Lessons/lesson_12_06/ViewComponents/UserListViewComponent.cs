using Microsoft.AspNetCore.Mvc;

namespace lesson_12_06.ViewComponents;

public class UserListViewComponent : ViewComponent
{
    private List<string> users;

    public UserListViewComponent()
    {
        users = new List<string>()
        {
            "Tom", "Kim", "Sem"
        };
    }

    public IViewComponentResult Invoke()
    {
        int number = users.Count;
        if (Request.Query.ContainsKey("number"))
        {
            Int32.TryParse(Request.Query["number"].ToString(), out number);
        }
        return View(users.Take(number));
    }

}