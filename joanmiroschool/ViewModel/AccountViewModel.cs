using System;
using System.ComponentModel;
using joanmiroschool.Abstractions;
using Refit;
using Xamarin.Essentials;

namespace joanmiroschool.ViewModel
{
    public class AccountViewModel :  INotifyPropertyChanged
    {
        private string  email_ ;

        public event PropertyChangedEventHandler PropertyChanged;

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
            }
        }

        public AccountViewModel()
        {
            email_ = Preferences.Get("AccountEmail", string.Empty);
            GetStudents(email_);
        }


        async void GetStudents(string email)
        {
            var accountData = RestService.For<IJMServices>("https://eliappjmadmin.herokuapp.com");
            try
            {
                var response = await accountData.GetAccount("joanahernandez2507@gmail.com");
                var resp = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
 
        }



        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
