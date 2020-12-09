using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace joanmiroschool.ViewModel
{
    public class ConfigViewModel : INotifyPropertyChanged
    {
        private string _theme;
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
        public ConfigViewModel()
        {
           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
