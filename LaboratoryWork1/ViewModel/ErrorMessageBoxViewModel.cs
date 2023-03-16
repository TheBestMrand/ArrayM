using LaboratoryWork1.Commands;
using System;
using System.ComponentModel;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryWork1.ViewModel
{
    public class ErrorMessageBoxViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _message;

        public string Message { get => _message; set { _message = value; OnPropertyChanged(nameof(Message)); } }

        public ICommand? CloseCommand { get; private set; }

        public ErrorMessageBoxViewModel() => CloseCommand = new CustomCommand(() => Application.Current.Dispatcher.Invoke(() => ((Window)Application.Current.Windows[1]).Close()));

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
