using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Foundation;
using Lottie.Forms.iOS.Renderers;
using UIKit;
using UserNotifications;
using WindowsAzure.Messaging;

namespace joanmiroschool.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
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

            Firebase.Core.App.Configure();
            AnimationViewRenderer.Init();
            LoadApplication(new App());

            bool result = base.FinishedLaunching(app, options);

            RegisteredForRemoteNotifications();

            return result;
        }

        private void RegisteredForRemoteNotifications()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                UNUserNotificationCenter.Current.RequestAuthorization
                    (
                        UNAuthorizationOptions.Alert |
                        UNAuthorizationOptions.Badge |
                        UNAuthorizationOptions.Sound,
                        (granted, err) =>
                        {
                            InvokeOnMainThread(UIApplication.SharedApplication.RegisterForRemoteNotifications);
                        }
                    );
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var pushSetting = UIUserNotificationSettings.GetSettingsForTypes(
                    UIUserNotificationType.Alert | UIUserNotificationType.Badge |
                    UIUserNotificationType.Sound, new NSSet()
                    );
                UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSetting);
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else
            {
                UIRemoteNotificationType notificationType =  
                    UIRemoteNotificationType.Alert |
                    UIRemoteNotificationType.Sound |
                    UIRemoteNotificationType.Badge;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationType);
            }
        }

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            //base.RegisteredForRemoteNotifications(application, deviceToken);
            var hub = new SBNotificationHub(
                "Endpoint=sb://jmsresourcesh.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=VFtnJKJoa+J6D/C5f7/DYllC1ONcgvk47OuwvHPmOMw=",
                "JMSNotificationHub");
            hub.UnregisterAll(deviceToken,(err)=>
            {
                if (err != null)
                {
                    return;
                }

                var tags = new NSSet((new string[] { "default" }).ToArray());
                hub.RegisterNative(deviceToken, tags,
                    (err2) =>
                    {
                        Debug.WriteLine($"{err2}");
                    });


                var tempoExp = DateTime.Now.AddDays(100).
                    ToString(System.Globalization.CultureInfo.
                    CreateSpecificCulture("en-US"));


                hub.RegisterTemplate(deviceToken, "defaultTemplate",
                    "{\"aps\":{\"alert\":\"Notification Hub test notification\"}}",
                    tempoExp, tags,
                    (err3) =>
                    {
                        Debug.WriteLine($"{err3}");
                    });
            });

        }

        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            ProcessNotification(userInfo);
        }

        private void ProcessNotification(NSDictionary options)
        {
            if (options != null && options.ContainsKey(new NSString("aps")))
            {
                NSDictionary aps = options.ObjectForKey(new NSString("aps")) as NSDictionary;
                string pl = string.Empty;
                if (aps.ContainsKey(new NSString("alert")))
                {
                    pl = aps[new NSString("alert")].ToString();
                }
                if (!string.IsNullOrEmpty(pl))
                {
                    // (App.Current.MainPage as MainPage)
                }
            }
            else
            {
                Debug.WriteLine($"{options}");
            }
        }
    }
}
