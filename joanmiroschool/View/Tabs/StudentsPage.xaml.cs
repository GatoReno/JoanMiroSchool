using System;
using System.Collections.Generic;
using joanmiroschool.ViewModel;
using Xamarin.Forms;

namespace joanmiroschool.View.Tabs
{
    public partial class StudentsPage : ContentPage
    {
        public StudentsPage()
        {
            InitializeComponent();
            BindingContext = new StudentsViewModel();
        }

        void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
        }
    }
}
