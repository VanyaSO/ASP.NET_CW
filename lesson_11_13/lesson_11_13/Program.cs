using System.Text.Json;
using lesson_11_13.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Реализовать веб-приложение, которое будет обрабатывать каждый HTTP и HTTPS-запрос, переданный ему, и анализировать его содержимое, чтобы проверить,
// является ли запрос допустимым. Если запрос допустим, приложение должно вызывать соответствующий обработчик,
// который выполнит нужные действия в зависимости от запроса. Если запрос недопустим, приложение должно вернуть соответствующий HTTP-код состояния и
// сообщение об ошибке.
//     Запрос допустим если он:
//  
// 1) Имеет тип GET или POST.
// 2) Если запрос типа GET, просто возвращаем приветствие в виде строки – «Welcome to Person API!».
// 3) Если запрос типа POST, то имеет содержимое типа - application/json.
// 4) Если запрос типа POST и имеет содержимое типа - application/json. Проверьте, является ли тело запроса действительным JSON (используя десериализацию объекта). 
//  
// Сама программа ожидает объект на основе класса:
//  
// record Person(string name, int age);
//  
// Именно в него выполнять десериализацию.
//  
//     Для отправки POST запроса, можно использовать HTML клиента с формой, PowerShell или Fiddler.

app.Run(async (context) =>
{
    if (context.Request.Method == HttpMethods.Get)
    {
        await context.Response.WriteAsync("Welcome to Person API!");
    }  
    else if (context.Request.Method == HttpMethods.Post && context.Request.ContentType == "application/json")
    {
        using (var reader = new StreamReader(context.Request.Body))
        {
            var body = await reader.ReadToEndAsync();
            Person? person = JsonSerializer.Deserialize<Person>(body);

            if (person != null)
            {
                await context.Response.WriteAsync("Запрос обработан");
            }
        }
    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Ошибка");
    }
});



// Создать веб-приложение на Asp.Net Core, которое будет использовать middleware для обработки HTTP запросов.
// Веб-приложение должно использовать middleware для логирования запросов,
// добавления заголовков ответов и обработки ошибок (для каждого действия – свой метод Use).

app.Use(async (context, next) =>
{
    Console.WriteLine($"Получени запрос {context.Request.Path}, {context.Request.Method},  {DateTime.Now.ToLongDateString()}");
    await next.Invoke();
});
//
// app.Use(async (context, next) =>
// {
//     await next.Invoke();
//     context.Response.Headers["Content-Language"] = "ru";
// });
//
// app.Use(async (context, next) =>
// {
//     try
//     {
//         await next.Invoke();
//     }
//     catch (Exception e)
//     {
//         Console.WriteLine($"Ошибка: {e.Message}");
//         context.Response.StatusCode = 500;
//         await context.Response.WriteAsync("Ошибка сервера !!!");
//     }
// });
//
// app.Run(async (context) =>
// {
//     await context.Response.WriteAsync("Добро пожаловать");
// });


// app.UseToken("12345678");


// после выполнения не выходит в первоначальный пайп лайн
// app.MapWhen(context => context.Request.Path == "/time2",
//     appBuilder => // Действия при выполнении условия
//     {
//         var time = DateTime.Now.ToShortTimeString(); // Получаем текущее время в коротком формате
//
//         // Обработка ответа
//         appBuilder.Run(async context =>
//         {
//             await context.Response.WriteAsync($"Time: {time}"); // Отправляем время в ответ
//         });
//     });

// после выполнения выходит в первоначальный пайп лайн
// app.UseWhen(
//     context => context.Request.Path == "/time", // Условие: если путь запроса "/time"
     // appBuilder => // Действия при выполнении условия
     // {
     //     var time = DateTime.Now.ToShortTimeString(); // Получаем текущее время в коротком формате
     //
     //     // Логирование данных - выводим время в консоль приложения
     //     appBuilder.Use(async (context, next) =>
     //     {
     //         Console.WriteLine($"Time: {time}"); // Вывод времени в консоль
     //         await next(); // Вызов следующего middleware
     //     });
     //
     //     // Обработка ответа
     //     appBuilder.Run(async context =>
     //     {
     //         await context.Response.WriteAsync($"Time: {time}"); // Отправляем время в ответ
     //     });
     // }
// );



string date = "";
app.Use(GetDate);

app.Run(async (context) => await context.Response.WriteAsync(date));

app.Run();

async Task GetDate(HttpContext context, Func<Task> next)
{
    string? path = context.Request.Path.Value.ToLower();

    if (path == "/date")
    {
        await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
    }
    else
    {
        await next.Invoke();
    }
}

record Person(string Name, int Age);
