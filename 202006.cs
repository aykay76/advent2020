using System;
using System.Collections.Generic;
using System.IO;

class Year2020Day6
{
    public static void Ex1()
    {
        string[] lines = File.ReadAllLines("202006.txt");

        List<char> group = new List<char>();
        int sum = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            foreach (char c in lines[i])
            {
                if (!group.Contains(c)) group.Add(c);
            }

            if (lines[i].Length == 0)
            {
                Console.WriteLine(group.Count);
                sum += group.Count;

                group = new List<char>();
            }
        }

        Console.WriteLine(group.Count);
        sum += group.Count;

        Console.WriteLine(sum);
    }

    public static void Ex2()
    {
        string[] lines = File.ReadAllLines("202006.txt");

        int sum = 0;
        int inGroup = 0;
        Dictionary<char, int> answers = new Dictionary<char, int>();

        for (int i = 0; i < lines.Length; i++)
        {
            foreach (char c in lines[i])
            {
                if (answers.ContainsKey(c))
                {
                    answers[c]++;
                }
                else
                {
                    answers[c] = 1;
                }
            }

            if (lines[i].Length == 0)
            {
                foreach (char c in answers.Keys)
                {
                    if (answers[c] == inGroup)
                    {
                        sum++;
                    }
                }

                inGroup = 0;
                answers = new Dictionary<char, int>();
            }
            else
            {
                inGroup++;
            }
        }

        foreach (char c in answers.Keys)
        {
            if (answers[c] == inGroup)
            {
                sum++;
            }
        }

        Console.WriteLine(sum);
    }
}
