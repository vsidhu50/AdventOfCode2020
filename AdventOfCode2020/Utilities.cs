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

        public static List<string> GetLines(int day, string split)
        {
            return File.ReadAllText($"/Users/vsidhu/Projects/AdventOfCode2020/AdventOfCode2020/Input/Day{day}.txt").Split(split, StringSplitOptions.RemoveEmptyEntries).ToList(); ;
        }
    }
}
