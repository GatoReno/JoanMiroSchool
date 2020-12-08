using System;
using System.Collections.Generic;
using joanmiroschool.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace joanmiroschool.View.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        void TapGestureRecognizer_Tapped_Profile(System.Object sender, System.EventArgs e)
        {
            App.MasterD.IsPresented = false;
        }

        void TapGestureRecognizer_Tapped_LogOut(System.Object sender, System.EventArgs e)
        {
            App.MasterD.IsPresented = false;
            FirebaseAuthService.LogOut();
            Application.Current.MainPage = new LoginPage();
        }
    }
}
