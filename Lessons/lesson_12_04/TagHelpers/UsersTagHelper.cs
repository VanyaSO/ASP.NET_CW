using System.Text;
using lesson_12_04.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace lesson_12_04.TagHelpers;

public class UsersTagHelper : TagHelper
{
    public List<User> Users { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";

        StringBuilder builder = new StringBuilder();
        foreach (var user in Users)
        {
            builder.Append($"<div>{user.Name} {user.Age}</div>");
        }
        
        output.Content.SetHtmlContent(builder.ToString());
    }
}


//
// public class TimerTagHelper : TagHelper
// {
//     public bool SecondsIncluded { get; set; }
//     public string Color { get; set; }
//     public override void Process(TagHelperContext context, TagHelperOutput output)
//     {
//         var now = DateTime.Now;
//         var time = String.Empty;
//         if (SecondsIncluded)    // если true добавляем секунды
//             time = now.ToString("HH:mm:ss");
//         else
//             time = now.ToString("HH:mm");
//  
//         output.TagName = "div";
//         output.TagMode = TagMode.StartTagAndEndTag;
//         // устанавливаем цвет
//         output.Attributes.SetAttribute("style", $"color:{Color};");
//  
//         output.Content.SetContent(time);
//     }
// }