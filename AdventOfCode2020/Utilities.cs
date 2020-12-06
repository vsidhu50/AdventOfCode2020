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

        public static List<string> GetLines(string input)
        {
            return input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static List<string> GetWords(string input)
        {
            return input.Split(new string[] { " ", "\t", Environment.NewLine, ",", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
