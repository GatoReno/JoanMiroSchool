using System;
using System.Collections.Generic;
using joanmiroschool.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace joanmiroschool.View
{
    public partial class ConfigPage : ContentPage
    {
        public ConfigPage()
        {
            InitializeComponent();
            BindingContext = new ConfigViewModel();

           

            //var prefTheme = Preferences.Get("Theme", string.Empty);
            //if (string.IsNullOrEmpty(prefTheme))
            //{

            //}
            //else
            //{
            //    if (prefTheme == "Dark")
            //    {
            //        Application.Current.UserAppTheme = OSAppTheme.Dark;
            //    }
            //    else if (prefTheme == "Light")
            //    {
            //        Application.Current.UserAppTheme = OSAppTheme.Light;
            //    }
            //}


            Application.Current.RequestedThemeChanged += (_, args) =>
            {
                themeName.Text = args.RequestedTheme.ToString();
            };
            themeName.Text = Application.Current.RequestedTheme.ToString();

        }
        public void btnChangeTheme_Clicked(object sender, EventArgs args)
        {
            if (Application.Current.RequestedTheme.ToString() == "Dark")
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
                Preferences.Set("Theme", "Light");
            }
            else
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
                Preferences.Set("Theme", "Dark");
            }
        }
    }
}
