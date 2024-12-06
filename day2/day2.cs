using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
static int part1() {
    using (StreamReader reader = new StreamReader("input.txt"))
    {
        string line;
        int count = 0;
        while ((line = reader.ReadLine()) != null)
        {
            string[] integers = line.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            bool incr = int.Parse(integers[0]) < int.Parse(integers[1]);
            int prev = 0;
            if (incr) {
                prev = int.Parse(integers[0]) - 1;
            } else {
                prev = int.Parse(integers[0]) + 1;
                
            }
            bool safe = true;
            
            foreach (string number in integers) {
                
                int diff = int.Parse(number) - prev;
                if (incr && !(diff >= 1 && diff <= 3)) {
                    safe = false;
                    break;
                } else if (!incr && !(diff <= -1 && diff >= -3)) {
                    safe = false;
                    break;
                }
                prev = int.Parse(number);
            }
            if (safe) {
                count++;
            }
        }
        return count;
    }
    return 0;
}


static bool find_incr(string[] integers) {
    int count = 0;
    int prev = int.Parse(integers[0]);
    foreach (string number in integers[1..4]) {
        int new_num = int.Parse(number);
        if (prev < new_num) {
            count ++;
        } else if (prev > new_num) {
            count --;
        }
        prev = new_num;
    }
    return count > 0;
}

static bool breaks_incr(int diff, bool incr) {
    return (incr && !(diff >= 1 && diff <= 3)) || (!incr && !(diff <= -1 && diff >= -3));
}

static int part2() {
    using (StreamReader reader = new StreamReader("input.txt"))
    {
        string line;
        int count = 0;
        while ((line = reader.ReadLine()) != null)
        {
            string[] integers = line.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            bool incr = find_incr(integers);
            

            bool skipped = false;
            int prev2 = int.Parse(integers[0]);
            int prev = int.Parse(integers[1]);

            int diff1 = prev - prev2;
            int start = 2;
            if (breaks_incr(diff1, incr)) {
                skipped = true;
            }
            if (breaks_incr(int.Parse(integers[2]) - prev, incr) && !breaks_incr(int.Parse(integers[2]) - prev2, incr)) {
                prev = prev2;
                skipped = true;
            } 
            bool safe = true;
            foreach (string number in integers[start..^0]) {
                int diff = int.Parse(number) - prev;
                if (breaks_incr(diff, incr)) {
                    diff = int.Parse(number) - prev2;
                    if (!skipped) {
                        skipped = true;
                    } else if (!breaks_incr(diff, incr) && !skipped) {
                        prev = int.Parse(number);
                        skipped = true;
                    } else {
                        safe = false;
                        break;
                    }
                } else {
                    prev2 = prev;
                    prev = int.Parse(number);
                }
            }
            if (safe) {
                count++;
                Console.WriteLine(line);
            }
        }
        return count;
    }
}

Console.WriteLine(part1());
Console.WriteLine(part2());

