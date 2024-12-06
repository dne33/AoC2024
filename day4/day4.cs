using System;
using System.Collections.Generic;
static int part1()
{
    using (StreamReader reader = new StreamReader("test.txt"))
    {
        string line;
        List<List<char> > letter_matrix = new List<List<char> >();
        while ((line = reader.ReadLine()) != null)
        {
            List<char> letters = line.ToList();
            letter_matrix.Add(letters);
        }
        int rowLength = letter_matrix.Count;
        int colLength = letter_matrix[0].Count;
        Console.Write(colLength);
        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                Console.WriteLine("cooked");
                Console.WriteLine("cooked");

            }
        }
        return 0;

    }
}




static int part2()
{
    return 0;
}

Console.WriteLine(part1());
Console.WriteLine(part2());

