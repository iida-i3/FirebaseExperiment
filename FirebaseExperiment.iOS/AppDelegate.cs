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
        CrossFirebase.Initialize();
        try
        {
            CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        return base.FinishedLaunching(application, launchOptions);
    }

    public override bool WillFinishLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // WillFinishLaunching is really the right way to handle below codes.
        //CrossFirebase.Initialize();
        //try
        //{
        //    CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    Console.WriteLine(ex.StackTrace);
        //}
        return base.WillFinishLaunching(application, launchOptions);
    }

    public override void OnActivated(UIApplication application)
    {
        Console.WriteLine("AppDelegate#OnActivated");
        base.OnActivated(application);
    }
}
