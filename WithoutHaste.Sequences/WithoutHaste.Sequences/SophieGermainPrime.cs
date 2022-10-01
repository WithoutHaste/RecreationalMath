using System;
using System.Collections.Generic;
using System.Linq;
using WithoutHaste.Sequences.Tools;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Where p and 2p+1 are both prime. 
	/// </summary>
	public class SophieGermainPrime : Sequence
	{
        /// <inheritdoc/>
        internal static new int[] TestNumbers = new int[] { 2, 3, 5, 11, 23, 29, 41, 53, 83, 89, 113, 131, 173, 179, 191, 233, 239, 251, 281, 293, 359, 419, 431, 443, 491, 509, 593, 641, 653, 659, 683, 719, 743, 761, 809, 911, 953 };

        public SophieGermainPrime(int max) : base(max)
        {
        }

        protected override void Generate()
        {
            Sequence primes = new SieveOfEratosthenes((Max * 2) + 1);
            foreach (int prime in primes.InRange(1, Max))
            {
                if (primes.Contains((prime * 2) + 1))
                {
                    Numbers.Add(prime);
                }
            }
        }

        public override string GetSaveToFolder()
        {
            return "Prime_SophieGermain";
        }
    }
}
