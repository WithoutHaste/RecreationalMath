﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// A Higgs prime, named after Denis Higgs, is a prime number with a totient (one less than the prime) that evenly divides the square of the product of the smaller Higgs primes.
	/// 
	/// Totient (or phi(N)) means (for an integer N greater than 1) the number of positive integers (including 1) less than N that are coprime to N
	/// Coprime means they share no prime factors
	/// Therefore, the totient of a prime number N = N - 1
	/// 
	/// Primes p for which p−1 divides the square of the product of all earlier terms. 
	/// </summary>
	public class HiggsPrime : Sequence
	{
		/// <inheritdoc/>
		public override long[] Numbers { get { return (long[])numbers.Clone(); } }
		private long[] numbers;

		/// <inheritdoc/>
		internal static new long[] TestNumbers = new long[] { 2, 3, 5, 7, 11, 13, 19, 23, 29, 31, 37, 43, 47, 53, 59, 61, 67, 71, 79, 101, 107, 127, 131, 139, 149, 151, 157, 173, 181, 191, 197, 199, 211, 223, 229, 263, 269, 277, 283, 311, 317, 331, 347, 349 };

		public HiggsPrime(long max) : base(max)
		{
		}

		protected override void Generate()
		{
			// Primes p for which p−1 divides the square of the product of all earlier terms
			long[] primes = new Prime(Max).Numbers;
			List<long> higgsPrimes = new List<long>();
			long productOfHiggsPrimes = 1;
			foreach(long p in primes)
			{
				long totient = p - 1;
				long squaredProduct = productOfHiggsPrimes * productOfHiggsPrimes;
				if(squaredProduct % totient == 0)
				{
					higgsPrimes.Add(p);
					productOfHiggsPrimes *= p;
				}
			}
			numbers = higgsPrimes.ToArray();
		}
	}
}