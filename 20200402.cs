using System;
using System.Collections.Generic;
using System.IO;

class Year2020Day4Ex2
{
    public static void Run(string[] args)
    {
        string[] lines = File.ReadAllLines("202004.txt");
        List<string> validEyeColours = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

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
            {
                bool ok = true;
                int byr = int.Parse(passport["byr"]);
                if (byr < 1920 || byr > 2002) ok = false;

                int iyr = int.Parse(passport["iyr"]);
                if (iyr < 2010 || iyr > 2020) ok = false;

                int eyr = int.Parse(passport["eyr"]);
                if (eyr < 2020 || eyr > 2030) ok = false;

                if (passport["hgt"].EndsWith("cm"))
                {
                    int hgt = int.Parse(passport["hgt"].Substring(0, passport["hgt"].Length - 2));
                    if (hgt < 150 || hgt > 193) ok = false;
                }
                else if (passport["hgt"].EndsWith("in"))
                {
                    int hgt = int.Parse(passport["hgt"].Substring(0, passport["hgt"].Length - 2));
                    if (hgt < 59 || hgt > 76) ok = false;
                }
                else
                {
                    ok = false;
                }

                if (passport["hcl"].Length == 7)
                {
                    if (passport["hcl"][0] == '#')
                    {
                        for (int j = 1; j < passport["hcl"].Length; j++)
                        {
                            char c = passport["hcl"][j];
                            if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f'))
                            {

                            }
                            else
                            {
                                ok = false;
                            }
                        }
                    }
                    else
                    {
                        ok = false;
                    }
                }
                else
                {
                    ok = false;
                }

                if (!validEyeColours.Contains(passport["ecl"])) ok = false;

                if (passport["pid"].Length == 9)
                {

                }
                else
                {
                    ok = false;
                }

                if (ok) valid++;
            }

            Console.WriteLine($"{valid} {passport.Keys.Count}");
            
            passport = new Dictionary<string, string>();
            i++;
        }
        while (i < lines.Length);

        Console.WriteLine(valid);
    }
}
