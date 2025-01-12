using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson_12_20.Filters;

public class LeadTimeFilter : Attribute, IResourceFilter
{
    private readonly ILogger _logger;

    public LeadTimeFilter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger("LeadTimeFilter");
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        _logger.LogInformation($"Time start - {DateTime.Now}");
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        _logger.LogInformation($"Time end - {DateTime.Now}");
    }
}