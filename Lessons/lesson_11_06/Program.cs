var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
app.UseDefaultFiles();

List<Person> people = new List<Person>()
{
    new Person("Іван", 30, "вул. Шевченка, 10", "+380 67 123 45 67"),
    new Person("Марія", 25, "вул. Франка, 15", "+380 50 234 56 78"),
    new Person("Олексій",  40, "вул. Лесі Українки, 22", "+380 63 345 67 89"),
    new Person("Ольга", 28, "вул. Грушевського, 5", "+380 96 456 78 90"),
    new Person("Дмитро", 35, "вул. Сагайдачного, 12", "+380 93 567 89 01")
};

app.Run(async (context) =>
{

    // Создать собственный терминальный компонент, используя метод Run.
    // Определить класс Person, содержащий 5 свойств.
    // Создать коллекцию объектов класса.
    // Вернуть коллекцию объектов в виде Json.
    
    if (context.Request.Path.StartsWithSegments("/api/length"))
    {
        var str = context.Request.Path.Value.Split('/').Last();
        
        await context.Response.WriteAsync($"{str.Length}");
    }

});

app.Run();

public class Person
{
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public int Age { get; set; }            
    public string Address { get; set; }      
    public string PhoneNumber { get; set; }

    public Person(string name, int age, string address, string phoneNumber)
    {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;
        Address = address;
        PhoneNumber = phoneNumber;
    }
};



// app.Run(async (context) =>
// {
//     context.Response.ContentType = "text/html; charset=utf-8";
//  
//     // если обращение идет по адресу "/postuser", получаем данные формы
//     if (context.Request.Path == "/postuser")
//     {
//         var form = context.Request.Form;
//         string name = form["name"];
//         string age = form["age"];
//         await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div>");
//     }
//     else
//     {
//         await context.Response.SendFileAsync("index.html");
//     }
// });



// context.Response.ContentType = "text/html; charset=utf-8";
    // if (context.Request.Path == "/")
    // {
    //     await context.Response.SendFileAsync("wwwroot/index.html");
    // }
// else if (context.Request.Path == "/uploadimage" && context.Request.Method == "POST")
// {
//     IFormFile file = context.Request.Form.Files.GetFile("file");
//     if (file != null && file.Length > 0)
//     {
//         var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", file.FileName);
//         using (var stream = new FileStream(filePath, FileMode.Create))
//         {
//             await file.CopyToAsync(stream);
//         }
//         await context.Response.WriteAsync($"File {file.FileName} uploaded successfully!");
//     }
//     else
//     {
//         context.Response.StatusCode = 400;
//         await context.Response.WriteAsync("No file uploaded.");
//     }
// }



// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
//
// app.UseStaticFiles();
// app.UseDefaultFiles();
//
// List<Person> people = new List<Person>()
// {
//     new Person("Tom", 30),
//     new Person("Kate", 19)
// };
//  
// app.Run(async (context) =>
// {
//     var path = context.Request.Path.ToString();
//     var response = context.Response;
//     var request = context.Request;
//  
//     switch (path.ToLower())
//     {
//         case "/": { await response.WriteAsync("Welcome to Users API"); break; }
//         case "/adduser":
//         {
//             string? name = request.Query["name"];
//             int age = 0;
//             if (!int.TryParse(request.Query["age"], out age))
//             {
//                 await response.WriteAsJsonAsync("Not valid age");
//             }
//             var user = new Person(name, age);
//             people.Add(user);
//             await response.WriteAsJsonAsync(user);
//             break;
//         }
//         case "/getuser":
//         {
//             await response.WriteAsJsonAsync(people.FirstOrDefault(e => e.Id == request.Query["id"]));
//             break;
//         }
//         case "/removeuser":
//         {
//             var user = people.FirstOrDefault(e => e.Id.ToString() == request.Query["id"]);
//             if (user != null)
//             {
//                 people.Remove(user);
//             }
//             await response.WriteAsJsonAsync(user);
//             break;
//         }
//         case "/allusers": { await response.WriteAsJsonAsync(people); break; }
//         default: { await response.WriteAsJsonAsync("Not found"); break; }
//     }
// });
//  
// app.UseDeveloperExceptionPage();
//
// app.Run();
//  
// class Person
// {
//     public Guid Id { get; set; } = Guid.NewGuid();
//     public string Name { get; set; }
//     public int Age { get; set; }
//  
//     public Person(string name, int age)
//     {
//         Name = name;
//         Age = age;
//     }
// }













///////

// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
//
// // app.UseWelcomePage(); // пайп лайн(конвеер)
// app.UseStaticFiles();
//
// // Middleware - миддлвере - 
// // конвеер запросов
// // промежуточное ПО
// // сервисы
// //DI / IOC
//
//
// // терминальный компонент значит что зайдет и с него не выйдет
// app.Run(async (context) =>
// {
//     string name = context.Request.Query["name"];
//     string age = context.Request.Query["age"];
//     await context.Response.WriteAsync($"{name} - {age}");
//     
//     
//     
//     // context.Response.ContentType = "text/html; charset=utf-8";
//     // var stringBuilder = new System.Text.StringBuilder("<h3>Параметры строки запроса</h3><table>");
//     // stringBuilder.Append("<tr><td>Параметр</td><td>Значение</td></tr>");
//     // foreach (var param in context.Request.Query)
//     // {
//     //     stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
//     // }
//     // stringBuilder.Append("</table>");
//     // await context.Response.WriteAsync(stringBuilder.ToString());
// });
//
//
//
//
// app.Run();
//
