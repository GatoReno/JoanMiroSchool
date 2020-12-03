using System;
using joanmiroschool.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace joanmiroschool
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
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
