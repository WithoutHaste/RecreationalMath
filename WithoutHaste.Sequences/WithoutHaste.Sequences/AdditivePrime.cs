﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Prime number where sum of digits is also a prime number.
	/// </summary>
	public class AdditivePrime : Sequence
	{
		/// <inheritdoc/>
		public override long[] Numbers { get { return (long[])numbers.Clone(); } }
		private long[] numbers;

		/// <inheritdoc/>
		internal static new long[] TestNumbers = new long[] { 2, 3, 5, 7, 11, 23, 29, 41, 43, 47, 61, 67, 83, 89, 101, 113, 131, 137, 139, 151, 157, 173, 179, 191, 193, 197, 199, 223, 227, 229, 241, 263, 269, 281, 283, 311, 313, 317, 331, 337, 353, 359, 373, 379, 397, 401, 409, 421, 443, 449 };

		public AdditivePrime(long max) : base(max)
		{
		}

		protected override void Generate()
		{
			long[] primes = new Prime(Max).Numbers;
			List<long> additivePrimes = new List<long>();
			foreach(long p in primes)
			{
				long sumOfDigits = p.SumOfDigits();
				if(primes.Contains(sumOfDigits))
				{
					additivePrimes.Add(p);
				}
			}
			numbers = additivePrimes.ToArray();
		}
	}
}
