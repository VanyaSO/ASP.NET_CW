using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson_12_20.Filters;

public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        string actionName = context.ActionDescriptor.DisplayName;
        string exceptionStack = context.Exception.StackTrace;
        string exceptionMessage = context.Exception.Message;

        context.Result = new ContentResult
        {
            Content = $"У методі {actionName} виникла помилка: \n{exceptionMessage} \n{exceptionStack}"
        };

        context.ExceptionHandled = true;
    }
}
