using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
static int part1() {
    var regex = new Regex(@"mul\(\d+,\d+\)");


    var numRegex = new Regex(@"(?<Part1>\d+),(?<Part2>\d+)");
    using (StreamReader reader = new StreamReader("input.txt"))
        {
            string line;
            int count = 0;
            while ((line = reader.ReadLine()) != null)
            {
                var result = regex.Matches(line).Where(p => p.Success).Select(p => p.Value).ToList();
                foreach (string match in result) {
                    var nums = numRegex.Match(match);
                    count += (int.Parse(nums.Groups["Part1"].Value) * int.Parse(nums.Groups["Part2"].Value));
                }
            }
            return count;
        }
}




static int part2() {
    var regex = new Regex(@"mul\(\d+,\d+\)|do\(\)|don't\(\)");
    var regexDo = new Regex(@"do\(\)");
    var regexDont = new Regex(@"don't\(\)");


    var numRegex = new Regex(@"(?<Part1>\d+),(?<Part2>\d+)");
    using (StreamReader reader = new StreamReader("input.txt"))
        {
            string line;
            int count = 0;
            var doing = true;
            while ((line = reader.ReadLine()) != null)
            {
                var result = regex.Matches(line).Where(p => p.Success).Select(p => p.Value).ToList();
                

                foreach (string match in result) {
                    if (regexDo.Match(match).Success) {
                        doing = true;

                    } else if (regexDont.Match(match).Success) {
                        doing = false;
                    } else if (doing && numRegex.Match(match).Success) {
                        var nums = numRegex.Match(match);
                        count += (int.Parse(nums.Groups["Part1"].Value) * int.Parse(nums.Groups["Part2"].Value));
                    }
                }
            }
            return count;
        }
}

// Console.WriteLine(part1());
Console.WriteLine(part2());

