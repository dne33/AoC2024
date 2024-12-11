using System;
using System.Collections.Generic;
static long recursively_multiply(List<long> nums, long answer) {
    if (nums.Count == 1) {
        
        if (nums[0] == answer) {
            return 1;
        } else {
            return 0;  
        }
    }
    List<long> mult = new List<long>();
    // Console.WriteLine(nums[0]);
    // Console.WriteLine(nums.Count);

    mult.Add(nums[0] * nums[1]);
    mult.AddRange(nums[2..^0]);

    List<long> add = new List<long>();
    add.Add(nums[0] + nums[1]);
    add.AddRange(nums[2..^0]);

    List<long> concat = new List<long>();
    concat.Add(long.Parse(nums[0].ToString() +  nums[1].ToString()));
    concat.AddRange(nums[2..^0]);

    return 0 + recursively_multiply(mult, answer) + recursively_multiply(add, answer) + recursively_multiply(concat, answer);
}
static long part1() {
     using (StreamReader reader = new StreamReader("input.txt"))
        {
            string line;
            long count = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string[] vals = line.Split(':');
                long result = long.Parse(vals[0]);
                string[] numbers = vals[1].Split(" ");
                List<long> nums = new List<long>();
                foreach(string num in numbers) {
                    long defaultNum = 0;
                    bool canConvert = long.TryParse(num, out defaultNum);
                    if (canConvert) {
                        nums.Add(defaultNum);
                    }
                }
                if (recursively_multiply(nums, result) > 0) {
                    // Console.WriteLine(result);
                    count += result;
                }
            }
            return count;
        }
    return 0;
}




static long part2() {
    using (StreamReader reader = new StreamReader("input.txt"))
        {
            string line;
            long count = 0;
            while ((line = reader.ReadLine()) != null)
            {
            }
            return count;
        }
    return 0;
}

Console.WriteLine(part1());
Console.WriteLine(part2());

