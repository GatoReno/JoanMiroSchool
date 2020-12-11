using System;
using System.ComponentModel;
using joanmiroschool.Abstractions;
using Refit;
using Xamarin.Essentials;

namespace joanmiroschool.ViewModel
{
    public class AccountViewModel :  INotifyPropertyChanged
    {
        private string  email_, name_,phone_ ,estado_ ;

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

        public string Phone
        {
            get
            {
                return phone_;
            }
            set
            {
                phone_ = value;
                OnPropertyChanged("Phone");
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
            }
        }

        public string Estado
        {
            get
            {
                return estado_;
            }
            set
            {
                estado_ = value;
                OnPropertyChanged("Estado");
            }
        }

        public AccountViewModel()
        {
           
         
            GetAccount(email_);
            Email = Preferences.Get("AccountEmail", string.Empty);
            Estado = Preferences.Get("Estado", string.Empty);
            Phone = Preferences.Get("Phone", string.Empty);
            Name = Preferences.Get("Name", string.Empty);
        }
        

        async void GetAccount(string email)
        {
            var accountData = RestService.For<IJMServices>("https://eliappjmadmin.herokuapp.com");
            try
            {
                var response = await accountData.GetAccount("joanahernandez2507@gmail.com");
                var resp = response[0];
                Estado = resp.Estado;
                Phone = resp.Phone;
                Name = resp.Name;

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
