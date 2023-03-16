using System.Text.RegularExpressions;

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
