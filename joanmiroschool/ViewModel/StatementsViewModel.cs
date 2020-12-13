using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using joanmiroschool.Abstractions;
using joanmiroschool.Models;

namespace joanmiroschool.ViewModel
{
    public class StatementsViewModel : INotifyPropertyChanged
    {
        private string _id;
        private IJMServices _iJMService { get; set; }
        public ObservableCollection<StatementData> Statements { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        #region props
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
        public StatementsViewModel(IJMServices JMServices, string id)
        {
            Id = id;
            _iJMService = JMServices;
            Statements = new ObservableCollection<StatementData>();
            Task.Run(async () => { await LoadStatements(); });
        }
        public async Task LoadStatements()
        {
            UserDialogs.Instance.ShowLoading();
            try
            {
                var stat = await _iJMService.GetStatements(Id);
                Statements.Clear();

                foreach (StatementData s in stat)
                {
                    Statements.Add(s);
                }

                UserDialogs.Instance.HideLoading();
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
