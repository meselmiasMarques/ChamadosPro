using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ChamadosPro.Web;
using ChamadosPro.Web.Services;
using MudBlazor.Services;
using System.Text.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Carrega o appsettings.json da wwwroot
var tempHttp = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
var configJson = await tempHttp.GetStringAsync("appsettings.json");

using var doc = JsonDocument.Parse(configJson);
var apiUrl = doc.RootElement.GetProperty("APIServer").GetProperty("Url").GetString();

// Configura o HttpClient nomeado "API"
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri(apiUrl!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Injeção do HttpClient padrão
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("API"));

builder.Services.AddMudServices();

// Serviços customizados
builder.Services.AddScoped<UsuarioService>();

await builder.Build().RunAsync();