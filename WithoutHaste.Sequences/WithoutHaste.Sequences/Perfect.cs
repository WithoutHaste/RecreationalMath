using System;
using System.Collections.Generic;
using System.Linq;
using WithoutHaste.Sequences.Tools;

namespace WithoutHaste.Sequences
{
    /// <summary>
    /// A number N such that SPD(N) = N. 
    /// </summary>
    public class Perfect : Sequence
    {
        /// <inheritdoc/>
        internal static new int[] TestNumbers = new int[] { 6, 28, 496 };

        public Perfect(int max) : base(max)
        {
        }

        protected override void Generate()
        {
            for (var i = 1; i <= Max; i++)
            {
                if (Extensions.SumOfProperDivisors(i) == i)
                    Numbers.Add(i);
            }
        }

        public override string GetSaveToFolder()
        {
            return "Perfect";
        }
    }
}
