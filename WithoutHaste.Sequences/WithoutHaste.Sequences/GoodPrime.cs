using System;
using System.Collections.Generic;
using System.Linq;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// A prime whose square is greater than the product of any two primes at +i and -i positions from the prime
	/// Or: p_n for which p_n^2 > p_n−i * p_n+i for all 1 ≤ i ≤ n−1, where p_n is the nth prime. 
	/// 
	/// 2, being the first prime, does not count because there are no smaller primes to multiply against.
	/// </summary>
	public class GoodPrime : Sequence
	{
		/// <inheritdoc/>
		public override long[] Numbers { get { return (long[])numbers.Clone(); } }
		private long[] numbers;

		/// <inheritdoc/>
		internal static new long[] TestNumbers = new long[] { 5, 11, 17, 29, 37, 41, 53, 59, 67, 71, 97, 101, 127, 149, 179, 191, 223, 227, 251, 257, 269, 307 };

		public GoodPrime(long max) : base(max)
		{
		}

		protected override void Generate()
		{
			Prime prime = new Prime(Max);
			List<long> goodPrimes = new List<long>();
			foreach(long p in prime.Numbers)
			{
				if(IsGoodPrime(p, prime))
					goodPrimes.Add(p);
			}
			numbers = goodPrimes.ToArray();
		}

		private bool IsGoodPrime(long p, Prime prime)
		{
			if(p == 2)
				return false;
			long pIndex = Array.IndexOf(prime.Numbers, p);
			long pSquared = p * p;
			for(int i = 1; pIndex - i >= 0; i++)
			{
				while(prime.Count <= pIndex + i)
				{
					prime.IncreaseMax(prime.Max + 10000);
				}

				if(pSquared <= prime[pIndex-i] * prime[pIndex+i])
					return false;
			}
			return true;
		}
	}
}
