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
            AccountIcon.Source = ImageSource.FromResource("joanmiroschool.Images.icons.usericon_w.png");
            LogoutIcon.Source = ImageSource.FromResource("joanmiroschool.Images.icons.logouticon.png");
            StatementsIcon.Source = ImageSource.FromResource("joanmiroschool.Images.icons.statementicon_w.png");
            ConfigIcon.Source = ImageSource.FromResource("joanmiroschool.Images.icons.gearicon_w.png");
        }

        void TapGestureRecognizer_Tapped_Profile(System.Object sender, System.EventArgs e)
        {
            App.MasterD.IsPresented = false;
            App.MasterD.Detail.Navigation.PushAsync(new ProfilePage());
        }

        void TapGestureRecognizer_Tapped_Config(System.Object sender, System.EventArgs e)
        {
            App.MasterD.IsPresented = false;
            App.MasterD.Detail.Navigation.PushAsync(new ConfigPage());
            
        }

        void TapGestureRecognizer_Tapped_LogOut(System.Object sender, System.EventArgs e)
        {
            App.MasterD.IsPresented = false;
            FirebaseAuthService.LogOut();
        }
    }
}
