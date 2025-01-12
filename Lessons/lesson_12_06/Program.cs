var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<TimeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


interface ITime
{
    public string GetTime(bool includeSeconds);
}

public class TimeService : ITime
{
    public string GetTime(bool includeSeconds)
    {
        if (includeSeconds)
        {
            return $"Current time: {DateTime.Now.ToString("hh:mm:ss")}";
        }
        return $"Current time: {DateTime.Now.ToString("hh:mm")}";
    }
}