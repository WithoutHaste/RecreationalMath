using System;
using System.Collections.Generic;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// The sieve of Eratosthenes is a fast computer-based method of finding prime numbers.
	/// </summary>
	/// <remarks>
	/// This sieve can find all primes up to the maximum of <see cref='int'/>.
	/// </remarks>
	public class SieveOfEratosthenes : Prime
	{
		private static readonly bool PRIME = false;
		private static readonly bool NOT_PRIME = true;
		/// <remarks>
		/// Must be less than Int32.MaxValue so that index does not overflow on iteration.
		/// Must also be low enough to not immediately run out of memory.
		/// </remarks>
		private static readonly int MAX_SIEVE_LENGTH = 100000000;

		private List<bool[]> sieves;
		private int trueIndex;
		private int sieveIndex;
		private int index;

		/// <inheritdoc/>
		public SieveOfEratosthenes(int max) : base(max)
		{
		}

		/// <inheritdoc/>
		protected override void Initialize()
		{
		}

		/// <inheritdoc/>
		protected override void Generate()
		{
			var SIEVE_LENGTH = Math.Min(Max, MAX_SIEVE_LENGTH);

			int sieveCount = (int)(Max / SIEVE_LENGTH) + 1;
			sieves = new List<bool[]>();
			for(int i = 0; i < sieveCount; i++)
			{
				sieves.Add(new bool[SIEVE_LENGTH]);
			}
			sieves[0][0] = NOT_PRIME;
			sieves[0][1] = NOT_PRIME;

			trueIndex = 2;
			sieveIndex = 0;
			index = 2;

			while(trueIndex < Max)
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
			Numbers = ExtractPrimesFromSieves();
		}

		/// <summary>
		/// Update sieve with new prime.
		/// </summary>
		/// <param name="sieves"></param>
		/// <param name="prime">The actual prime number</param>
		/// <param name="sieveIndex">Index in <paramref name="sieves"/> of actual prime.</param>
		/// <param name="index">Index in <c>sieves[sieveIndex]</c> of actual prime.</param>
		private void ApplyPrimeToSieves(List<bool[]> sieves, int prime, int sieveIndex, int index)
		{
			int forwardIndex = index;
			while(true)
			{
				forwardIndex += prime;
				while(sieveIndex < sieves.Count && forwardIndex >= sieves[sieveIndex].Length)
				{
					forwardIndex -= sieves[sieveIndex].Length;
					sieveIndex++;
				}
				if(sieveIndex >= sieves.Count)
					break;
				sieves[sieveIndex][(int)forwardIndex] = NOT_PRIME;
			}
		}

		/// <summary>
		/// Update sieve with new prime.
		/// </summary>
		/// <param name="sieves"></param>
		/// <param name="prime">The actual prime number</param>
		private void ApplyPrimeToSieves(List<bool[]> sieves, int prime)
		{
			while(true)
			{
				if(sieveIndex >= sieves.Count)
					return;
				if(trueIndex == prime)
				{
					ApplyPrimeToSieves(sieves, prime, sieveIndex, index);
					return;
				}
				index++;
				trueIndex++;
				if(index >= sieves[sieveIndex].Length)
				{
					index = 0;
					sieveIndex++;
				}
			}
		}

		/// <summary>
		/// Returns a list of primes recorded in the sieves.
		/// </summary>
		private List<int> ExtractPrimesFromSieves()
		{
			List<int> primes = new List<int>();

			int trueIndex = 2;
			int sieveIndex = 0;
			int index = 2;
			while(trueIndex <= Max && sieveIndex < sieves.Count)
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
