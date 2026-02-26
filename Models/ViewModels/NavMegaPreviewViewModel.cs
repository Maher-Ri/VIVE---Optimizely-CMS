// Models/ViewModels/NavMegaPreviewViewModel.cs
using EPiServer.Core;

namespace VIVEcms.Models.ViewModels
{
    public class NavMegaPreviewViewModel
    {
        public ContentReference? PreviewImage { get; set; }
        public string? Url { get; set; }
        public string? Label { get; set; }
    }
}
