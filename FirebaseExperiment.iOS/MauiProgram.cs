using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Core.Platforms.iOS;

namespace FirebaseExperiment.iOS;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		return MauiApp.CreateBuilder()
			.UseSharedMauiApp()
            .RegisterFirebaseServices()
            .Build();
	}

    /// <summary>
    /// refer to https://github.com/TobiasBuchholz/Plugin.Firebase
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddiOS(iOS => iOS.WillFinishLaunching((_, __) =>
            {
                CrossFirebase.Initialize();
                return false;
            }));
        });

        builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
        return builder;
    }
}
