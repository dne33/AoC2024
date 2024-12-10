using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
static int part1()
{
    using (StreamReader reader = new StreamReader("test.txt"))
    {
        string line;
        int count = 0;
        Dictionary<int, List<int>> order = new Dictionary<int, List<int>>();
        var numRegex = new Regex(@"(?<Part1>\d+)\|(?<Part2>\d+)");

        while ((line = reader.ReadLine()) != null)
        {
            var nums = numRegex.Match(line);
            if (nums.Success)
            {
                var part1 = int.Parse(nums.Groups["Part1"].Value);
                var part2 = int.Parse(nums.Groups["Part2"].Value);

                if (order.ContainsKey(part1))
                {
                    order[part1].Add(part2);
                }
                else
                {
                    order[part1] = new List<int> { part2 };
                }
            }
            else if (line.Length > 0)
            {
                var nextLine = false;
                HashSet<int> usedNumbers = new HashSet<int>();
                string[] numList = line.Split(',');
                int length = 0;
                foreach (string number in numList) {
                    length += 1;
                    var current = int.Parse(number);
                    if (order.ContainsKey(current)) {
                        foreach(int check in order[current]) {
                        if (usedNumbers.Contains(check)) {
                            nextLine = true;
                            break;
                        }

                    }
                    }
                    
                    if (nextLine) {
                        break;
                    } else {
                       usedNumbers.Add(current);
                    }
                }
                if (!nextLine) {
                    count += int.Parse(numList[length/2]);
                }
            }

        }
        foreach (var kvp in order)
        {
            Console.Write($"Key: {kvp.Key}, Values: ");
            Console.WriteLine(string.Join(", ", kvp.Value));
        }
        return count;
    }
    return 0;
}




static int part2()
{
    return 0;
}

Console.WriteLine(part1());
Console.WriteLine(part2());

