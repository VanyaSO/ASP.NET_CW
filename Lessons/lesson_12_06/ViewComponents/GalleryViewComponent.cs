using lesson_12_06.Models;
using Microsoft.AspNetCore.Mvc;

namespace lesson_12_06.ViewComponents;

public class GalleryViewComponent : ViewComponent
{
    List<Image> images = new List<Image>();
    public GalleryViewComponent()
    {
        images = Image.Gallery();
    }
 
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = images;
        return await Task.FromResult((IViewComponentResult)View("Gallery", model));
    }
}