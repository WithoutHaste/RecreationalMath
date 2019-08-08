using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace WithoutHaste.Sequences.Tools
{
	/// <summary>
	/// The sieve of Eratosthenes is a fast computer-based method of finding prime numbers.
	/// </summary>
	/// <remarks>
	/// This sieve can find all primes up to the maximum of <see cref='BigInteger'/>.
	/// </remarks>
	public static class SieveOfEratosthenes
	{
		private static readonly bool PRIME = false;
		private static readonly bool NOT_PRIME = true;
		private static readonly int TWO_BILLION = 2000000000; //less than Int32.MaxValue so index can go past end of array without overflow

		/// <summary>
		/// Returns a list of all primes from 1 to <paramref name='max'/>.
		/// </summary>
		/// <param name="max">Highest number to check for prime.</param>
		public static List<BigInteger> GetPrimes(BigInteger max)
		{
			int sieveCount = (int)(max / new BigInteger(TWO_BILLION)) + 1;
			List<bool[]> sieves = new List<bool[]>();
			for(int i = 0; i < sieveCount; i++)
			{
				sieves.Add(new bool[Int32.MaxValue]);
			}
			sieves[0][0] = NOT_PRIME;
			sieves[0][1] = NOT_PRIME;

			BigInteger trueIndex = new BigInteger(2);
			int sieveIndex = 0;
			int index = 2;
			while(trueIndex < max)
			{
				if(sieves[sieveIndex][index] == PRIME)
				{
					ApplyPrimeToSieves(sieves, trueIndex, sieveIndex, index);
				}
				trueIndex++;
				index++;
				if(index >= sieves[sieveIndex].Length)
				{
					index = 0;
					sieveIndex++;
				}
			}

			return ExtractPrimesFromSieves(sieves, max);
		}

		/// <summary>
		/// Returns a list of all primes from 1 to <paramref name='max'/>.
		/// First attempts to load pre-generated primes from file.
		/// </summary>
		/// <param name="max">Highest number to check for prime.</param>
		/// <param name="directory">Absolute or relative path to directory containing pre-generated primes.</param>
		public static List<BigInteger> GetPrimes(BigInteger max, string directory)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Update sieve with new prime.
		/// </summary>
		/// <param name="sieves"></param>
		/// <param name="trueIndex">The actual prime number</param>
		/// <param name="sieveIndex">Index in <paramref name="sieves"/> of actual prime.</param>
		/// <param name="index">Index in <c>sieves[sieveIndex]</c> of actual prime.</param>
		private static void ApplyPrimeToSieves(List<bool[]> sieves, BigInteger trueIndex, int sieveIndex, int index)
		{
			BigInteger bigIndex = new BigInteger(index);
			while(true)
			{
				bigIndex += trueIndex; //increment by prime
				while(sieveIndex < sieves.Count && bigIndex >= sieves[sieveIndex].Length)
				{
					bigIndex -= sieves[sieveIndex].Length;
					sieveIndex++;
				}
				if(sieveIndex >= sieves.Count)
					break;
				sieves[sieveIndex][(int)bigIndex] = NOT_PRIME;
			}
		}

		/// <summary>
		/// Returns a list of primes recorded in the sieves.
		/// </summary>
		/// <param name="sieves"></param>
		/// <returns></returns>
		private static List<BigInteger> ExtractPrimesFromSieves(List<bool[]> sieves, BigInteger max)
		{
			List<BigInteger> primes = new List<BigInteger>();

			BigInteger trueIndex = 2;
			int sieveIndex = 0;
			int index = 2;
			while(trueIndex <= max && sieveIndex < sieves.Count)
			{
				if(sieves[sieveIndex][index] == PRIME)
				{
					primes.Add(trueIndex);
				}
				trueIndex++;
				index++;
				if(index >= sieves[sieveIndex].Length)
				{
					sieveIndex++;
					index = 0;
				}
			}

			return primes;
		}
	}
}
