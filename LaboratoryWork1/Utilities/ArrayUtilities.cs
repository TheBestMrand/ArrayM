using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork1.Utilities
{
    public static class ArrayUtilities
    {
        public static int[] Generate(this int[] array, int length)
        {
            Random rnd = new Random();

            array = new int[length];

            array = Enumerable.Repeat(0, length).Select(x => rnd.Next(-100,100)).ToArray();

            return array;
        }
    }
}
