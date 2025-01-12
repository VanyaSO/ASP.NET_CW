using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace lesson_12_06.ViewComponents;

// [ViewComponent]
public class TimerViewComponent : ViewComponent
{
    private readonly TimeService _time;

    public TimerViewComponent(TimeService _service)
    {
        _time = _service;
    }

    public IViewComponentResult Invoke(bool includeSeconds)
    {
        return new HtmlContentViewComponentResult(new HtmlString($"<div>{_time.GetTime(includeSeconds)}</div>"));
        // return Content(_time.GetTime(includeSeconds));
    }
    
    // public string Invoke(bool includeSeconds)
    // {
    //     return _time.GetTime(includeSeconds);
    // }
}