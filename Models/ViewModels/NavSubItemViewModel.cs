// Models/ViewModels/NavSubItemViewModel.cs
namespace VIVEcms.Models.ViewModels
{
    public class NavSubItemViewModel
    {
        public string? Label { get; set; }
        public string? Url { get; set; }

        // 3rd level sub-items (e.g: Shop → Shop Layouts → Shop 3 Columns)
        public List<NavSubItemViewModel> SubSubItems { get; set; } = new();
    }
}
