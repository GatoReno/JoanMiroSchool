using System;
using Acr.UserDialogs;
using joanmiroschool.Services;
using joanmiroschool.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace joanmiroschool
{
    public partial class App : Application
    {

        public static MasterDetailPage MasterD { get; set; }
        public App()
        {
            InitializeComponent();
            

            UserDialogs.Instance.ShowLoading();
            bool au = FirebaseAuthService.IsAuthenticated();
            if (!au)
            {
                MainPage = new LoginPage();
            }
            else {
                MainPage = new MainPage();
            }
            UserDialogs.Instance.HideLoading();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
