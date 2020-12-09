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
                 
            }
        }
        public ConfigViewModel()
        {
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
