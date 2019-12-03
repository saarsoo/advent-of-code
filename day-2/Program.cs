using System;
using System.Linq;

namespace day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) {
                Console.WriteLine("Must provide comma separated list!");
                return;
            }

            var instructions = args[0].Split(',').Select(a => int.Parse(a)).ToArray();

            instructions[1] = 12;
            instructions[2] = 2;

            for (int i = 0; i < instructions.Length; i += 4)
            {
                var oper = instructions[i];

                if (oper == 99) {
                    break;
                }

                if (instructions.Length < i + 4) {
                    Console.WriteLine($"Invalid op codes line! {String.Join(",", instructions.Skip(i))}");
                    break;
                }

                var inPos1 = instructions[i+1];
                var inPos2 = instructions[i+2];
                
                var in1 = instructions[inPos1];
                var in2 = instructions[inPos2];
                var outPos = instructions[i+3];

                instructions[outPos] = oper switch
                {
                    1 => in1 + in2,
                    2 => in1 * in2,
                    _ => throw new NotImplementedException()
                };

                var operStr = oper == 1 ? "+" : "*";
                Console.WriteLine($"{oper},{inPos1},{inPos2},{outPos} ({in1} {operStr} {in2} = {instructions[outPos]})");
            }

            Console.WriteLine(String.Join(",", instructions));
        }
    }
}