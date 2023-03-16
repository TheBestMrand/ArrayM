using LaboratoryWork1.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LaboratoryWork1.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int[] _numbers;
        public int[] Numbers
        {
            get => _numbers;
            set
            {
                _numbers = value;
                OnPropertyChanged(nameof(Numbers));
            }
        }

        private int[] _selectedNumbers;
        public int[] SelectedNumbers
        {
            get => _selectedNumbers;
            set
            {
                _selectedNumbers = value;
                OnPropertyChanged(nameof(SelectedNumbers));
                DeleteSelectedCommand.RaiseCanExecuteChanged(); 
            }
        }

        public AddCommand AddCommand { get; private set; }
        public DeleteSelectedCommand DeleteSelectedCommand { get; private set; }

        public MainViewModel()
        {
            _numbers = new int[0];

            AddCommand = new AddCommand(this);
            DeleteSelectedCommand = new DeleteSelectedCommand(this);
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
