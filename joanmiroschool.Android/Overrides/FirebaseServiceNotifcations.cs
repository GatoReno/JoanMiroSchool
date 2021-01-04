using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Firebase.Messaging;
using WindowsAzure.Messaging;

namespace joanmiroschool.Droid.NotificationsOverrides
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseServiceNotifcations : FirebaseMessagingService
    {
        public FirebaseServiceNotifcations()
        {
        }
        public override void OnNewToken(string token)
        {
            SendRegistationToAzure(token);
            //base.OnNewToken(token);
        }

        private void SendRegistationToAzure(string token)
        {
            try
            {
                NotificationHub hub = new NotificationHub(
                "JMSNotificationHub"
                , "Endpoint=sb://jmsresourcesh.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=VFtnJKJoa+J6D/C5f7/DYllC1ONcgvk47OuwvHPmOMw="
                , this);

                Registration reg = hub.Register(token, new string[] { "default" });
                string pnsHamndle = reg.PNSHandle;
                hub.RegisterTemplate(pnsHamndle, "defaultTempalte",
               "{\"notification\":{\"title\":\"Notification Hub Test Notification\",\"body\":\"This is a sample notification delivered by Azure Notification Hubs.\"},\"data\":{\"property1\":\"value1\",\"property2\":\"42\"}}",
               new string[] { "default" });
            }
            catch (Exception ex)
            {

            }


        }

        public override void OnMessageReceived(RemoteMessage msn)
        {
            base.OnMessageReceived(msn);
            string msgBody = string.Empty;
            if (msn.GetNotification() != null)
            {
                msgBody = msn.GetNotification().Body;
            }
            else
            {
                msgBody = msn.Data.Values.First();
            }

            SendLocalNotification(msgBody);
            //(App.Current.MainPage as MainPage).
        }

        private void SendLocalNotification(string msgBody)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            intent.PutExtra("message", msgBody);

            var requestCode = new Random().Next();
            var pendingIntent = PendingIntent.GetActivity(this,
                requestCode, intent, PendingIntentFlags.OneShot);

            var notificationBulider = new NotificationCompat.Builder(this)
                .SetContentTitle("Joan Miro School")
                .SetSmallIcon(Resource.Drawable.ic_launcher)
                .SetContentText(msgBody)
                .SetShowWhen(false)
                .SetContentIntent(pendingIntent)
                ;
            var notificationManager = NotificationManager.FromContext(this);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel ch = new NotificationChannel(
                    "JMNotifyChannel",
                    "Joan Miro School",
                    NotificationImportance.High);
                notificationManager.CreateNotificationChannel(ch);
                notificationBulider.SetChannelId("XamarinNotifyChannel");
            }
            notificationManager.Notify(0, notificationBulider.Build());
        }
    }
}