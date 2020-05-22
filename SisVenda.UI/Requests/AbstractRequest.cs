using Microsoft.AspNetCore.Components;
using System.Net.Http;

namespace SisVenda.UI.Requests
{
    public abstract class AbstractRequest : ComponentBase
    {
        [Inject] public HttpClient http { get; set; }
        protected AbstractRequest(HttpClient http)
        {
            this.http = http;
        }
    }
}