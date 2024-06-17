using Foundation;
using Plugin.Firebase.Core.Platforms.iOS;
using Plugin.Firebase.Crashlytics;
using UIKit;

namespace FirebaseExperiment.iOS;

[Register(nameof(AppDelegate))]
public class AppDelegate : MauiUIApplicationDelegate
{
    /// <inheritdoc/>
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    /// <inheritdoc/>
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        Console.WriteLine("AppDelegate#FinishedLaunching");
        //CrossFirebase.Initialize();
        try
        {
            CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
            CrossFirebaseCrashlytics.Current.Log("Sample log. Crashlytics is enabled.");
        }
        catch (Exception ex)
        {
            CrossFirebaseCrashlytics.Current.RecordException(ex);
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }

        // To send readable logs of fatal error, must use use an API that manually logs non-fatal errors
        // https://github.com/TobiasBuchholz/Plugin.Firebase/issues/291#issuecomment-2168581051
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

        return base.FinishedLaunching(application, launchOptions);
    }

    /// <summary>
    /// Event handler for TaskScheduler.UnobservedTaskException
    /// </summary>
    private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        CrossFirebaseCrashlytics.Current.Log("Sample log. TaskScheduler_UnobservedTaskException is called.");
        CrossFirebaseCrashlytics.Current.RecordException(e.Exception);
    }

    /// <summary>
    /// Event handler for AppDomain.CurrentDomain.UnhandledException
    /// </summary>
    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        CrossFirebaseCrashlytics.Current.Log("Sample log. CurrentDomain_UnhandledException is called.");
        CrossFirebaseCrashlytics.Current.Log($"{e.ExceptionObject?.ToString()}");
        CrossFirebaseCrashlytics.Current.RecordException(e.ExceptionObject as Exception);
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public override void OnActivated(UIApplication application)
    {
        Console.WriteLine("AppDelegate#OnActivated");
        base.OnActivated(application);
    }
}
