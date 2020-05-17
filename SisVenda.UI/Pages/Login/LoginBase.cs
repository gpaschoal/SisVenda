using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.Requests;

namespace SisVenda.UI.Pages.Login
{
    public class LoginBase : AbstractComponentBase
    {
        public LoginUsersCommand loginCommand;
        [Inject] public LoginRequest loginRequest { get; set; }
        public LoginBase()
        {
            loginCommand = new LoginUsersCommand() { Username = "admin", Password = "123" };
        }
        public async Task Logar()
        {
            (bool result, string message) = await loginRequest.Login(loginCommand);

            if (result) navigation.NavigateTo("/");
            else {/*  */}
        }
    }
}