using lesson_11_29.Models;

namespace lesson_11_29.ViewModels;

public class IndexViewModel
{
    public IEnumerable<Phone> Phones { get; set; }
    public IEnumerable<CompanyViewModel> Companies { get; set; }
    public int? SelectedCompanyId { get; set; }
}