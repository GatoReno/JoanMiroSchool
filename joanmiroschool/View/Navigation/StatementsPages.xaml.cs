using System;
using System.Collections.Generic;
using joanmiroschool.Abstractions;
using joanmiroschool.ViewModel;
using Refit;
using Xamarin.Forms;

namespace joanmiroschool.View
{
    public partial class StatementsPages : ContentPage
    {
        public StatementsPages()
        {
            InitializeComponent();
            BindingContext = new StudentsViewModel(
                RestService.For<IJMServices>("https://eliappjmadmin.herokuapp.com"));
        }
    }
}
