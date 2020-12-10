using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Year2020Day10
{
    public static void Ex1()
    {
        string[] lines = File.ReadAllLines("202010.txt");
        List<int> adapters = new List<int>();

        foreach (string line in lines)
        {
            adapters.Add(int.Parse(line));
        }
        adapters.Sort();

        int ones = 1; // first adapter
        int threes = 1; // my device
        for (int i = 1; i < adapters.Count; i++)
        {
            if (adapters[i] - adapters[i - 1] == 1) ones++;
            if (adapters[i] - adapters[i - 1] == 3) threes++;
        }

        Console.WriteLine(ones * threes);
    }

    public static void Ex2()
    {
        string[] lines = File.ReadAllLines("202009.txt");

    }
}
