using System;
using System.ComponentModel;
using joanmiroschool.Abstractions;

namespace joanmiroschool.ViewModel
{
    public class StudentDetailViewModel : INotifyPropertyChanged
    {
        private string _nivel, _name, _lastNameP,_lastNameM, _estado, _id;
        private IJMServices _iJMService { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public StudentDetailViewModel(IJMServices JMServices, string id)
        {
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
