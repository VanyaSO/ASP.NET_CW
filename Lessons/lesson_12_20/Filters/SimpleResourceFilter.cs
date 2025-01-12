using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson_12_20.Filters;

// public class SimpleResourceFilter : IActionFilter
// {
    // public void OnActionExecuting(ActionExecutingContext context)
    // {
    //     // код
    // }
    //
    // public void OnActionExecuted(ActionExecutedContext context)
    // {
    //     // код
    // }
// }

// public class SimpleAsyncActionFilter : IAsyncActionFilter
// {
//     public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//     {
//         await next();
//     }
// }

// public class SimpleResourceFilter : Attribute, IResourceFilter
// {
//     public void OnResourceExecuting(ResourceExecutingContext context)
//     {
//         context.HttpContext.Response.Cookies.Append("LastVisit", DateTime.Now.ToString());
//     }
//
//     public void OnResourceExecuted(ResourceExecutedContext context)
//     {
//     }
// }

// public class SimpleResourceFilter : Attribute, IResourceFilter
// {
//     private int _id;
//     private string _token;
//
//     public SimpleResourceFilter(int id, string token)
//     {
//         _id = id;
//         _token = token;
//     }
//     public void OnResourceExecuting(ResourceExecutingContext context)
//     {
//     }
//
//     public void OnResourceExecuted(ResourceExecutedContext context)
//     {
//         context.HttpContext.Response.Headers.Add("Id", _id.ToString());
//         context.HttpContext.Response.Headers.Add("Token", _token);
//     }
// }


    public class SimpleResourceFilter : Attribute, IResourceFilter
    {
        private readonly ILogger _logger;

        public SimpleResourceFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("SimpleResourceFilter");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _logger.LogInformation($"OnResourceExecuted - {DateTime.Now}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _logger.LogInformation($"OnResourceExecuting - {DateTime.Now}");
        }
    }
