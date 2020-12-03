using System;
using System.Collections.Generic;
using System.IO;

class Year2015Day1Ex1
{
    public static void Run(string[] args)
    {
        string s = File.ReadAllText("2015.1.1.txt");
        int floor = 0;

        foreach (char c in s)
        {
            if (c == '(') floor++;
            else floor--;
        }

        Console.WriteLine(floor);
    }
}
