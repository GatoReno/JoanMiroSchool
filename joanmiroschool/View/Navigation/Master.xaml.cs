using System;
using System.Collections.Generic;

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
        }

        void TapGestureRecognizer_Tapped_LogOut(System.Object sender, System.EventArgs e)
        {
        }
    }
}
