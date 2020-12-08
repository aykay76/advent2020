using System;
using System.Collections.Generic;
using System.IO;

class Year2020Day8
{
    public class Instruction
    {
        public string Operation { get; set; }
        public int Operand { get; set; }

        public void Switch()
        {
            if (Operation == "nop") 
            {
                Operation = "jmp";
            }
            else if (Operation == "jmp")
            {
                Operation = "nop";
            }
        }
    }

    public static bool Execute(List<Instruction> instructions, ref int acc)
    {
        List<int> executed = new List<int>();
        int cur = 0;
        while (cur < instructions.Count)
        {
            if (executed.Contains(cur))
            {
                return false;
            }
            else
            {
                string op = instructions[cur].Operation;
                executed.Add(cur);

                if (op == "nop")
                {
                    cur++;
                }
                else if (op == "acc")
                {
                    acc += instructions[cur].Operand;
                    cur++;
                }
                else if (op == "jmp")
                {
                    cur += instructions[cur].Operand;
                }
            }
        }

        return true;
    }

    public static void Ex1()
    {
        string[] lines = File.ReadAllLines("202008.txt");

        List<Instruction> instructions = new List<Instruction>();

        foreach (string line in lines)
        {
            string[] parts = line.Split(" ");
            instructions.Add(new Instruction() { Operation = parts[0], Operand = int.Parse(parts[1])});
        }

        int acc = 0;
        Execute(instructions, ref acc);
    }

    public static void Ex2()
    {
        string[] lines = File.ReadAllLines("202008.txt");

        List<Instruction> instructions = new List<Instruction>();

        foreach (string line in lines)
        {
            string[] parts = line.Split(" ");
            instructions.Add(new Instruction() { Operation = parts[0], Operand = int.Parse(parts[1])});
        }

        int acc = 0;
        if (Execute(instructions, ref acc) == false)
        {
            for (int i = 0; i < instructions.Count; i++)
            {
                instructions[i].Switch();

                acc = 0;
                if (Execute(instructions, ref acc))
                {
                    Console.WriteLine($"Success: {acc}");
                }

                instructions[i].Switch();
            }
        }
    }
}
