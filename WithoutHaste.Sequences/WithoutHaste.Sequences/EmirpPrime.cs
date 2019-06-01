using System;
using System.Collections.Generic;
using System.Linq;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Primes which become a different prime when their decimal digits are reversed. 
	/// 13, 17, 31, 37, 71, 73, 79, 97, 107, 113, 149, 157, 167, 179, 199, 311, 337, 347, 359, 389, 701, 709, 733, 739, 743, 751, 761, 769, 907, 937, 941, 953, 967, 971, 983, 991 
	/// </summary>
	public class EmirpPrime : Sequence
	{
		/// <inheritdoc/>
		public override long[] Numbers { get { return (long[])numbers.Clone(); } }
		private long[] numbers;

		/// <inheritdoc/>
		internal static new long[] TestNumbers = new long[] { 13, 17, 31, 37, 71, 73, 79, 97, 107, 113, 149, 157, 167, 179, 199, 311, 337, 347, 359, 389, 701, 709, 733, 739, 743, 751, 761, 769, 907, 937, 941, 953, 967, 971, 983, 991 };

		public EmirpPrime(long max) : base(max)
		{
		}

		protected override void Generate()
		{
			long[] primes = new Prime(Max * 10).Numbers; //going order of magnitude higher than prime because reversing prime could end up with a higher number; ex: 17 => 71
			List<long> emirpPrimes = new List<long>();
			foreach(long p in primes.Where(p => p <= Max))
			{
				if(IsEmirpPrime(p, primes))
					emirpPrimes.Add(p);
			}
			numbers = emirpPrimes.ToArray();
		}

		private bool IsEmirpPrime(long p, long[] primes)
		{
			string s = String.Join("", p.ToString().ToArray().Select(c => c.ToString()).Reverse().ToArray());
			long p2 = Int64.Parse(s);
			if(p2 == p)
				return false;
			return (primes.Contains(p2));
		}
	}
}
