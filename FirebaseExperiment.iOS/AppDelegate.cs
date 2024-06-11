using Foundation;
using Plugin.Firebase.Core.Platforms.iOS;
using Plugin.Firebase.Crashlytics;
using UIKit;

namespace FirebaseExperiment.iOS;

[Register(nameof(AppDelegate))]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        Console.WriteLine("AppDelegate#FinishedLaunching");
        // I confirmed isSupported to be true.
        var isSupported = CrossFirebaseCrashlytics.IsSupported;
        CrossFirebase.Initialize();
        // When the following method is called, the app crashes.
        CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
        return base.FinishedLaunching(application, launchOptions);
    }

    public override bool WillFinishLaunching(UIApplication application, NSDictionary launchOptions)
    {
        return base.WillFinishLaunching(application, launchOptions);
    }

    public override void OnActivated(UIApplication application)
    {
        Console.WriteLine("AppDelegate#OnActivated");
        //var isSupported = CrossFirebaseCrashlytics.IsSupported;
        //CrossFirebase.Initialize();
        //CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
        base.OnActivated(application);
    }
}
