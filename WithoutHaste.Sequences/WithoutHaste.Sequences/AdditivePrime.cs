using System;
using System.Collections.Generic;
using System.Linq;
using WithoutHaste.Sequences.Tools;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Prime number where sum of digits is also a prime number.
	/// </summary>
	public class AdditivePrime : Sequence
	{
		/// <inheritdoc/>
		internal static new int[] TestNumbers = new int[] { 2, 3, 5, 7, 11, 23, 29, 41, 43, 47, 61, 67, 83, 89, 101, 113, 131, 137, 139, 151, 157, 173, 179, 191, 193, 197, 199, 223, 227, 229, 241, 263, 269, 281, 283, 311, 313, 317, 331, 337, 353, 359, 373, 379, 397, 401, 409, 421, 443, 449 };

		public AdditivePrime(int max) : base(max)
		{
		}

		protected override void Generate()
		{
			List<int> primes = (new SieveOfEratosthenes(Max)).Numbers;
			int maxPreloaded = (Numbers.Count > 0) ? Numbers.Last() : 0;
			for(int i = 0; i < primes.Count; i++)
			{
				int prime = primes[i];
				if(prime <= maxPreloaded)
					continue;
				int sumOfDigits = prime.SumOfDigits();
				if(primes.Contains(sumOfDigits)) //sum of digits is guaranteed to be equal or lesser number, so its in the prime collection
				{
					Numbers.Add(prime);
				}
			}
		}

		protected override string GetSaveToFolder()
		{
			return "Prime_Additive";
		}
	}
}
