using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Utilities
    {
        public Utilities()
        {
        }

        public static List<string> GetInputLines(int day)
        {
            return File.ReadAllText($"/Users/vsidhu/Projects/AdventOfCode2020/AdventOfCode2020/Input/Day{day}.txt").Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList(); ;
        }

        public static List<string> GetInputParagraphs(int day)
        {
            return File.ReadAllText($"/Users/vsidhu/Projects/AdventOfCode2020/AdventOfCode2020/Input/Day{day}.txt").Split("\n\n", StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static List<int> GetInputNums(int day)
        {
            return File.ReadAllText($"/Users/vsidhu/Projects/AdventOfCode2020/AdventOfCode2020/Input/Day{day}.txt").Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(x => Int32.Parse(x)).ToList(); 
        }

        public static List<long> GetInputLongs(int day)
        {
            return File.ReadAllText($"/Users/vsidhu/Projects/AdventOfCode2020/AdventOfCode2020/Input/Day{day}.txt").Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(x => Int64.Parse(x)).ToList();
        }

        public static char[,] GetInputGridChars(int day)
        {
            var rows = Utilities.GetInputLines(day);
            var numRows = rows.Count;
            var numCols = rows[0].Length;
            var grid = new char[numRows, numCols];

            for (int i = 0; i < numRows; i++)
                for (int j = 0; j < numCols; j++)
                    grid[i, j] = rows[i][j];

            return grid;
        }

        public static List<string> GetLines(string input)
        {
            return input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static List<string> GetWords(string input)
        {
            return input.Split(new string[] { " ", "\t", Environment.NewLine, ",", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static List<int> GetNums(string input)
        {
            return input.Split(new string[] { " ", "\t", Environment.NewLine, ",", "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => Int32.Parse(x)).ToList();
        }
    }
}
