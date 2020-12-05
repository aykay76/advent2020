using System;
using System.Collections.Generic;
using System.IO;

class Year2020Day5Ex2
{
    public static void Run(string[] args)
    {
        string[] lines = File.ReadAllLines("202005.txt");

        int highest = 0;

        SortedDictionary<int, List<int>> rows = new SortedDictionary<int, List<int>>();

        foreach (string line in lines)
        {
            int row = 0;
            int seat = 0;

            for (int i = 0; i < 7; i++)
            {
                if (line[i] == 'B')
                {
                    row = row | (1 << (6 - i));
                }
            }
            for (int i = 7; i < 10; i++)
            {
                if (line[i] == 'R')
                {
                    seat = seat | (1 << (9 - i));
                }
            }

            if (rows.ContainsKey(row))
            {
                rows[row].Add(seat);
            }
            else
            {
                rows[row] = new List<int>() { seat };
            }

            int id = row * 8 + seat;
            highest = Math.Max(id, highest);
        }

        foreach (int row in rows.Keys)
        {
            if (rows[row].Count < 8)
            {
                Console.WriteLine($"{rows[row]}");
            }
        }

        Console.WriteLine($"{66*8+6}");
    }
}
