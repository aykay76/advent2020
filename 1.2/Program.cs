﻿using System;
using System.Collections.Generic;
using System.IO;

namespace _1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("../costs.txt");
            List<int> costs = new List<int>();
            foreach (var line in lines)
            {
                costs.Add(int.Parse(line));
            }

            costs.Sort();

            for (int i = 0; i < costs.Count; i++)
            {
                int a = costs[i];

                for (int j = i; j < costs.Count; j++)
                {
                    int b = costs[j];

                    for (int k = j; k < costs.Count; k++)
                    {
                        int c = costs[k];

                        if (a + b + c == 2020)
                        {
                            Console.WriteLine($"{a}, {b}, {c}: Add to 2020, multiply to {a * b * c}");
                        }
                    }
                }
            }
        }
    }
}
