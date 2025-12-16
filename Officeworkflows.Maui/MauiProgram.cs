using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Microsoft.AspNetCore.Components.WebView.Maui;

// ✅ Syncfusion imports
using Syncfusion.Blazor;
using Syncfusion.Maui.Core.Hosting;

// ✅ Services
using Officeworkflows.Maui.Services;
using static Officeworkflows.Maui.Services.AuthService;

namespace Officeworkflows.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit(options =>
                {
                    options.SetShouldEnableSnackbarOnWindows(true);
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                // ✅ REQUIRED FOR SYNCFUSION MAUI
                .ConfigureSyncfusionCore();

            // ✅ MAUI Blazor WebView support
            builder.Services.AddMauiBlazorWebView();

            // ✅ Register Syncfusion Blazor services (REQUIRED)
            builder.Services.AddSyncfusionBlazor();

            // ✅ Register HttpClient (used in AuthService)
            builder.Services.AddScoped(sp => new HttpClient
            {

                BaseAddress = new Uri("https://10.0.2.2:7162")  // Android emulator can't use localhost

                //BaseAddress = new Uri("https://localhost:7162")

            });

            // ✅ Register application services
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<HolidayService>();
            builder.Services.AddSingleton<LeaveService>();

            System.Object value = builder.Services.AddSingleton<SecureStorageService>();

            // ✅ Syncfusion license key
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
                "Ngo9BigBOggjHTQxAR8/V1JEaF5cXmRCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXhccXRdQ2NYWENzWkRWYEk="
            );


            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
            builder.Services.AddMauiBlazorWebView();


            return builder.Build();
        }
    }
}
