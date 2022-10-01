using System;
using System.Collections.Generic;
using System.Linq;
using WithoutHaste.Sequences.Tools;

namespace WithoutHaste.Sequences
{
    /// <summary>
    /// N is divisible by the number of its factors
    /// aka Refactorable
    /// Ex: 2, because it has 2 factors [1, 2]
    /// </summary>
    public class Tau : Sequence
    {
        /// <inheritdoc/>
        internal static new int[] TestNumbers = new int[] { 1, 2, 8, 9, 12, 18, 24, 36, 40, 56, 60, 72, 80, 84, 88, 96, 104, 108 };

        public Tau(int max) : base(max)
        {
        }

        protected override void Generate()
        {
            for (var i = 1; i <= Max; i++)
            {
                var divisorCount = Extensions.Divisors(i).Count();
                if (i % divisorCount == 0)
                    Numbers.Add(i);
            }
        }

        public override string GetSaveToFolder()
        {
            return "Tau";
        }
    }
}
