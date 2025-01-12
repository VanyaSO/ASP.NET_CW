namespace lesson_11_29.Models;

public class Phone
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Company Manufacturer { get; set; }
    public decimal Price { get; set; }
}