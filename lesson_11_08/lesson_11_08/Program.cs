using System.Reflection;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

// app.UseDirectoryBrowser(new DirectoryBrowserOptions
// {
//     FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "@wwwroot\"\"\\html")),
//     RequestPath = new PathString("/pages")
// });

// app.UseDefaultFiles();
// app.UseStaticFiles();




// SqlCommand command = new SqlCommand($"insert into [Users] ([Name], [Age]) values ('{name}', {age})", connection);
// command.ExecuteNonQuery();





var configurationService = app.Services.GetService<IConfiguration>();
string connectionString = configurationService["ConnectionStrings:DefaultConnection"];

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    response.ContentType = "text/html; charset=utf-8";
 
    //При переходе на главную страницу, считываем всех пользователей
    if (request.Path == "/")
    {
        List<User> users = new List<User>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand("select Id, Name, Age from UsersMy", connection);
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        users.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    }
                }
            }
        }
        await response.WriteAsync(GenerateHtmlPage(BuildHtmlTable(users), "All Users from DataBase"));
    }
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync("Page Not Found");
    }
});

app.Run();

static string BuildHtmlTable<T>(IEnumerable<T> collection)
{
    StringBuilder tableHtml = new StringBuilder();
    tableHtml.Append("<table class=\"table\">");
 
    PropertyInfo[] properties = typeof(T).GetProperties();
 
    tableHtml.Append("<tr>");
    foreach (PropertyInfo property in properties)
    {
        tableHtml.Append($"<th>{property.Name}</th>");
    }
    tableHtml.Append("</tr>");
 
    foreach (T item in collection)
    {
        tableHtml.Append("<tr>");
        foreach (PropertyInfo property in properties)
        {
            object value = property.GetValue(item);
            tableHtml.Append($"<td>{value}</td>");
        }

        tableHtml.Append($"<td></td>");
        tableHtml.Append("</tr>");
    }
 
    tableHtml.Append("</table>");
    return tableHtml.ToString();
}

 
static string GenerateHtmlPage(string body, string header)
{
    string html = $"""
       <!DOCTYPE html>
       <html>
       <head>
           <meta charset="utf-8" />
           <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" 
           integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
           <title>{header}</title>
       </head>
       <body>
       <div class="container">
       <h2 class="d-flex justify-content-center">{header}</h2>
       <div class="mt-5"></div>
                {body}
           <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js" 
           integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe" crossorigin="anonymous"></script>
       </div>
       </body>
       </html>
       """;
    return html;
}


record User(int Id, string Name, int Age)
{
    public User(string Name, int Age) : this(0, Name, Age)
    {
        
    }
}




// app.Run(async (context) =>
// {
//     var response = context.Response;
//     var request = context.Request;
//     // путь к папке, где будут храниться файлы
//     var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";
//  
//  
//     response.ContentType = "text/html; charset=utf-8";
//  
//     if (request.Path == "/upload" && request.Method == "POST")
//     {
//         IFormFileCollection files = request.Form.Files;
//         // если такой папки нет, то создаем ее
//         if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
//  
//         foreach (var file in files)
//         {
//             // путь к папке uploads
//             string fullPath = $"{uploadPath}/{file.FileName}";
//  
//             // сохраняем файл в папку uploads
//             using (var fileStream = new FileStream(fullPath, FileMode.Create))
//             {
//                 await file.CopyToAsync(fileStream);
//             }
//         }
//         await response.WriteAsync("Файлы успешно загружены");
//     }
//     else if (request.Path == "/getFile")
//     {
//         string fileName = request.Query["fileName"];
//         string fullFileName = $"{uploadPath}/{fileName}";
//         if (File.Exists(fullFileName))
//         {
//             response.ContentType = "application/octet-stream";
//             await context.Response.SendFileAsync(fullFileName);
//         }
//         else
//         {
//             response.StatusCode = 404;
//             await context.Response.WriteAsJsonAsync("File Not Found");
//         }
//     }
//     else
//     {
//         await response.SendFileAsync("html/index.html");
//     }
// });












//context.Response.ContentType = "image/jpeg";
//context.Response.Headers.ContentDisposition = "attachment; filename=" + fileName;
//context.Response.ContentType = "application/octet-stream";

// app.Run(async (context) =>
// {
//     var response = context.Response;
//     var request = context.Request;
//  
//     response.ContentType = "text/html; charset=utf-8";
//  
//     if (request.Path == "/upload" && request.Method == "POST")
//     {
//         IFormFileCollection files = request.Form.Files;
//         // путь к папке, где будут храниться файлы
//         var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";
//         // если такой папки нет, то создаем ее
//         if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
//  
//         foreach (var file in files)
//         {
//             // путь к папке uploads
//             string fullPath = $"{uploadPath}/{file.FileName}";
//  
//             // сохраняем файл в папку uploads
//             using (var fileStream = new FileStream(fullPath, FileMode.Create))
//             {
//                 await file.CopyToAsync(fileStream);
//             }
//         }
//         await response.WriteAsync("Файлы успешно загружены");
//     }
//     else
//     {
//         await response.SendFileAsync("index.html");
//     }
// });


