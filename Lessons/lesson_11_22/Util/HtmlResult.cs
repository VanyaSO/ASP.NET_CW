using Microsoft.AspNetCore.Mvc;

namespace lesson_11_22.Util;

public class HtmlResult : IActionResult
{
    string htmlCode;
    
    public HtmlResult(string html)
    {
        htmlCode = html;
    }
    
    public async Task ExecuteResultAsync(ActionContext context)
    {
        string fullHtmlCode = "<!DOCTYPE html><html><head>";
        fullHtmlCode += "<title>Главная страница</title>";
        fullHtmlCode += "<meta charset=utf-8 />";
        fullHtmlCode += "</head> <body>";
        fullHtmlCode += htmlCode;
        fullHtmlCode += "</body></html>";
        await context.HttpContext.Response.WriteAsync(fullHtmlCode);
    }
}