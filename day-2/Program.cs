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

            var opCodes = args[0].Split(',').Select(a => int.Parse(a)).ToArray();

            opCodes[1] = 12;
            opCodes[2] = 2;

            for (int i = 0; i < opCodes.Length; i += 4)
            {
                var oper = opCodes[i];

                if (oper == 99) {
                    break;
                }

                if (opCodes.Length < i + 4) {
                    Console.WriteLine($"Invalid op codes line! {String.Join(",", opCodes.Skip(i))}");
                    break;
                }

                var inPos1 = opCodes[i+1];
                var inPos2 = opCodes[i+2];
                
                var in1 = opCodes[inPos1];
                var in2 = opCodes[inPos2];
                var outPos = opCodes[i+3];

                opCodes[outPos] = oper switch
                {
                    1 => in1 + in2,
                    2 => in1 * in2,
                    _ => throw new NotImplementedException()
                };

                var operStr = oper == 1 ? "+" : "*";
                Console.WriteLine($"{oper},{inPos1},{inPos2},{outPos} ({in1} {operStr} {in2} = {opCodes[outPos]})");
            }

            Console.WriteLine(String.Join(",", opCodes));
        }
    }
}