using System;
using System.Collections.Generic;
using joanmiroschool.ViewModel;
using Xamarin.Forms;

namespace joanmiroschool.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LogsViewModel();
        }

        void TapGestureRecognizer_Tapped_RegisterLbl(System.Object sender, System.EventArgs e)
        {
            RegistStackLayout.IsVisible = true;
            LoginStackLayout.IsVisible = false;
        }

        void TapGestureRecognizer_Tapped_LogInLbl(System.Object sender, System.EventArgs e)
        {
            RegistStackLayout.IsVisible = false;
            LoginStackLayout.IsVisible = true;
            ResetPasswordStackLayout.IsVisible = false;
        }

        void TapGestureRecognizer_Tapped_ResetPassword(System.Object sender, System.EventArgs e)
        {
            LoginStackLayout.IsVisible = false;
            ResetPasswordStackLayout.IsVisible = true;
        }
    }
}
