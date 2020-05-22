using Microsoft.AspNetCore.Components;
using SisVenda.UI.Auth;
using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Responses;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SisVenda.UI.Requests
{
    public class LoginRequest : AbstractRequest
    {
        [Inject] public TokenAuthenticationProvider authStateProvider { get; set; }
        public LoginRequest(HttpClient http, TokenAuthenticationProvider authStateProvider) : base(http)
        {
            this.authStateProvider = authStateProvider;
        }

        public async Task<(bool, string)> Login(LoginUsersCommand loginCommand)
        {
            string loginAsJson = JsonSerializer.Serialize(loginCommand);
            HttpResponseMessage httpResponse = await http.PostAsync("api/login/login", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            if (httpResponse.IsSuccessStatusCode)
            {
                string responseAsString = await httpResponse.Content.ReadAsStringAsync();
                LoginResponse loginResult = JsonSerializer.Deserialize<LoginResponse>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                await authStateProvider.Login(loginResult.Token);
                return (true, "Logado com sucesso!");
            }

            return (false, "Ops, houve algum erro com o acesso! :C");
        }
    }
}