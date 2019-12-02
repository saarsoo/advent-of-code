using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day_1
{
    class Program
    {
        static async Task Main(string[] masses)
        {
            var fuelValues = CalculateFuelAsync(masses.Select(m => int.Parse(m)));
            await Console.Out.WriteLineAsync($"Total fuel: {await fuelValues.SumAsync()}");
        }

        private static async IAsyncEnumerable<int> CalculateFuelAsync(IEnumerable<int> masses) {
            foreach (var mass in masses) {
                 var fuel = (mass / 3) - 2;

                await Console.Out.WriteLineAsync($"({mass} / 3) - 2 = {fuel}");

                yield return fuel;
            }
        }
    }
}
