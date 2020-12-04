using System;
using System.Collections.Generic;
using System.IO;

class Year2020Day4Ex1
{
    public static void Run(string[] args)
    {
        string[] lines = File.ReadAllLines("202004.txt");

        int i = 0;
        int valid = 0;
        Dictionary<string, string> passport = new Dictionary<string, string>();
        do
        {
            while (i < lines.Length && lines[i].Length > 0)
            {
                string[] parts = lines[i].Split(' ');
                foreach (string part in parts)
                {
                    string[] temp = part.Split(':');
                    passport[temp[0]] = temp[1];
                }
                i++;
            }

            // check password
            if (passport.Keys.Count == 8 || (passport.Keys.Count == 7 && !passport.ContainsKey("cid")))
                valid++;

            Console.WriteLine($"{valid} {passport.Keys.Count}");
            
            passport = new Dictionary<string, string>();
            i++;
        }
        while (i < lines.Length);

        Console.WriteLine(valid);
    }
}
