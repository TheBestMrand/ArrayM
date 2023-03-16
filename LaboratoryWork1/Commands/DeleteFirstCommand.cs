using LaboratoryWork1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryWork1.Commands
{
    public class DeleteFirstCommand : ICommand
    {
        private MainViewModel _viewModel;

        public DeleteFirstCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _viewModel.Numbers.Length > 0;
        }

        public void Execute(object? parameter)
        {
            var numbersList = _viewModel.Numbers.ToList();
            numbersList.RemoveAt(0);
            _viewModel.Numbers = numbersList.ToArray();
        }

        public void RaiseCanExecuteChanged() 
        { 
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
