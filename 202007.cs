using System;
using System.Collections.Generic;
using System.IO;

class Year2020Day7
{
    public static void Check1(List<string> matches, Dictionary<string, List<string>> links, string inner)
    {
        foreach (string outer in links[inner])
        {
            if (!matches.Contains(outer))
            {
                matches.Add(outer);
            }

            if (links.ContainsKey(outer))
            {
                Check1(matches, links, outer);
            }
        }
    }

    public static void Ex1()
    {
        string[] lines = File.ReadAllLines("202007.txt");
        Dictionary<string, List<string>> links = new Dictionary<string, List<string>>();
        List<string> matches = new List<string>();

        foreach (string line in lines)
        {
            string[] p1 = line.Split(" bags contain ");
            string outer = p1[0];

            if (p1[1] != "no other bags.")
            {
                string[] inners = p1[1].Replace(".", "").Split(", ");
                foreach (string inner in inners)
                {
                    string[] p2 = inner.Split(' ');
                    string innerBag = p2[1] + " " + p2[2];

                    if (links.ContainsKey(innerBag))
                    {
                        links[innerBag].Add(outer);
                    }
                    else
                    {
                        links[innerBag] = new List<string>() { outer };
                    }
                }
            }
        }

        if (links.ContainsKey("shiny gold"))
        {
            Check1(matches, links, "shiny gold");
        }
        Console.WriteLine(matches.Count);
    }

    public static int Check2(Dictionary<string, Dictionary<string, int>> links, string outer)
    {
        int bags = 0;

        foreach (var inner in links[outer])
        {
            if (links.ContainsKey(inner.Key))
            {
                bags += inner.Value * Check2(links, inner.Key) + inner.Value;
            }
            else
            {
                bags += inner.Value;
            }
        }

        return bags;
    }

    public static void Ex2()
    {
        string[] lines = File.ReadAllLines("202007.txt");
        Dictionary<string, Dictionary<string, int>> links = new Dictionary<string, Dictionary<string, int>>();
        List<string> matches = new List<string>();

        foreach (string line in lines)
        {
            string[] p1 = line.Split(" bags contain ");
            string outer = p1[0];

            if (p1[1] != "no other bags.")
            {
                string[] inners = p1[1].Replace(".", "").Split(", ");
                foreach (string inner in inners)
                {
                    string[] p2 = inner.Split(' ');
                    string innerBag = p2[1] + " " + p2[2];

                    if (links.ContainsKey(outer))
                    {
                        links[outer].Add(innerBag, int.Parse(p2[0]));
                    }
                    else
                    {
                        links[outer] = new Dictionary<string, int>() { { innerBag, int.Parse(p2[0]) } };
                    }
                }
            }
        }

        int bags = 0;
        if (links.ContainsKey("shiny gold"))
        {
            bags += Check2(links, "shiny gold");
        }
        Console.WriteLine(bags);
    }
}
