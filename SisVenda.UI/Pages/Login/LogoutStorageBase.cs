using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SisVenda.UI.Auth;

namespace SisVenda.UI.Pages.Login
{
    public class LogoutBase : ComponentBase
    {
        [Inject] TokenAuthenticationProvider authStateProvider { get; set; }
        [Inject] NavigationManager navigation { get; set; }
        public async Task Logout()
        {
            await authStateProvider.Logout();
            navigation.NavigateTo("/");
        }
    }
}