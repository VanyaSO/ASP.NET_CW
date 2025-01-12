namespace lesson_11_13.Middleware;

public class TokenMiddleware
{
    private readonly RequestDelegate _next;
    private string token;

    public TokenMiddleware(RequestDelegate next, string token)
    {
        _next = next;
        this.token = token;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Query["token"];
        if (token != this.token)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Token is invalid");
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}
