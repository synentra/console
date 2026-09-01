using Blazored.LocalStorage;
using Console;
using Console.Preferences;
using Console.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IPreferenceManager, PreferenceManager>();
builder.Services.AddScoped<ConsoleState>();
builder.Services.AddScoped<SynentraApiClient>();

await builder.Build().RunAsync();
