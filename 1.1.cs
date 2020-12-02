using System;
using System.Collections.Generic;
using System.IO;

class Day1Ex1
{
    public static void Run(string[] args)
    {
        var lines = File.ReadAllLines("costs.txt");
        List<int> costs = new List<int>();
        foreach (var line in lines)
        {
            costs.Add(int.Parse(line));
        }

        costs.Sort();

        for (int i = 0; i < costs.Count; i++)
        {
            int a = costs[i];

            for (int j = costs.Count - 1; j >= i; j--)
            {
                int b = costs[j];

                if (a + b == 2020)
                {
                    Console.WriteLine($"{a}, {b}: Add to 2020, multiply to {a * b}");
                }
            }
        }
    }
}
