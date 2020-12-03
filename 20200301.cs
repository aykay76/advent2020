using System;
using System.Collections.Generic;
using System.IO;

class Year2020Day3Ex1
{
    public static void Run(string[] args)
    {
        string[] lines = File.ReadAllLines("202003.txt");
        int x = 0;
        int y = 0;
        int trees = 0;

        while (y < lines.Length)
        {
            Console.WriteLine($"{x}, {y}");
            try
            {
                if (lines[y][x] == '#') trees++;
                x = (x + 3) % lines[y].Length;
                y++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{x}, {y}");
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        Console.WriteLine(trees);
    }
}
