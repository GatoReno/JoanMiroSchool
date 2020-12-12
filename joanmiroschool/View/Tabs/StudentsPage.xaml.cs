using System;
using System.Collections.Generic;
using joanmiroschool.Abstractions;
using joanmiroschool.ViewModel;
using Refit;
using Xamarin.Forms;

namespace joanmiroschool.View.Tabs
{
    public partial class StudentsPage : ContentPage
    {
        public StudentsPage()
        {
            InitializeComponent();
            BindingContext = new StudentsViewModel
            (
                RestService.For<IJMServices>("https://eliappjmadmin.herokuapp.com")
            );
          
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
             

        }

        void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
        }
    }
}
