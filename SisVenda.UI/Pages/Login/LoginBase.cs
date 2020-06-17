using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.Requests;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.Login
{
    public class LoginBase : AbstractComponentBase
    {
        public UsersLoginCommand loginCommand;
        [Inject] public LoginRequest Request { get; set; }
        public LoginBase()
        {
            loginCommand = new UsersLoginCommand() { Username = "admin", Password = "123" };
        }
        public async Task Logar()
        {
            (bool result, _) = await Request.Login(loginCommand);

            if (result) Navigation.NavigateTo("/");
            else {/*  */}
        }
    }
}