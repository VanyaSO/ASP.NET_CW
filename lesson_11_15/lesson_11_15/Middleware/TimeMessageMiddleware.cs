namespace lesson_11_15.Middleware;

public class TimeMessageMiddleware
{
    private readonly RequestDelegate _next;

    public TimeMessageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var timeMessage = context.RequestServices.GetService<TimeMessage>();
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.WriteAsync($"<h2>{timeMessage?.GetTime()}</h2>");
    }
}
