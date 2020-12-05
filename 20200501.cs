using System;
using System.Collections.Generic;
using System.IO;

class Year2020Day5Ex1
{
    public static void Run(string[] args)
    {
        string[] lines = File.ReadAllLines("202005.txt");

        int highest = 0;

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

            int id = row * 8 + seat;
            highest = Math.Max(id, highest);
        }

        Console.WriteLine($"{highest}");
    }
}
