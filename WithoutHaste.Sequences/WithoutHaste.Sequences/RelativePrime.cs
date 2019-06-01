using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// There is no standard name for this category.
	/// A prime where p + x is also prime, or p - x is also prime (both sides of pair are saved).
	/// Includes twin primes, cousin primes, and sexy primes.
	/// </summary>
	public abstract class RelativePrime : Sequence
	{
		/// <inheritdoc/>
		public override BigInteger[] Numbers { get { return (BigInteger[])numbers.Clone(); } }
		private BigInteger[] numbers;

		/// <summary>
		/// The constant to add to each prime. Ex: Cousin Primes use x = 4.
		/// </summary>
		protected virtual int X { get; }

		/// <param name="x">The constant to add to each prime. Ex: Cousin Primes use x = 4.</param>
		public RelativePrime(BigInteger max) : base(max)
		{
		}

		protected override void Generate()
		{
			BigInteger[] primes = new Prime(Max + X).Numbers;
			List<BigInteger> relativePrimes = new List<BigInteger>();
			foreach(BigInteger p in primes.Where(p => p <= Max))
			{
				BigInteger p2 = p + X;
				if(primes.Contains(p2))
				{
					relativePrimes.Add(p);
					if(p2 <= Max)
						relativePrimes.Add(p2);
				}
			}
			numbers = relativePrimes.Distinct().OrderBy(n => n).ToArray();
		}
	}
}
