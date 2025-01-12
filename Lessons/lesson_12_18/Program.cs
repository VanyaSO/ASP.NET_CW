using System.Security.Claims;
using lesson_12_18.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;






var adminRole = new Role("admin");
var userRole = new Role("user");
var people = new List<Person>
{
    new Person("tom@gmail.com", "12345", adminRole),
    new Person("bob@gmail.com", "55555", userRole),
};
 
var builder = WebApplication.CreateBuilder();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/accessdenied";
    });
builder.Services.AddAuthorization();
 
var app = builder.Build();
 
app.UseAuthentication();
app.UseAuthorization(); 
 
app.MapGet("/accessdenied", async (HttpContext context) =>
{
    context.Response.StatusCode = 403;
    await context.Response.WriteAsync("Access Denied");
});
app.MapGet("/login", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    // html-форма для ввода логина/пароля
    string loginForm = @"<!DOCTYPE html>
    <html>
    <head>
        <meta charset='utf-8' />
        <title>Auth</title>
    </head>
    <body>
        <h2>Login Form</h2>
        <form method='post'>
            <p>
                <label>Email</label><br />
                <input name='email' />
            </p>
            <p>
                <label>Password</label><br />
                <input type='password' name='password' />
            </p>
            <input type='submit' value='Login' />
        </form>
    </body>
    </html>";
    await context.Response.WriteAsync(loginForm);
});
 
app.MapPost("/login", async (string? returnUrl, HttpContext context) =>
{
    var form = context.Request.Form;
    if (!form.ContainsKey("email") || !form.ContainsKey("password"))
        return Results.BadRequest("Email и/или пароль не установлены");
    string email = form["email"];
    string password = form["password"];
 
 
    Person? person = people.FirstOrDefault(p => p.Email == email && p.Password == password);
    // если пользователь не найден, отправляем статусный код 401
    if (person is null) return Results.Unauthorized();
    var claims = new List<Claim>
    {
        new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email),
        new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role.Name)
        //или так
        //new Claim(ClaimTypes.Role, currentUser.Role.Name);
    };
    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    await context.SignInAsync(claimsPrincipal);
    return Results.Redirect(returnUrl ?? "/");
});
// доступ только для роли admin
app.Map("/admin", [Authorize(Roles = "admin")] () => "Admin Panel");
 
// доступ только для ролей admin и user
app.Map("/", [Authorize(Roles = "admin, user")] (HttpContext context) =>
{
    var login = context.User.FindFirst(ClaimsIdentity.DefaultNameClaimType);
    var role = context.User.FindFirst(ClaimsIdentity.DefaultRoleClaimType);
    return $"Name: {login?.Value}\nRole: {role?.Value}";
});
app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return "Данные удалены";
});
 
app.Run();
 


    
    
    
    



// var builder = WebApplication.CreateBuilder();
//  
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
//  
// var app = builder.Build();
//  
// app.UseAuthentication();
//  
// // Добавление возраста
// app.MapGet("/addage", async (HttpContext context) =>
// {
//     if (context.User.Identity is ClaimsIdentity claimsIdentity)
//     {
//         claimsIdentity.AddClaim(new Claim("age", "37"));
//         var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//         await context.SignInAsync(claimsPrincipal);
//     }
//     return Results.Redirect("/");
// });
// // удаление телефона
// app.MapGet("/removephone", async (HttpContext context) =>
// {
//     if (context.User.Identity is ClaimsIdentity claimsIdentity)
//     {
//         var phoneClaim = claimsIdentity.FindFirst(ClaimTypes.MobilePhone);
//         // если claim успешно удален
//         if (claimsIdentity.TryRemoveClaim(phoneClaim))
//         {
//             var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//             await context.SignInAsync(claimsPrincipal);
//         }
//     }
//     return Results.Redirect("/");
// });
//  
// app.MapGet("/login", async (HttpContext context) =>
// {
//     var username = "Tom";
//     var company = "Microsoft";
//     var phone = "+12345678901";
//  
//     var claims = new List<Claim>
//     {
//         new Claim (ClaimTypes.Name, username),
//         new Claim ("company", company),
//         new Claim(ClaimTypes.MobilePhone,phone)
//     };
//     var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
//     var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//     await context.SignInAsync(claimsPrincipal);
//     return Results.Redirect("/");
// });
// app.Map("/", (HttpContext context) =>
// {
//     var username = context.User.FindFirst(ClaimTypes.Name);
//     var phone = context.User.FindFirst(ClaimTypes.MobilePhone);
//     var company = context.User.FindFirst("company");
//     var age = context.User.FindFirst("age");
//     return $"Name: {username?.Value}\nPhone: {phone?.Value}\n" +
//     $"Company: {company?.Value}\nAge: {age?.Value}";
// });
// app.MapGet("/logout", async (HttpContext context) =>
// {
//     await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//     return "Данные удалены";
// });
//  
// app.Run();
//
//
//  
// app.MapGet("/login", async (HttpContext context) =>
// {
//     var claims = new List<Claim>
//     {
//         new Claim (ClaimTypes.Name, "Tom"),
//         new Claim ("languages", "English"),
//         new Claim ("languages", "German"),
//         new Claim ("languages", "Spanish")
//     };
//     var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
//     var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//     await context.SignInAsync(claimsPrincipal);
//     return Results.Redirect("/");
// });
// app.Map("/", (HttpContext context) =>
// {
//     var username = context.User.FindFirst(ClaimTypes.Name);
//     var languages = context.User.FindAll("languages");
//     // объединяем список claims в строку
//     var languagesToString = "";
//     foreach (var l in languages)
//         languagesToString = $"{languagesToString} {l.Value}";
//     return $"Name: {username?.Value}\nLanguages: {languagesToString}";
// });
// app.MapGet("/logout", async (HttpContext context) =>
// {
//     await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//     return "Данные удалены";
// });
 


 






