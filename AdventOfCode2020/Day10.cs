using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day10
    {
        public Day10()
        {
        }

        public static int PartOne()
        {
            var numbers = Utilities.GetInputLongs(10);
            var num1 = 0;
            var num3 = 1;

            numbers.Add(0);

            numbers.Sort();

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] - numbers[i - 1] == 3)
                    num3++;
                if (numbers[i] - numbers[i - 1] == 1)
                    num1++;
            }

            return num1 * num3;
        }

        public static long PartTwo()
        {
            var numbers = Utilities.GetInputLongs(10);
            numbers.Add(0);
            numbers.Sort();

            var paths = new List<long>(new long[numbers.Count]) { [0] = 1 }; 

            for (int i = 1; i < numbers.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (numbers[i] - numbers[j] <= 3)
                        paths[i] += paths[j];
                }
            }

            return paths[numbers.Count - 1];
        }

    }
}
