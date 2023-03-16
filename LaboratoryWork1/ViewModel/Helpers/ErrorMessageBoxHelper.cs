using LaboratoryWork1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork1.ViewModel.Helpers
{
    class ErrorMessageBoxHelper
    {
        public static void Show(string errorMessage)
        {
            var errorBox = new ErrorMessageBoxViewModel();
            errorBox.Message = errorMessage;
            var window = new ErrorMessageBoxView() { DataContext = errorBox };
            window.ShowDialog();
            window.Focus();
        }
    }
}
