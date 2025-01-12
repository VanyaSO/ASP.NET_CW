using Microsoft.AspNetCore.Razor.TagHelpers;

namespace lesson_12_04.TagHelpers;

public interface ITimeService
{
    string GetTime();
}
public class SimpleTimeService : ITimeService
{
    public string GetTime() => System.DateTime.Now.ToString("HH:mm:ss");
}

public class StyleInfo
{
    public string Color { get; set; }
    public int FontSize { get; set; }
    public string FontFamily { get; set; }
}


public class TimerTagHelper : TagHelper
{
    private readonly ITimeService _timeService;
    public TimerTagHelper(ITimeService timeService)
    {
        _timeService = timeService;
    }
    public StyleInfo StyleInfo { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var now = DateTime.Now;
        var time = String.Empty;
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;
        // устанавливаем цвет
        output.Attributes.SetAttribute("style", $"color:{StyleInfo.Color};font-size:${StyleInfo.FontSize};");
 
        output.Content.SetContent(time);
    }
}
    
// public class TimerTagHelper : TagHelper
// {
//     public override void Process(TagHelperContext context, TagHelperOutput output)
//     {
//         output.TagName = "div";
//         output.Content.SetContent($"Current time: {DateTime.Now.ToString("HH:mm:ss")}");
//     }
// }
// public class DateTagHelper : TagHelper
// {
//     public override void Process(TagHelperContext context, TagHelperOutput output)
//     {
//         output.TagName = "div";
//         output.Content.SetContent($"Current date: {DateTime.Now.ToString("dd/mm/yyyy")}");
//     }
// }
// public class SummaryTagHelper : TagHelper
// {
//     public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
//     {
//         output.TagName = "div";
//         // получаем вложенный контекст из дочерних tag-хелперов
//         var target = await output.GetChildContentAsync();
//         var content = "<h3>Summary info</h3>" + target.GetContent();
//         output.Content.SetHtmlContent(content);
//     }
// }