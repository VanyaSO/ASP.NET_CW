using lesson_12_20.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(
//     options =>
// {
//     // options.Filters.Add(new SimpleResourceFilter());
//     options.Filters.Add(typeof(SimpleResourceFilter)); // если принимает зависимость
// }
    );

builder.Services.AddScoped<SimpleResourceFilter>();
builder.Services.AddScoped<LeadTimeFilter>();

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