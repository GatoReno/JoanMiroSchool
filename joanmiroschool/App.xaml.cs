using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using joanmiroschool.Helpers;
using joanmiroschool.Services;
using joanmiroschool.View;
using Xamarin.Essentials;
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



            //Themes
            #region themes
            var prefTheme = Preferences.Get("Theme", string.Empty);
            if (string.IsNullOrEmpty(prefTheme))
            {

            }
            else
            {
                if (prefTheme == "Dark")
                {
                    Application.Current.UserAppTheme = OSAppTheme.Dark;
                }
                else if (prefTheme == "Light")
                {
                    Application.Current.UserAppTheme = OSAppTheme.Light;
                }
            }
            #endregion

           

            #region auth
            //authentification 
            //bool au = FirebaseAuthService.IsAuthenticated();
            //if (!au)
            //{
            //    MainPage = new LoginPage();
            //}
            //else
            //{
            //    MainPage = new MainPage();
            //}
            MainPage = new LottiePage();
            #endregion 

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
