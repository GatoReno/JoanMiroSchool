using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using joanmiroschool.ViewModel;
using Xamarin.Forms;

namespace joanmiroschool.View
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new AccountViewModel();
         }
        
    }
}
