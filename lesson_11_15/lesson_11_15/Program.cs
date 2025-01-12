using Humanizer;
using lesson_11_15.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITimeService, LongTimeService>();
builder.Services.AddTransient<ILogger, ConsoleLogger>();
builder.Services.AddTransient<TimeMessage>();

var app = builder.Build();

// app.Run(async context =>
// {
//     var timeService = app.Services.GetService<ITimeService>();
//     var timeService2 = app.Services.GetRequiredService<ITimeService>();
//     await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
// });
//
// app.Run(async context =>
// {
//     var timeService = context.RequestServices.GetService<ITimeService>();
//     var timeService2 = context.RequestServices.GetRequiredService<ITimeService>();
//     await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
// });

// app.Run(async context =>
// {
//     var timeService = app.Services.GetService<ITimeService>();
//     await context.Response.WriteAsync(timeService.GetTime());
// });

// app.Run(async context =>
// {
     // var timeMessage = context.RequestServices.GetService<TimeMessage>();
     // context.Response.ContentType = "text/html; charset=utf-8";
     // await context.Response.WriteAsync($"<h2>{timeMessage?.GetTime()}</h2>");
// });

app.UseMiddleware<TimeMessageMiddleware>();

app.Run();

class TimeMessage
{
    ITimeService timeService;

    public TimeMessage(ITimeService timeService)
    {
        this.timeService = timeService;
    }

    public string GetTime() => $"Time: {timeService.GetTime()}";
}


interface ITimeService
{
    string GetTime();
}

class ShortTimeService : ITimeService
{
    public string GetTime()
    {
        return DateTime.Now.ToShortTimeString();
    }
}

class LongTimeService : ITimeService
{
    private ILogger logger;

    public LongTimeService(ILogger logger)
    {
        this.logger = logger;
    }
    public string GetTime()
    {
        logger.Log($"Log - {DateTime.Now.ToLongTimeString()}");
        return DateTime.Now.ToLongTimeString();
    }
}

interface ILogger
{
    public void Log(string mess);
}

public class ConsoleLogger : ILogger
{
    public void Log(string mess) 
    {
        Console.WriteLine(mess);
    }
}








// app.Environment.EnvironmentName = "Production";
//
// if (app.Environment.IsDevelopment())
// {
//     app.Run(async (context) => await context.Response.WriteAsync("Dev"));
// }
// else
// {
//     app.Run(async (context) => await context.Response.WriteAsync("Prod"));
// }


// app.Use(async (context, next) =>
// {
//     context.Response.ContentType = "text/html; charset=utf-8";
//     if ((context.Request.Method == HttpMethods.Get && context.Request.Query.ContainsKey("number")))
//     {
//         await next.Invoke();
//     }
//     else
//     {
//         context.Response.StatusCode = 404;
//         await context.Response.WriteAsync("<h1>Page not found</h1>");
//     }
// });
//
// app.Use(async (context, next) =>
// {
//     if (int.TryParse(context.Request.Query["number"], out int number) && number >= 1 && number <= 1000)
//     {
//         await next.Invoke();
//     }
//     else
//     {
//         await context.Response.WriteAsync("<h1>Range not available or data not number</h1>");
//     }
// });
//         
// app.Run(async (context) =>
// {
//     int number = int.Parse(context.Request.Query["number"].ToString());
//     await context.Response.WriteAsync($"<h1>{number.ToWords()}</h1>");
// });




