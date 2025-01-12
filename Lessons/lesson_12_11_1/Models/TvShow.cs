namespace lesson_12_11_1.Models;

public class TvShow
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string ImdbUrl { get; set; }
    public Genre Genre { get; set; }
    public string? Poster { get; set; }
}