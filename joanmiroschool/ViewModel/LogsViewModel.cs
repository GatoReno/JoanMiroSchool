using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace joanmiroschool.ViewModel
{
    public class LogsViewModel : INotifyPropertyChanged
    {
        private string name_, email_, password_, confirmPassword_, phone_;
        private bool canLogin_, canRegister_;
        public string Email
        {
            get
            {
                return email_;
            }
            set
            {
                email_ = value;
                OnPropertyChanged("Email");
                OnPropertyChanged("CanLogin");
            }
        }
        public string Password
        {
            get
            {
                return password_;
            }
            set
            {
                password_ = value;
                OnPropertyChanged("Passwprd");
                OnPropertyChanged("CanLogin");
            }
        }
        public string Name
        {
            get
            {
                return name_;
            }
            set
            {
                name_ = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("CanRegister");
            }
        }
        public string ConfirmPassword
        {
            get
            {
                return confirmPassword_;
            }
            set
            {
                confirmPassword_ = value;
                OnPropertyChanged("ConfirmPassword");
                OnPropertyChanged("CanRegister");
            }
        }
        public string Phone
        {
            get
            {
                return phone_;
            }
            set
            {
                phone_ = value;
                OnPropertyChanged("Email");
            }
        }

        public bool CanLogin
        {
            get
            {
                return !string.IsNullOrEmpty(Email) &&
                  !string.IsNullOrEmpty(Password);
            }
            set { canLogin_ = value; }
        }
        public bool CanRegister
        {
            get
            {
                return !string.IsNullOrEmpty(Email)
                  && !string.IsNullOrEmpty(Password)
                  && !string.IsNullOrEmpty(ConfirmPassword)
                  && !string.IsNullOrEmpty(Name);
            }
            set { canRegister_ = value; }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public LogsViewModel()
        {
            LoginCommand = new Command(Login, CanLoginExecute);
            RegisterCommand = new Command(Register, CanRegisterExecute);
        }

        private bool CanRegisterExecute(object arg)
        {
            return CanRegister;
        }

        private  void Register(object obj)
        {
            //AuthFirebase
            if (confirmPassword_ != Password)
            {
                //await App.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coniciden! ", "ok");
            }
            else
            {
                //await FirebaseAuthService.RegisterUser(Name, Email, Password, Phone);
            }

        }

        private bool CanLoginExecute(object arg)
        {
            return CanLogin;
        }

        private  void Login(object param)
        {
            //await FirebaseAuthService.AuthenticateUser(Email,Password);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
