using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day9
    {
        public Day9()
        {
        }

        public static long PartOne()
        {
            var numbers = Utilities.GetInputLongs(9);

            for (int i = 25; i < numbers.Count; i++)
            {
                var hasSum = false;

                for (int j = i - 25; j < i - 1; j++)
                    for (int k = j + 1; k < i; k++)
                        if (numbers[j] + numbers[k] == numbers[i])
                            hasSum = true;

                if (!hasSum)
                    return numbers[i];
            }
            return -1;
        }

        public static long PartTwo()
        {
            var numbers = Utilities.GetInputLongs(9);
            var pOne = PartOne();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    var list = numbers.GetRange(i, j - i + 1);

                    if (list.Sum() == pOne)
                        return list.Max() + list.Min();
                }
            }

            return -1;
        }
    }
}
