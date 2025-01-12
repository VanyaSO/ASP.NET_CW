namespace lesson_12_06.Models;

public class Image
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
 
    public static List<Image> Gallery()
    {
        return new List<Image>()
        {
            new Image() {Title = "Склад", Description = "Описание картинки", FilePath = "/images/sklad.jpg"},
            new Image() {Title = "Склад", Description = "Описание картинки", FilePath = "/images/sklad.jpg"},
            new Image() {Title = "Склад", Description = "Описание картинки", FilePath = "/images/sklad.jpg"},
            new Image() {Title = "Склад", Description = "Описание картинки", FilePath = "/images/sklad.jpg"},
            new Image() {Title = "Склад", Description = "Описание картинки", FilePath = "/images/sklad.jpg"}
        };
    }
}