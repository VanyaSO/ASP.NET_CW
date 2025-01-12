using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson_12_20.Filters;

public class FeatureEnabledAttribute : Attribute, IResourceFilter
{
    public bool IsEnabled { get; set; }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        if (!IsEnabled)
        {
            context.Result = new BadRequestResult();
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
    }
}
