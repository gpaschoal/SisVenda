using Microsoft.AspNetCore.Components;

namespace SisVenda.UI.Pages
{
    public class AbstractComponentBase : ComponentBase
    {
        [Inject] public NavigationManager Navigation { get; set; }
    }
}