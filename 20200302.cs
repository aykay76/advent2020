using System;
using System.Collections.Generic;
using System.IO;

class Year2020Day3Ex2
{
    public static int CheckSlope(string[] lines, int r, int d)
    {
        int x = 0;
        int y = 0;
        int trees = 0;

        while (y < lines.Length)
        {
            try
            {
                if (lines[y][x] == '#') trees++;
                x = (x + r) % lines[y].Length;
                y += d;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{x}, {y}");
                Console.WriteLine(ex.ToString());
            }
        }

        return trees;
    }

    public static void Run(string[] args)
    {
        string[] lines = File.ReadAllLines("202003.txt");

        int trees = CheckSlope(lines, 1, 1);
        trees *= CheckSlope(lines, 3, 1);
        trees *= CheckSlope(lines, 5, 1);
        trees *= CheckSlope(lines, 7, 1);
        trees *= CheckSlope(lines, 1, 2);

        Console.WriteLine(trees);
    }
}
