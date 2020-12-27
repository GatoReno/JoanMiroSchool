using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using joanmiroschool.Abstractions;
using joanmiroschool.Helpers;
using joanmiroschool.Services;
using joanmiroschool.ViewModel;
using Refit;
using Xamarin.Forms;

namespace joanmiroschool.View
{
    public partial class LoginPage : ContentPage
    {
        public  LoginPage()
        {

            InitializeComponent();


            #region connectivity
            var conn = ConetctivityManager.CheckConnectivity();
            
            if (!conn)
            {              
                ConetctivityManager.ConnectivityAlert();                
            }
            #endregion

            BindingContext = new LogsViewModel(
                RestService.For<IJMServices>("https://eliappjmadmin.herokuapp.com"),
                DependencyService.Get<IFiBAuth>()
                );
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
