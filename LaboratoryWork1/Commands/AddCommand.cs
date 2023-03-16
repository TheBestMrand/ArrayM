using LaboratoryWork1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryWork1.Commands
{
    public class AddCommand : ICommand
    {
        private MainViewModel _viewModel;

        public AddCommand(MainViewModel viewModel)
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
            if(int.TryParse(parameter?.ToString(), out int result))
            {
                _viewModel.Numbers = _viewModel.Numbers.Append(result).ToArray();
            }
            else
            {
                throw new Exception("das");
            }
        }
    }
}
