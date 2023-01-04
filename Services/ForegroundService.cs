using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using AndroidX.Core.App;
using AceMicEV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using AceMicEV.Models.Response;
using Kotlin.Contracts;
using AceMicEV.Views;

[assembly: Dependency(typeof(IForgroundService))]
namespace AceMicEV.Services
{
    [Service]
    public class ForegroundService : Service, IForgroundService
    {
        readonly INotificationRepository _notificationRepository = new NotificationServices();
        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        [return: GeneratedEnum]
        public  override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            string UserDid = Preferences.Get("DidKey", "Null");
            string Notitype = "payment";
            Task.Run(() =>
            {
                while(true)
                {
                    var NotificationInfo =  _notificationRepository.NotiData(UserDid, Notitype);

                    System.Diagnostics.Debug.WriteLine("get data from API");

                    if (NotificationInfo != null) 
                    {

                        AppShell.Current.DisplayAlert("Hello", "Hiii", "Cancel");
             //           System.Diagnostics.Debug.WriteLine("get data from API");

                        //  Shell.Current.GoToAsync($"../{nameof(WelcomeScreen)}");

                        //    StopMyForegroundService();

                    }

                    //System.Diagnostics.Debug.WriteLine("background process running");
                    Thread.Sleep(3000);
                }
            });

            string chennelID = "ForeGroundServiceChannel";
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O) 
            {
                var notificationchannel = new NotificationChannel(chennelID,chennelID,NotificationImportance.Low );
                notificationManager.CreateNotificationChannel(notificationchannel);
            }

            var notificationBuild = new NotificationCompat.Builder(this, chennelID)
                                    .SetContentTitle("BackgroundServiceStarted");

            StartForeground(1001, notificationBuild.Build());
            return base.OnStartCommand(intent, flags, startId);
        }

        public void StartMyForegroundService()
        {

            var intent = new Intent(Android.App.Application.Context, typeof(ForegroundService));
            Android.App.Application.Context.StartForegroundService(intent);
                
        }

        public void StopMyForegroundService()
        {
            var intent = new Intent(Android.App.Application.Context, typeof(ForegroundService));
            Android.App.Application.Context.StopService(intent);
           
        }
    }
}
