using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_2_part_2
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0) {
                Console.WriteLine("Must provide comma separated list or file!");
                return -1;
            }

            int[] instructions;

            if (File.Exists(args[0])) {
                instructions = ReadFile(args[0]).ToArray();
            } else {
                instructions = args[0].Split(',').Select(a => int.Parse(a)).ToArray();
            }

            int output;
            int noun = 0;
            int verb = 0;

            do {
                output = RunMachineWithParams(instructions.ToArray(), noun, verb);

                if (output == 19690720) {
                    Console.WriteLine($"Found noun {noun} and verb {verb} for output {output}!");
                    Console.WriteLine($"100 * {noun} + {verb} = {100 * noun + verb}");
                    break;
                } else {
                    Console.WriteLine($"Failed to find for noun {noun} and verb {verb}, output was {output}...");
                }

                if (noun < 99) noun++;
                else {
                    noun = 0;
                    verb++;
                    if (verb > 99) {
                        Console.WriteLine("Could not find a solution =(");
                        break;
                    }
                }

            } while(true);

            return output;
        }

        private static int RunMachineWithParams(int[] instructions, int noun, int verb) {
            instructions[1] = noun;
            instructions[2] = verb;

            return RunMachine(instructions.ToArray());
        }

        private static IEnumerable<int> ReadFile(string path)
        {
            using var reader = new StreamReader(path);
            var line = reader.ReadLine();
            return line.Split(",").Select(v => int.Parse(v));
        }

        private static int RunMachine(int[] instructions) {
            for (int address = 0; address < instructions.Length; address += 4)
            {
                var instruction = instructions[address];

                if (instruction == 99) {
                    break;
                }

                if (instructions.Length < address + 4) {
                    Console.WriteLine($"Invalid op codes line! {String.Join(",", instructions.Skip(address))}");
                    break;
                }

                var paramPos1 = instructions[address+1];
                var paramPos2 = instructions[address+2];
                
                if (paramPos1 >= instructions.Length || paramPos2 >= instructions.Length) {
                    Console.WriteLine("Abort -- out of bounds!");
                }

                var param1 = instructions[paramPos1];
                var param2 = instructions[paramPos2];
                var outPos = instructions[address+3];

                var output = instruction switch
                {
                    1 => param1 + param2,
                    2 => param1 * param2,
                    _ => -1
                };

                if (output == -1)
                    return -1;

                instructions[outPos] = output;

                var operStr = instruction == 1 ? "+" : "*";
                //Console.WriteLine($"{instruction},{paramPos1},{paramPos1},{outPos} ({param1} {operStr} {param2} = {output})");
            }

            //Console.WriteLine();
            //Console.WriteLine(String.Join(",", instructions));

            return instructions[0];
        }
    }
}
