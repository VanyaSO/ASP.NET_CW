using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson_12_20.Filters;

public class FakeNotFountResourceFilter : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        context.Result = new ContentResult() { Content = "Ресурс не найден" };
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
    }
}