using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace SisVenda.UI.Utils
{
    public static class IJSRuntimeExtensions
    {
        private static readonly string Storage = "sessionStorage";
        public static ValueTask<object> SetInSessionStorage(this IJSRuntime js, string key, string content)
             => js.InvokeAsync<object>($"{Storage}.setItem", key, content);

        public static ValueTask<string> GetFromSessionStorage(this IJSRuntime js, string key) 
            => js.InvokeAsync<string>($"{Storage}.getItem", key);

        public static ValueTask<object> RemoveFromSessionStorage(this IJSRuntime js, string key) 
            => js.InvokeAsync<object>($"{Storage}.removeItem", key);
    }
}