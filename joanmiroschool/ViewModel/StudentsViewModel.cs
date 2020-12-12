using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using joanmiroschool.Abstractions;
using joanmiroschool.Models;
using Refit;
using Xamarin.Essentials;

namespace joanmiroschool.ViewModel
{
    public class StudentsViewModel : INotifyPropertyChanged
    {
        private string _id;

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
        public ObservableCollection<StudentData> Students { get; set; }
        private IJMServices _iJMService { get; set; }

        public StudentsViewModel(IJMServices JMServices)
        {


            Id = Preferences.Get("Id", string.Empty);
            _iJMService = JMServices;
            Students = new ObservableCollection<StudentData>();
             
            Task.Run(async () => { await LoadStudents(); });
        }

        public async Task LoadStudents()
        {
            UserDialogs.Instance.ShowLoading();
            try
            {
                var st = await _iJMService.GetStudents(Id);
                Students.Clear();

                foreach (StudentData s in st)
                {
                    Students.Add(s);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("Exito", $"{ex}", "ok");

            }

            UserDialogs.Instance.HideLoading();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
