using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day_1_part_2
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
                var fuel = CalculateFuelForMass(mass);

                await Console.Out.WriteLineAsync($"Require {fuel} fuel for {mass} mass");

                yield return fuel;
            }
        }

        private static int CalculateFuelForMass(int mass) {
            var fuel = (mass / 3) - 2;

            int fuelForFuel = fuel;
            while ((fuelForFuel = (fuelForFuel / 3) -2) > 0) {
                fuel += fuelForFuel;
            }

            return Math.Max(fuel, 0);
        }
    }
}
