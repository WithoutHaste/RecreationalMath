using System;
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
		internal static new int[] TestNumbers = new int[] { 2, 3, 5, 7, 11, 13, 19, 23, 29, 31, 37, 43, 47, 53, 59, 61, 67, 71, 79, 101, 107, 127, 131, 139, 149, 151, 157, 173, 181, 191, 197, 199, 211, 223, 229, 263, 269, 277, 283, 311, 317, 331, 347, 349 };

		public HiggsPrime(int max) : base(max)
		{
		}

		protected override void Generate()
		{
			Sequence primes = new SieveOfEratosthenes(Max);
			BigInteger productOfHiggsPrimes = ProductOfNumbers();
			foreach(int prime in primes.InRange(LastNumber, Max))
			{
				int totient = prime - 1;
				BigInteger squaredProduct = productOfHiggsPrimes * productOfHiggsPrimes;
				if(squaredProduct % totient == 0)
				{
					Numbers.Add(prime);
					productOfHiggsPrimes *= prime;
				}
			}
		}

		/// <summary>
		/// Returns the product of all <see cref='Numbers'/> so far.
		/// </summary>
		/// <returns></returns>
		private BigInteger ProductOfNumbers()
		{
			BigInteger product = new BigInteger(1);
			foreach(int number in Numbers)
			{
				product = product * number;
			}
			return product;
		}

		public override string GetSaveToFolder()
		{
			return "Prime_Higgs";
		}
	}
}
