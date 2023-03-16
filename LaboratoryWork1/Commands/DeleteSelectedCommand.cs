using LaboratoryWork1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryWork1.Commands
{
    public class DeleteSelectedCommand : ICommand
    {
        private MainViewModel _viewModel;

        public DeleteSelectedCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedNumbers?.Length > 0;
        }

        public void Execute(object? parameter)
        {
            var selectedIndexes = new HashSet<int>(_viewModel.SelectedNumbers.Select((num, index) => index));

            _viewModel.Numbers = _viewModel.Numbers
                .Where((number, index) => !selectedIndexes.Contains(index))
                .ToArray();
            _viewModel.SelectedNumbers = new int[0]; 
        }


        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
