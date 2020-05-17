using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SisVenda.UI.Auth;

namespace SisVenda.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(@"http://localhost:56673/api") });
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<TokenAuthenticationProvider>();
            builder.Services.AddScoped<IAuthorizeService, TokenAuthenticationProvider>(provider => provider.GetRequiredService<TokenAuthenticationProvider>());
            builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationProvider>(provider => provider.GetRequiredService<TokenAuthenticationProvider>());

            await builder.Build().RunAsync();
        }
    }
}
