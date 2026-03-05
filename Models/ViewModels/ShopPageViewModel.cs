// Models/ViewModels/ShopPageViewModel.cs
using System.Collections.Generic;
using VIVEcms.Models.Pages;

namespace VIVEcms.Models.ViewModels
{
    public class ShopPageViewModel(ShopPage currentPage) : PageViewModel<ShopPage>(currentPage)
    {
        public List<SingleProductPage> Products { get; set; } = new();
    }
}
