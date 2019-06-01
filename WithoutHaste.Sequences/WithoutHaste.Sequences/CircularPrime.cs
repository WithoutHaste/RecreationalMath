using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// A circular prime number is a number that remains prime on any cyclic rotation of its digits (in base 10). 
	/// 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, 97, 113, 131, 197, 199, 311, 337, 373, 719, 733, 919, 971, 991, 1193, 1931, 3119, 3779, 7793, 7937, 9311, 9377, 11939, 19391, 19937, 37199, 39119, 71993, 91193, 93719, 93911, 99371, 193939, 199933, 319993, 331999, 391939, 393919, 919393, 933199, 939193, 939391, 993319, 999331
	/// </summary>
	public class CircularPrime : Sequence
	{
		/// <inheritdoc/>
		public override BigInteger[] Numbers { get { return (BigInteger[])numbers.Clone(); } }
		private BigInteger[] numbers;

		/// <inheritdoc/>
		internal static new BigInteger[] TestNumbers = new BigInteger[] { 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, 97, 113, 131, 197, 199, 311, 337, 373, 719, 733, 919, 971, 991, 1193, 1931, 3119, 3779, 7793, 7937, 9311, 9377, 11939, 19391, 19937, 37199, 39119, 71993, 91193, 93719, 93911, 99371, 193939, 199933 };

		public CircularPrime(BigInteger max) : base(max)
		{
		}

		protected override void Generate()
		{
			BigInteger[] primes = new Prime(Max * 10).Numbers; //going order of magnitude higher than prime because rotating prime could end up with a higher number; ex: 17 => 71
			List<BigInteger> circularPrimes = new List<BigInteger>();
			foreach(BigInteger p in primes.Where(p => p <= Max))
			{
				if(IsCircularPrime(p, primes))
					circularPrimes.Add(p);
			}
			numbers = circularPrimes.ToArray();
		}

		private bool IsCircularPrime(BigInteger p, BigInteger[] primes)
		{
			if(p < 10)
				return true;
			string s = p.ToString();
			for(BigInteger i = 1; i < s.Length; i++)
			{
				s = s.Substring(1) + s.Substring(0, 1);
				BigInteger p2 = BigInteger.Parse(s);
				if(!primes.Contains(p2))
					return false;
			}
			return true;
		}
	}
}
