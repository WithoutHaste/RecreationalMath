using System;
using System.Collections.Generic;
using System.Linq;
using WithoutHaste.Sequences.Tools;

namespace WithoutHaste.Sequences
{
    /// <summary>
    /// A number N such that SPD(N) less than N. 
    /// </summary>
    public class Deficient : Sequence
    {
        /// <inheritdoc/>
        internal static new int[] TestNumbers = new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 13, 14, 15, 16, 17, 19, 21, 22, 23 };

        public Deficient(int max) : base(max)
        {
        }

        protected override void Generate()
        {
            for (var i = 1; i <= Max; i++)
            {
                if (Extensions.SumOfProperDivisors(i) < i)
                    Numbers.Add(i);
            }
        }

        public override string GetSaveToFolder()
        {
            return "Deficient";
        }
    }
}
