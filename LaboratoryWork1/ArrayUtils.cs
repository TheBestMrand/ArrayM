using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LaboratoryWork1
{
    public static class ArrayUtils
    {
        public static IEnumerable<int> ConvertToIEnumerable(this string input)
        {
            return input.Split(' ').Select(int.Parse);
        }

        public static int[] Remove(this int[] array, int[] toRemove)
        {
            HashSet<int> selectedIndices = new HashSet<int>(toRemove);

            return array.Where((item, index) => !selectedIndices.Contains(index)).ToArray();
        }

        public static int[] Remove(this int[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            int[] newArray = new int[array.Length - 1];
            Array.Copy(array, 0, newArray, 0, index);
            Array.Copy(array, index + 1, newArray, index, array.Length - index - 1);

            return newArray;
        }
    }
}
