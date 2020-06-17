using Microsoft.AspNetCore.Components;
using System.Net.Http;

namespace SisVenda.UI.Requests
{
    public abstract class AbstractRequest : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; }
        protected AbstractRequest(HttpClient http) { Http = http; }
    }
}