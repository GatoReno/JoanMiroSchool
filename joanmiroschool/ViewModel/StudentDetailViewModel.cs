using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using joanmiroschool.Abstractions;

namespace joanmiroschool.ViewModel
{
    public class StudentDetailViewModel : INotifyPropertyChanged
    {
        private string _nivel, _name, _lastNameP,_lastNameM, _estado, _id;
        private IJMServices _iJMService { get; set; }

        #region props
        public string Nivel
        {
            get
            {
                return _nivel;
            }
            set
            {
                _nivel = value;

                OnPropertyChanged("Nivel");
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
        public string LastNameM
        {
            get
            {
                return _lastNameM;
            }
            set
            {
                _lastNameM = value;

                OnPropertyChanged("LastNameM");
            }
        }
        public string LastNameP
        {
            get
            {
                return _lastNameP;
            }
            set
            {
                _lastNameP = value;

                OnPropertyChanged("LastNameP");
            }
        }
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;

                OnPropertyChanged("Id");
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public StudentDetailViewModel(IJMServices JMServices, string id)
        {
            Id = id;
            _iJMService = JMServices;
            Task.Run(async () => { await LoadStudentData(); });
        }
        private async Task  LoadStudentData()
        {
            UserDialogs.Instance.ShowLoading();
            try
            {
                var st = await _iJMService.GetDataStudent(Id);
                var res = st[0];
                Name = res.Name;
                Estado = res.Estado;
                LastNameM = res.LastnameM;
                LastNameP = res.LastnameP;
                Nivel = res.Nivel;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("Exito", $"{ex}", "ok");
            }
            UserDialogs.Instance.HideLoading();
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
