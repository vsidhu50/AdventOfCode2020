using System;
namespace AdventOfCode2020
{
    public class Day3
    {
        public Day3()
        {
        }

        public static long PartOne()
        {
            return TreeCount(3, 1);
        }

        public static long PartTwo()
        {
            return TreeCount(1, 1) * TreeCount(3, 1) * TreeCount(5, 1) * TreeCount(7, 1) * TreeCount(1, 2);
        }

        private static long TreeCount(int right, int down)
        {
            var lines = Utilities.GetInputLines(3);
            var rowCount = lines.Count;
            var colCount = lines[0].Length;

            var rowIndex = 0;
            var colIndex = 0;
            var treeCount = 0;

            while (rowIndex < rowCount)
            {
                if (lines[rowIndex][colIndex] == '#')
                    treeCount++;

                rowIndex += down;
                colIndex += right;
                colIndex %= colCount;
            }

            return treeCount;
        }
    }
}
