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
        private readonly NumberFormatInfo _currentCultureInfo;

        public Validation()
        {
            _currentCultureInfo = CultureInfo.CurrentCulture.NumberFormat;
        }

        private string HandleCommaAsSeparator(string input)
        {
            var parts = input.Split(',');

            if (parts.Length > 1)
            {
                for (int i = 0; i < parts.Length; i++)
                {
                    if (!string.IsNullOrEmpty(parts[i]))
                    {
                        parts[i] = parts[i].Trim();
                    }
                }
            }

            return string.Join(" ", parts);
        }

        public string ProccesInput(string input)
        {
            string pattern = @"[\[\{,]|[\]\}]|\s+";
            string replaced = Regex.Replace(input, pattern, " ");
            return replaced.Trim();
        }

        public bool ValidateInput(string input)
        {
            return Regex.IsMatch(input, @"^(\d+(\s+\d+)*)$");
        }
    }
}
