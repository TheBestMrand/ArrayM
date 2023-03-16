using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace LaboratoryWork1
{
    public class Validation
    {
        public string ProccesInput(string input)
        {
            string pattern = @"[\[\{,]|[\]\}]|\s+";
            string replaced = Regex.Replace(input, pattern, " ");
            replaced = Regex.Replace(replaced, @"\s{2,}", " ");
            return replaced.Trim();
        }

        public bool ValidateInput(string input)
        {
            return Regex.IsMatch(input, @"^(-?\d+(\s+-?\d+)*)$");
        }
    }
}
