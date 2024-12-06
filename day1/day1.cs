using System;
using System.Collections.Generic;
static int part1() {
    using (StreamReader reader = new StreamReader("input.txt"))
    {
        string line;
        List<int> numbers1 = new List<int>();
        List<int> numbers2 = new List<int>();

        while ((line = reader.ReadLine()) != null)
        {
            string[] integers = line.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            
            numbers1.Add(int.Parse(integers[0]));
            numbers2.Add(int.Parse(integers[1]));
        }
        numbers1.Sort();
        numbers2.Sort();
        int return_number = 0;
        for (int index = 0; index < numbers1.Count; index++) {
            return_number += Math.Abs(numbers1[index] - numbers2[index]);
        }
       return return_number;
    }
    return 0;
}




static int part2() {

    
    using (StreamReader reader = new StreamReader("input.txt"))
    {
        string line;
        List<int> numbers1 = new List<int>();
        Dictionary<int, int> count_dict = new Dictionary<int, int>();

        while ((line = reader.ReadLine()) != null)
        {
            string[] integers = line.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            
            numbers1.Add(int.Parse(integers[0]));
            int value = int.Parse(integers[1]);
            if (count_dict.ContainsKey(value)==true) {
                count_dict[value]++;
            } else {
               count_dict[value] = 1;
            }
        }
        int return_number = 0;
        foreach (int number in numbers1) {
            return_number += number * (count_dict.TryGetValue(number, out var value) ? value : 0);
        }
       return return_number;
    }
    return 0;
}

Console.WriteLine(part1());
Console.WriteLine(part2());

