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

        private ListBox _listBox;

        private int[] _numbers;
        public int[] Numbers
        {
            get => _numbers;
            set
            {
                _numbers = value;
                OnPropertyChanged(nameof(Numbers));
                DeleteLastCommand.RaiseCanExecuteChanged();
                DeleteFirstCommand.RaiseCanExecuteChanged();
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
                if(_selectedNumbers.Length == 0)
                {
                    _listBox.UnselectAll();
                }
            }
        }

        public AddCommand AddCommand { get; private set; }
        public DeleteSelectedCommand DeleteSelectedCommand { get; private set; }
        public DeleteFirstCommand DeleteFirstCommand { get; private set; }
        public DeleteLastCommand DeleteLastCommand { get; private set; }
        public FillCommand FillCommand { get; private set; }
        public ListBox ListBox { get => _listBox; set => _listBox = value; }

        public MainViewModel()
        {
            _numbers = new int[0];

            AddCommand = new AddCommand(this);
            DeleteSelectedCommand = new DeleteSelectedCommand(this);
            DeleteFirstCommand = new DeleteFirstCommand(this);
            DeleteLastCommand = new DeleteLastCommand(this);
            FillCommand = new FillCommand(this);
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
