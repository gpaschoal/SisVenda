using System.Net.Http;
using Microsoft.AspNetCore.Components;
using SisVenda.UI.Auth;

namespace SisVenda.UI.Requests
{
    public abstract class AbstractRequest : ComponentBase
    {
        [Inject] public HttpClient http { get; set; }
        [Inject] public TokenAuthenticationProvider authStateProvider { get; set; }
        protected AbstractRequest(HttpClient http, TokenAuthenticationProvider authStateProvider)
        {
            this.http = http;
            this.authStateProvider = authStateProvider;
        }
    }
}