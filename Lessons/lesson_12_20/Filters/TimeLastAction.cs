using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson_12_20.Filters;

public class TimeLastActionResourceFilter : Attribute, IResourceFilter
{
    private string _markName { get; set; }
    private TodoTask _task { get; set; }

    public TimeLastActionResourceFilter(TodoTask task, string markName)
    {
        _task = task;
        _markName = markName;
    }
    
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        _task.TimeMarkName = _markName;
        _task.TimeMark = DateTime.Now;
    }
}

public class TodoTask
{
    public string Name { get; set; }
    public string TimeMarkName { get; set; }
    public DateTime TimeMark { get; set; }
}