// var builder = WebApplication.CreateBuilder();
//  
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
//  
// var app = builder.Build();
//  
// app.UseAuthentication();
//  
// // Добавление возраста
// app.MapGet("/addage", async (HttpContext context) =>
// {
//     if (context.User.Identity is ClaimsIdentity claimsIdentity)
//     {
//         claimsIdentity.AddClaim(new Claim("age", "37"));
//         var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//         await context.SignInAsync(claimsPrincipal);
//     }
//     return Results.Redirect("/");
// });
// // удаление телефона
// app.MapGet("/removephone", async (HttpContext context) =>
// {
//     if (context.User.Identity is ClaimsIdentity claimsIdentity)
//     {
//         var phoneClaim = claimsIdentity.FindFirst(ClaimTypes.MobilePhone);
//         // если claim успешно удален
//         if (claimsIdentity.TryRemoveClaim(phoneClaim))
//         {
//             var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//             await context.SignInAsync(claimsPrincipal);
//         }
//     }
//     return Results.Redirect("/");
// });
//  
// app.MapGet("/login", async (HttpContext context) =>
// {
//     var username = "Tom";
//     var company = "Microsoft";
//     var phone = "+12345678901";
//  
//     var claims = new List<Claim>
//     {
//         new Claim (ClaimTypes.Name, username),
//         new Claim ("company", company),
//         new Claim(ClaimTypes.MobilePhone,phone)
//     };
//     var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
//     var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//     await context.SignInAsync(claimsPrincipal);
//     return Results.Redirect("/");
// });
// app.Map("/", (HttpContext context) =>
// {
//     var username = context.User.FindFirst(ClaimTypes.Name);
//     var phone = context.User.FindFirst(ClaimTypes.MobilePhone);
//     var company = context.User.FindFirst("company");
//     var age = context.User.FindFirst("age");
//     return $"Name: {username?.Value}\nPhone: {phone?.Value}\n" +
//     $"Company: {company?.Value}\nAge: {age?.Value}";
// });
// app.MapGet("/logout", async (HttpContext context) =>
// {
//     await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//     return "Данные удалены";
// });
//  
// app.Run();
//








// var builder = WebApplication.CreateBuilder();
//  
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
//  
// var app = builder.Build();
//  
// app.UseAuthentication();
//  
// app.MapGet("/login", async (HttpContext context) =>
// {
//     var username = "Tom";
//     var company = "Microsoft";
//     var phone = "+12345678901";
//  
//     var claims = new List<Claim>
//     {
//         new Claim (ClaimTypes.Name, username),
//         new Claim ("company", company),
//         new Claim(ClaimTypes.MobilePhone,phone)
//     };
//     var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
//     var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//     await context.SignInAsync(claimsPrincipal);
//     return Results.Redirect("/");
// });
// app.Map("/", (HttpContext context) =>
// {
//     // аналогично var username = context.User.Identity.Name
//     var username = context.User.FindFirst(ClaimTypes.Name);
//     var phone = context.User.FindFirst(ClaimTypes.MobilePhone);
//     var company = context.User.FindFirst("company");
//     return $"Name: {username?.Value}\nPhone: {phone?.Value}\nCompany: {company?.Value}";
// });
// app.MapGet("/logout", async (HttpContext context) =>
// {
//     await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//     return "Данные удалены";
// });
//  
// app.Run();






// var builder = WebApplication.CreateBuilder();
//  
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//     .AddCookie();
//  
// var app = builder.Build();
//  
// app.UseAuthentication();
//  
// app.MapGet("/login/{username}", async (string username, HttpContext context) =>
// {
//     var claims = new List<Claim> { new(ClaimTypes.Name, username) };
//     var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
//     var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//     await context.SignInAsync(claimsPrincipal);
//     return $"Установлено имя {username}";
// });
// app.Map("/", (HttpContext context) =>
// {
//     var user = context.User.Identity;
//     if (user is not null && user.IsAuthenticated)
//         return $"UserName: {user.Name}";
//     else return "Пользователь не аутентифицирован.";
// });
// app.MapGet("/logout", async (HttpContext context) =>
// {
//     await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//     return "Данные удалены";
// });
//  
// app.Run();




// var builder = WebApplication.CreateBuilder();
//  
// // аутентификация с помощью куки
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//     .AddCookie();
//  
// var app = builder.Build();
//  
// app.UseAuthentication();
//  
// app.MapGet("/login", async (HttpContext context) =>
// {
//     var claimsIdentity = new ClaimsIdentity("Undefined");
//     var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//     // установка аутентификационных куки
//     await context.SignInAsync(claimsPrincipal);
//     return Results.Redirect("/");
// });
//  
// app.MapGet("/logout", async (HttpContext context) =>
// {
//     await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//     return "Данные удалены";
// });
// app.Map("/", (HttpContext context) =>
// {
//     var user = context.User.Identity;
//     if (user is not null && user.IsAuthenticated)
//     {
//         return $"Пользователь аутентифицирован. Тип аутентификации: {user.AuthenticationType}";
//     }
//     else
//     {
//         return "Пользователь НЕ аутентифицирован";
//     }
// });
//  
// app.Run();