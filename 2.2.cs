using System;
using System.Collections.Generic;
using System.IO;

class Day2Ex2
{
    public static void Run(string[] args)
    {
        var lines = File.ReadAllLines("passwords.txt");
        int count = 0;

        foreach (var line in lines)
        {
            string[] parts = line.Split(": ");
            string[] subparts = parts[0].Split(' ');
            string[] limits = subparts[0].Split('-');

            int first = int.Parse(limits[0]);
            int second = int.Parse(limits[1]);
            char check = subparts[1][0];
            string password = parts[1];

            bool valid1 = (password[first - 1] == check);
            bool valid2 = (password[second - 1] == check);
            if (valid1 ^ valid2)
            {
                count++;
                Console.WriteLine(line);
            }
        }

        Console.WriteLine(count);
    }
}
