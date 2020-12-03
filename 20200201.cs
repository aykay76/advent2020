using System;
using System.Collections.Generic;
using System.IO;

class Day2Ex1
{
    public static void Run(string[] args)
    {
        var lines = File.ReadAllLines("202002.txt");
        int count = 0;

        foreach (var line in lines)
        {
            string[] parts = line.Split(": ");
            string[] subparts = parts[0].Split(' ');
            string[] limits = subparts[0].Split('-');

            int min = int.Parse(limits[0]);
            int max = int.Parse(limits[1]);
            char check = subparts[1][0];
            string password = parts[1];

            int occurence = 0;
            foreach (char c in password)
            {
                if (c == check) occurence++;
            }
            if (occurence >= min && occurence <= max)
            {
                count++;
                Console.WriteLine(line);
            }
        }

        Console.WriteLine(count);
    }
}
