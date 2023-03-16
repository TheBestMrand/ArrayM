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
        /// <summary>
        /// Converts a string of space separated integers into an IEnumerable of integers
        /// </summary>
        /// <param name="input">A string of space separated integers</param>
        public static IEnumerable<int> ConvertToIEnumerable(this string input)
        {
            return input.Split(' ').Select(int.Parse);
        }

        /// <summary>
        /// Removes the elements at the specified indices from the given array
        /// </summary>
        /// <param name="array">The input array</param>
        /// <param name="toRemove">An array of indices to remove from the input array</param>
        public static int[] Remove(this int[] array, int[] toRemove)
        {
            HashSet<int> selectedIndices = new HashSet<int>(toRemove);

            return array.Where((item, index) => !selectedIndices.Contains(index)).ToArray();
        }

        /// <summary>
        /// Removes the element at the specified index from the given array
        /// </summary>
        /// <param name="array">The input array</param>
        /// <param name="index">The index of the element to removey</param>
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

        /// <summary>
        /// Converts an array of integers into a string representation, with elements separated
        /// </summary>
        /// <param name="array">The input array of integers</param>
        public static string Stringify(this int[] array)
        {
            return string.Join(", ", array);
        }
    }
}
