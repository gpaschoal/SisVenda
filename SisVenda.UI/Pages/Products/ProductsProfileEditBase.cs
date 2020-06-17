using Microsoft.AspNetCore.Components;

namespace SisVenda.UI.Pages.Products
{
    public class ProductsProfileEditBase : AbstractComponentBase
    {
        [Parameter] public string ProductsProfileId { get; set; }
    }
}
