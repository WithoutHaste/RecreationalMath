using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Prime number where sum of digits is also a prime number.
	/// </summary>
	public class AdditivePrime : Sequence
	{
		/// <inheritdoc/>
		public override BigInteger[] Numbers { get { return (BigInteger[])numbers.Clone(); } }
		private BigInteger[] numbers;

		/// <inheritdoc/>
		internal static new BigInteger[] TestNumbers = new BigInteger[] { 2, 3, 5, 7, 11, 23, 29, 41, 43, 47, 61, 67, 83, 89, 101, 113, 131, 137, 139, 151, 157, 173, 179, 191, 193, 197, 199, 223, 227, 229, 241, 263, 269, 281, 283, 311, 313, 317, 331, 337, 353, 359, 373, 379, 397, 401, 409, 421, 443, 449 };

		public AdditivePrime(BigInteger max) : base(max)
		{
		}

		protected override void Generate()
		{
			BigInteger[] primes = new Prime(Max).Numbers;
			List<BigInteger> additivePrimes = new List<BigInteger>();
			foreach(BigInteger p in primes)
			{
				BigInteger sumOfDigits = p.SumOfDigits();
				if(primes.Contains(sumOfDigits))
				{
					additivePrimes.Add(p);
				}
			}
			numbers = additivePrimes.ToArray();
		}
	}
}
