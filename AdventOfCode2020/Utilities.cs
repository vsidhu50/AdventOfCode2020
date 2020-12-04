using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public class Utilities
    {
        public Utilities()
        {
        }

        public static List<string> GetLines(int day)
        {
            var lines = new List<string>();
            string line;

            var file = new StreamReader($"/Users/vsidhu/Projects/AdventOfCode2020/AdventOfCode2020/Input/Day{day}.txt");

            while ((line = file.ReadLine()) != null)
                lines.Add(line);

            return lines;
        }
    }
}
