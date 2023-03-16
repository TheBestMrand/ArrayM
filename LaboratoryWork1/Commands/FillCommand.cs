using LaboratoryWork1.Utilities;
using LaboratoryWork1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryWork1.Commands
{
    public class FillCommand : ICommand
    {
        private MainViewModel _viewModel;

        public FillCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.Numbers = new int[0];
            _viewModel.Numbers = _viewModel.Numbers.Generate(10);
        }
    }
}
