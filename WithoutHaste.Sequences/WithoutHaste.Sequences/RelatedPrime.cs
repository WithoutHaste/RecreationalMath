using System.Collections.Generic;
using System.Linq;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// There is no standard name for this category.
	/// A prime where p + x is also prime, or p - x is also prime (both sides of pair are saved).
	/// Includes twin primes, cousin primes, and sexy primes.
	/// </summary>
	public abstract class RelatedPrime : Sequence
	{
		/// <summary>
		/// The constant to add to each prime. Ex: Cousin Primes use x = 4.
		/// </summary>
		protected virtual int X { get; }

		public RelatedPrime(int max) : base(max)
		{
		}

		protected override void Generate()
		{
			Sequence primes = new SieveOfEratosthenes(Max + X);
			foreach(int prime in primes.InRange(LastNumber, Max))
			{
				int p2 = prime + X;
				int p3 = prime - X;
				if(primes.Contains(p2) || primes.Contains(p3))
				{
					Numbers.Add(prime);
				}
			}
		}
	}
}
