using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Year2020Day9
{
    public static void Ex1()
    {
        string[] lines = File.ReadAllLines("202009.txt");

        long[] values = new long[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            values[i] = long.Parse(lines[i]);
        }

        for (int i = 25; i < values.Length; i++)
        {
            long sum = values[i];
            bool ok = false;

            for (int j = 0; j < i; j++)
            {
                for (int k = j; k < i; k++)
                {
                    if (values[j] + values[k] == sum)
                    {
                        ok = true;
                        break;
                    }
                }
            }

            if (!ok)
            {
                Console.WriteLine(values[i]);
                break;
            }
        }
    }

    public static void FindRange(long[] values, int preamble, int badindex, long badvalue, ref int start, ref int end)
    {
        for (int i = Math.Max(preamble, 0); i < badindex; i++)
        {
            long sum = values[i];

            for (int j = i + 1; j < badindex; j++)
            {
                sum += values[j];
                if (sum == badvalue)
                {
                    start = i;
                    end = j;
                    return;
                }
                else if (sum > badvalue)
                {
                    break;
                }
            }
        }
    }

    public static void Ex2()
    {
        string[] lines = File.ReadAllLines("202009.txt");

        long[] values = new long[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            values[i] = long.Parse(lines[i]);
        }

        int badindex = -1;
        long badvalue = -1;
        int preamble = 25;

        for (int i = preamble; i < values.Length; i++)
        {
            long sum = values[i];
            bool ok = false;

            for (int j = Math.Max(0, i - preamble); j < i - 1; j++)
            {
                for (int k = j + 1; k < i; k++)
                {
                    if (values[j] + values[k] == sum)
                    {
                        ok = true;
                        break;
                    }
                }
            }

            if (!ok)
            {
                badindex = i;
                badvalue = values[i];
                Console.WriteLine($"{badindex} => {badvalue}");
                break;
            }
        }

        int start = -1;
        int end = -1;
        FindRange(values, preamble, badindex, badvalue, ref start, ref end);

        List<long> range = new List<long>();
        for (int i = start; i < end; i++)
        {
            range.Add(values[i]);
        }

        Console.WriteLine(range.Min() + range.Max());
    }
}
