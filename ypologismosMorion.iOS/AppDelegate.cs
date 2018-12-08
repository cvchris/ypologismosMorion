using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using MTiRate;

namespace ypologismosMorion.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        static AppDelegate()
        {
            iRate.SharedInstance.DaysUntilPrompt = 2;
            iRate.SharedInstance.UsesUntilPrompt = 3;
            iRate.SharedInstance.MessageTitle = "Αξιολογήστε την Εφαρμογή";
            iRate.SharedInstance.Message = "Εάν σας άρεσε η εφαρμογή και θέλετε να υποστηρίξετε την προσπάθεια, αξιολογήστε την εφαρμογή και πατήστε επάνω στις διαφημίσεις"; ;
            iRate.SharedInstance.CancelButtonLabel = "Όχι, ευχαριστώ";
            iRate.SharedInstance.RemindButtonLabel = "Υπενθύμιση αργότερα";
            iRate.SharedInstance.RateButtonLabel = "Κριτική Τώρα";

        }

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
