// Models/ViewModels/NavItemViewModel.cs
namespace VIVEcms.Models.ViewModels
{
    public class NavItemViewModel
    {
        public string? Label { get; set; }
        public string? Url { get; set; }
        public bool HasMegaMenu { get; set; }

        // Dropdown sub-items
        public List<NavSubItemViewModel> SubItems { get; set; } = new();

        // Mega menu preview images
        public List<NavMegaPreviewViewModel> MegaMenuPreviews { get; set; } = new();
    }
}