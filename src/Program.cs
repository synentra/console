using Console;
using Console.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(
        "appsettings.json",
        optional: true,
        reloadOnChange: true)
    .AddJsonFile(
        $"appsettings.{builder.Environment.EnvironmentName}.json",
        optional: true,
        reloadOnChange: true)
    .AddUserSecrets<Program>(optional: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);

var customConfigPath = builder.Configuration["config"];

if (!string.IsNullOrEmpty(customConfigPath))
{
    builder.Configuration.Sources.Clear();

    builder.Configuration.AddJsonFile(
        customConfigPath,
        optional: false,
        reloadOnChange: false);
}

builder.ConfigureHttpServer();

builder.Services
    .AddConsoleServices()
    .AddMudBlazor();

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttps();

app.UseAntiforgery();

app.UseStaticFiles();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();