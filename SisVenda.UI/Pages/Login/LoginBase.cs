using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SisVenda.UI.Auth;
using SisVenda.UI.CQRS.Commands;

namespace SisVenda.UI.Pages.Login
{
    public class LoginBase : ComponentBase
    {
        [Inject] HttpClient http { get; set; }
        [Inject] TokenAuthenticationProvider authStateProvider { get; set; }
        [Inject] NavigationManager navigation { get; set; }
        public LoginUsersCommand loginCommand;
        public LoginBase()
        {
            loginCommand = new LoginUsersCommand();
        }
        public async Task Logar()
        {
            string loginAsJson = JsonSerializer.Serialize(loginCommand);
            HttpResponseMessage httpResponse = await http.PostAsync("api/login/login", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            if (httpResponse.IsSuccessStatusCode)
            {
                string responseAsString = await httpResponse.Content.ReadAsStringAsync();
                CQRS.Responses.LoginResponse loginResult = JsonSerializer.Deserialize<CQRS.Responses.LoginResponse>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                await authStateProvider.Login(loginResult.Token);
                navigation.NavigateTo("/");
            }
        }
    }
}