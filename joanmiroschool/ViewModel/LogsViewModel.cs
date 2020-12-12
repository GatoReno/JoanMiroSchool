using System;
using System.ComponentModel;
using System.Windows.Input;
using Acr.UserDialogs;
using joanmiroschool.Abstractions;
using joanmiroschool.Services;
using Refit;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace joanmiroschool.ViewModel
{
    public class LogsViewModel : INotifyPropertyChanged
    {
        private string name_, email_, password_, confirmPassword_;
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
        public ICommand ResetCommand { get; set; }

        private IJMServices _iJMService { get; set; }

        private IFiBAuth _fiBAuth { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public LogsViewModel(
            IJMServices jMServices,
            IFiBAuth fiBAuth
            )
        {
            LoginCommand = new Command(Login, CanLoginExecute);
            RegisterCommand = new Command(Register, CanRegisterExecute);
            ResetCommand = new Command(ResetPassword);
            _iJMService = jMServices;
            _fiBAuth = fiBAuth; 
        }

        private  void ResetPassword(object obj)
        {

            _fiBAuth.ResetPassword(Email);
        }

        private bool CanRegisterExecute(object arg)
        {
            return CanRegister;
        }

        private async  void Register(object obj)
        {
            //AuthFirebase

            if (confirmPassword_ != Password)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coniciden! ", "ok");
            }
            else
            {
                try
                {
                    UserDialogs.Instance.ShowLoading();
                    await _fiBAuth.RegisterUser(Name, Email, Password);
                    await App.Current.MainPage.DisplayAlert("Exito","Usuario registrado, ya puedes iniciar sesion","ok");

                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error", $"{ex.ToString()} ", "ok");
                }
                UserDialogs.Instance.HideLoading();
            }

        }

        private bool CanLoginExecute(object arg)
        {
            return CanLogin;
        }

        private async void Login(object param)
        {

            UserDialogs.Instance.ShowLoading();
            try
            {
               bool au =  await _fiBAuth.AuthenticateUser(Email, Password);
                if (au)
                {
                    try
                    {                        
                        var response = await _iJMService.GetAccount("joanahernandez2507@gmail.com");
                        var resp = response[0];
                        Preferences.Set("Estado", resp.Estado);
                        Preferences.Set("Phone", resp.Phone);
                        Preferences.Set("Name", resp.Name);
                        Preferences.Set("Id", resp.Id);
                        Preferences.Set("Email", Email);

                        Application.Current.MainPage = new MainPage();

                    }
                    catch (Exception ex)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", $"{ex.ToString()} ", "ok");
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"{ex.ToString()} ", "ok");
            }
            UserDialogs.Instance.HideLoading();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
