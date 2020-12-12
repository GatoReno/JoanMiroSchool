using System;
using System.Collections.Generic;
using joanmiroschool.Abstractions;
using joanmiroschool.Models;
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

        async void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var st = e.Item as StudentData;
            await App.MasterD.Detail.Navigation.PushAsync(
                new Students.DetailsPage(st.Id.ToString()));
        }


       
    }
}
