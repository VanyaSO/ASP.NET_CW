using System.Text;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddTransient<TimeService>();
// builder.Services.AddTransient<IHelloService, RuHelloService>();
// builder.Services.AddTransient<IHelloService, EnHelloService>();
// builder.Services.AddSingleton<IUser, UserRepository>();

var app = builder.Build();

////// конец практики
///
/// 
// Определить интерфейс и класс работающий с пользователями. Создать конечную точку, в которой через полученную зависимость, вернуть пользователя по его Id.
// app.MapGet("/{id:int}", async (HttpContext context, int id) =>
// {
//     var user = context.RequestServices.GetService<IUser>().GetUserById(id);
//     if (user is not null)
//     {
//         await context.Response.WriteAsync($"{user.Id} {user.Name} {user.Age}");
//     }
//     else
//     {
//         await context.Response.WriteAsync("User not found");
//     }
// });
//
// app.Run();
//
// interface IUser
// {
//     public User GetUserById(int id);
// }
//
// class UserRepository : IUser
// {
//     List<User> users = new List<User>() { new User() { Id = 1, Name = "Ivan", Age = 20},  new User() { Id = 2, Name = "Alex", Age = 22 }};
//
//     public User GetUserById(int id)
//     {
//         return users.FirstOrDefault(e => e.Id == id);
//     }
// }
//
// public class User
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public int Age { get; set; } 
// }


// app.Map("/{id}", (int id) => $"{id}");
// app.Map("/{name:maxlength(20)}", (string name) => $"{name}");
// app.Map("/{email:regex(^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{{2,}}$)}", (string email) => $"{email}");


////// конец практики








// Используя метод Map, определить 5 маршруток в стиле сайта визитки. Получить все имеющиеся в приложении конечные точки и вернуть пользователю в виде гиперссылок.

// app.Map("/", async context => await context.Response.WriteAsync("Home"));
// app.Map("/about", async context => await context.Response.WriteAsync("about"));
// app.Map("/shop", async context => await context.Response.WriteAsync("shop"));
// app.Map("/payment", async context => await context.Response.WriteAsync("payment"));
// app.Map("/cart", async context => await context.Response.WriteAsync("payment"));
//
// app.Map("/routes", async (IEnumerable<EndpointDataSource> endpoints, HttpContext context) =>
// {
//     StringBuilder routes = new StringBuilder();
//     var points = endpoints.SelectMany(e => e.Endpoints);
//
//     foreach (var route in points)
//     {
//         routes.Append($"<a href=\"https://localhost:7080{route}\">{route}</a> \n");
//     }
//     
//     context.Response.ContentType = "text/html; charset=utf-8";
//     await context.Response.WriteAsync(routes.ToString());
// });

// app.Run();

// app.UseMiddleware<HelloMiddleware>();
//
// class HelloMiddleware
// {
//     private readonly List<IHelloService> helloServices;
//
//     public HelloMiddleware(RequestDelegate _, List<IHelloService> helloServices)
//     {
//         this.helloServices = helloServices; // Сохраняем полученные сервисы
//     }
//
//     public async Task InvokeAsync(HttpContext context)
//     {
//         context.Response.ContentType = "text/html; charset=utf-8";
//         string responseText = "";
//
//         foreach (var service in helloServices)
//         {
//             responseText += $"<h3>{service.Message}</h3>";
//         }
//
//         await context.Response.WriteAsync(responseText);
//     }
// }
//
//
// interface IHelloService
// {
//     string Message { get; }
// }
//
// class RuHelloService : IHelloService
// {
//     public string Message => "Привет мир!";
// }
//
// class EnHelloService : IHelloService
// {
//     public string Message => "Hello world!";
// }


// app.MapGet("{first}/{second}/{third}", async context =>
// {
//     await context.Response.WriteAsync("Hi \n");
//
//     foreach (var kvp in context.Request.RouteValues)
//     {
//         await context.Response.WriteAsync($"{kvp.Key}: {kvp.Value} \n");
//     }
// });
//
// // callback маршрут
// app.MapFallback(async context =>
// {
//     await context.Response.WriteAsync("Fallback endpoint");
// });


// Приоритеты
// app.Map("{number:int}", async context =>
//     {
//         await context.Response.WriteAsync("Routed to the int endpoint");
//     })
//     .Add(e => ((RouteEndpointBuilder)e).Order = 1);
//
// app.Map("{number:double}", async context =>
//     {
//         await context.Response.WriteAsync("Routed to the double endpoint");
//     })
//     .Add(e => ((RouteEndpointBuilder)e).Order = 2);





// Зависимости
// app.Map("/time", (TimeService timeService) => $"Time: {timeService.Time}");
//
// app.Run();
//
// public class TimeService
// {
//     public string Time => DateTime.Now.ToLongTimeString();
// }



//ограничения
// app.Map("/users/{id:int}", (int id) => $"User Id: {id}");
// app.Map("/users/{id:int:max(10)}", (int id) => $"User Id: {id}");
// app.Map("/users/{id:int:range(10,100)}", (int id) => $"User Id: {id}");
// app.Map("/users/{id:alpha}", (int id) => $"User Id: {id}");
// app.Map("/users/{id:required}", (int id) => $"User Id: {id}");
// app.Map("/users/{id:regex()}", (int id) => $"User Id: {id}");
// app.Map("/", () => "Index Page");
//
// app.Map("/users/{name:alpha:minlength(2)}/{age:int:range(1, 110)}", 
//     (string name, int age) => $"User Age: {age} \nUser Name: {name}");
//
// app.Map("/phonebook/{phone:regex(^0\\d{2}-\\d{3}-\\d{2}-\\d{2}$)}", 
//     (string phone) => $"Phone: {phone}");


// app.Map("/users/{id}", (string id) => $"User Id: {id}");
// app.Map("/users/{id}/{name}", (string id, string name) => $"User Id: {id}, {name}");
// app.Map("/users/{id}-{name}", (string id, string name) => $"User Id: {id}, {name}");
// app.Map("/users/{id}and{name}", (string id, string name) => $"User Id: {id}, {name}");
//
// app.Map("/users/{id?}", (string? id) => $"User Id: {id ?? "null"}");
//
//
// app.Map(
//     "{controller=Home}/action=Index/{id?}",
//     (string controller, string action, string? id) => $"{controller} {action} {id}"
// );
//
//
// app.Map("users/{**info}", (string info) => $"Users Info: {info}");



// app.Map("/routes", async (IEnumerable<EndpointDataSource> endpoints, HttpContext context) =>
// {
//     await context.Response.WriteAsync(string.Join("\n", endpoints.SelectMany(e => e.Endpoints)));
// });

// app.Run();