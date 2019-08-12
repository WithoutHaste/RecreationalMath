using System;
using System.Collections.Generic;
using System.Linq;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Primes p such that neither p−2 nor p+2 is prime. I.e. Prime but not a <see cref='TwinPrime'/>.
	/// 2, 23, 37, 47, 53, 67, 79, 83, 89, 97, 113, 127, 131, 157, 163, 167, 173, 211, 223, 233, 251, 257, 263, 277, 293, 307, 317, 331, 337, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 439, 443, 449, 457, 467, 479, 487, 491, 499, 503, 509, 541, 547, 557, 563, 577, 587, 593, 607, 613, 631, 647, 653, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 839, 853, 863, 877, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997 
	/// </summary>
	public class IsolatedPrime : Difference
	{
		public IsolatedPrime(int max, string loadFromFolder) : base(max, loadFromFolder)
		{
		}

		public IsolatedPrime(int max)
		{
			Sequence primes = new SieveOfEratosthenes(max);
			Sequence twinPrimes = new TwinPrime(max);
			Difference difference = primes.Difference(twinPrimes);

			saveToFolder = "Prime_Isolated";
			Max = difference.Max;
			Numbers = difference.Numbers;
		}
	}
}
