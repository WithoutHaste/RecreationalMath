using System;
using System.Collections.Generic;
using System.Linq;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// The Nth fortunate number is:
	///   Primorial = the product of the first N prime numbers
	///   M = the smallest integer greater than 1 such that Primorial + M is prime
	/// The Nth Fortunate number = M
	/// </summary>
	/// <remarks>
	/// This sequence produces duplicates and out of order numbers.
	/// <see cref='Fortunate.Numbers'/> will be distinct and in order.
	/// </remarks>
	/// <remarks>
	/// NOT IN USE - requires primes above the trillion mark - running out of memory for the seive
	/// </remarks>
	public class Fortunate : Sequence
	{
		/// <inheritdoc/>
		public override long[] Numbers { get { return (long[])numbers.Clone(); } }
		private long[] numbers;

		/// <inheritdoc/>
		internal static new long[] TestNumbers = new long[] { 3, 5, 7, 13, 17, 19, 23, 37, 47, 59, 61, 67, 71, 79, 89, 101, 103, 107, 109, 127, 151, 157, 163, 167, 191, 197, 199 };

		public Fortunate(long max) : base(max)
		{
		}

		protected override void Generate()
		{
			Prime prime = new Prime(Max);
			List<long> fortunates = new List<long>();
			while(true)
			{
				long n = fortunates.Count + 1;
				prime.IncreaseMax(n);
				long primorial = n.Primorial(prime.Numbers);
				long m = 2;
				while(true)
				{
					if(prime.Max < primorial + m)
						prime.IncreaseMax(primorial + m + 100);
					if(prime.Contains(primorial + m))
						break;
					m++;
				}
				if(m > Max)
					break;
				fortunates.Add(m);
			}
			numbers = fortunates.ToArray();
		}
	}
}
