using System;
using System.ComponentModel;

namespace joanmiroschool.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
