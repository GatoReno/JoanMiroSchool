using System;
using System.Collections.Generic;
using joanmiroschool.Abstractions;
using joanmiroschool.ViewModel;
using Refit;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace joanmiroschool.View
{
    public partial class StatementsPages : ContentPage
    {
        public StatementsPages()
        {
            InitializeComponent();
            BindingContext = new StatementsViewModel(
                RestService.For<IJMServices>("https://eliappjmadmin.herokuapp.com")
                , Preferences.Get("Id", string.Empty));
        }
    }
}
