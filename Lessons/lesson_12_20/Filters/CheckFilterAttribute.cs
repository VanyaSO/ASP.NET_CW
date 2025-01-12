using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson_12_20.Filters;

public class CheckFilterAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ModelState.IsValid == false)
            context.ActionArguments["id"] = 34;

        await next();
    }
}