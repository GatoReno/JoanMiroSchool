using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace joanmiroschool.ViewModel
{
    public class ConfigViewModel : INotifyPropertyChanged
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
        public ConfigViewModel()
        {
              _accountEmail = Preferences.Get("AccountEmail", string.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
