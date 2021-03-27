using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using joanmiroschool.Services;
using joanmiroschool.View;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace joanmiroschool.ViewModel
{
    public class ConfigViewModel : BaseViewModel
    {
        private string _theme, _accountEmail;
        public string ThemeName
        {
            get
            {
                return _theme;
            }
            set
            {
                _theme = value;

                OnPropertyChanged("ThemeName");
            }
        }

        public string AccountEmail
        {
            get
            {
                return _accountEmail;
            }
            set
            {
                _accountEmail = value;

                OnPropertyChanged("AccountEmail");
            }
        }

        public ICommand LogoutCommand { get; set; }

        public ConfigViewModel()
        {
            AccountEmail = Preferences.Get("Email", string.Empty);
            LogoutCommand = new Command(async () => await OnLogout());
        }

        private async Task OnLogout()
        {
            var outAlert = await App.Current.MainPage.DisplayAlert("Cerrar session", "Usted esta apunto de cerrar sesion", "ok","cancel");
            if (outAlert)
            {
                FirebaseAuthService.LogOut();
            }
        }

       

    }
}
