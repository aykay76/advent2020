using System;
using System.Collections.Generic;
using System.IO;

class Year2020Day8
{
    public static void Ex1()
    {
        string[] lines = File.ReadAllLines("202008.txt");

        List<KeyValuePair<string, int>> instructions = new List<KeyValuePair<string, int>>();

        foreach (string line in lines)
        {
            string[] parts = line.Split(" ");
            instructions.Add(new KeyValuePair<string, int>(parts[0], int.Parse(parts[1])));
        }

        List<int> executed = new List<int>();
        int acc = 0;
        int cur = 0;
        while (cur < instructions.Count)
        {
            if (executed.Contains(cur))
            {
                Console.WriteLine(acc);
                break;
            }
            else
            {
                string op = instructions[cur].Key;
                executed.Add(cur);

                if (op == "nop")
                {
                    cur++;
                }
                else if (op == "acc")
                {
                    acc += instructions[cur].Value;
                    cur++;
                }
                else if (op == "jmp")
                {
                    cur += instructions[cur].Value;
                }
            }
        }
    }

    public static void Ex2()
    {
        string[] lines = File.ReadAllLines("202008.txt");
    }
}
