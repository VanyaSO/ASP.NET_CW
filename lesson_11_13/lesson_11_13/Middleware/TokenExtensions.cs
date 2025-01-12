namespace lesson_11_13.Middleware;

public static class TokenExtensions
{
    public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string token)
    {
        return builder.UseMiddleware<TokenMiddleware>(token);
    }
}