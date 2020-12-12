using System;
using System.ComponentModel;
using joanmiroschool.Abstractions;
using Refit;
using Xamarin.Essentials;

namespace joanmiroschool.ViewModel
{
    public class AccountViewModel :  INotifyPropertyChanged
    {
        private string  _email, _name,_phone ,_estado ;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email"); 
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Estado
        {
            get
            {
                return _estado;
            }
            set
            {
                _estado = value;
                OnPropertyChanged("Estado");
            }
        }

        public AccountViewModel()
        {  
            Email = Preferences.Get("Email", string.Empty);
            Estado = Preferences.Get("Estado", string.Empty);
            Phone = Preferences.Get("Phone", string.Empty);
            Name = Preferences.Get("Name", string.Empty);
        }
         
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
