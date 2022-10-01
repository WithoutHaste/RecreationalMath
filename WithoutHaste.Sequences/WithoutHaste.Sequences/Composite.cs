using System;
using System.Collections.Generic;
using System.Linq;
using WithoutHaste.Sequences.Tools;

namespace WithoutHaste.Sequences
{
    /// <summary>
    /// Has factors other than 1 and itself.
    /// So, not prime and not 1.
    /// </summary>
    public class Composite : Sequence
    {
        /// <inheritdoc/>
        internal static new int[] TestNumbers = new int[] { 4, 6, 8, 9, 10, 12, 14, 15, 16, 18, 20, 21, 22, 24, 25, 26, 27, 28, 30, 32, 33, 34, 35, 36, 38, 39, 40, 42, 44, 45, 46, 48, 49, 50, 51, 52, 54, 55, 56, 57, 58, 60, 62, 63, 64, 65, 66, 68, 69, 70, 72, 74, 75, 76, 77, 78, 80, 81, 82, 84, 85, 86, 87, 88, 90, 91, 92, 93, 94, 95, 96, 98, 99, 100 };

        public Composite(int max) : base(max)
        {
        }

        protected override void Generate()
        {
            Sequence primes = new SieveOfEratosthenes(Max);
            for (var i = 2; i <= Max; i++)
            {
                if (primes.Numbers.Contains(i))
                    continue;
                Numbers.Add(i);
            }
        }

        public override string GetSaveToFolder()
        {
            return "Composite";
        }
    }
}
