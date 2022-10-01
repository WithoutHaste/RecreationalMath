using System;
using System.Collections.Generic;
using System.Linq;
using WithoutHaste.Sequences.Tools;

namespace WithoutHaste.Sequences
{
    /// <summary>
    /// A number N such that SPD(N) > N. 
    ///   Sum of Proper Divisors: aka Aliquot Sum: SPD(N)
    ///   For example, SPD(12) = 1 + 2 + 3 + 4 + 6 = 16
    /// </summary>
    public class Abundant : Sequence
    {
        /// <inheritdoc/>
        internal static new int[] TestNumbers = new int[] { 12, 18, 20, 24, 30, 36, 40, 42, 48, 54, 56, 60, 66, 70, 72, 78, 80, 84, 88, 90, 96, 100 };

        public Abundant(int max) : base(max)
        {
        }

        protected override void Generate()
        {
            for (var i = 1; i <= Max; i++)
            {
                if (Extensions.SumOfProperDivisors(i) > i)
                    Numbers.Add(i);
            }
        }

        public override string GetSaveToFolder()
        {
            return "Abundant";
        }
    }
}
