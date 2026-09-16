using Blazored.LocalStorage;
using Console.Preferences;
using Console.Services;
using Console.Settings;
using MudBlazor;
using MudBlazor.Services;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConsoleServices(this IServiceCollection services)
    {
        services.AddServerSideBlazor();
        services
            .AddBlazoredLocalStorage()
            .AddScoped<IPreferenceManager, PreferenceManager>()
            .AddScoped<ConsoleState>()
            .AddScoped<SynentraApiClient>()
            .AddHttpClient()
            .AddHttpContextAccessor();

        return services;
    }

    public static IServiceCollection AddMudBlazor(this IServiceCollection services) =>
        services.AddMudServices(ConfigureMudSnackbar);

    #region Private Helpers

    private static void ConfigureMudSnackbar(MudServicesConfiguration config)
    {
        var snackbar = config.SnackbarConfiguration;
        snackbar.PositionClass = Defaults.Classes.Position.BottomRight;
        snackbar.HideTransitionDuration = 500;
        snackbar.ShowTransitionDuration = 500;
        snackbar.VisibleStateDuration = 10000;
        snackbar.PreventDuplicates = false;
        snackbar.NewestOnTop = false;
        snackbar.ShowCloseIcon = true;
        snackbar.SnackbarVariant = Variant.Filled;
    }

    #endregion
}