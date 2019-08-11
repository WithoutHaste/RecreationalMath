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
		internal static new int[] TestNumbers = new int[] { 13, 17, 31, 37, 71, 73, 79, 97, 107, 113, 149, 157, 167, 179, 199, 311, 337, 347, 359, 389, 701, 709, 733, 739, 743, 751, 761, 769, 907, 937, 941, 953, 967, 971, 983, 991 };

		public EmirpPrime(int max) : base(max)
		{
		}

		protected override void Generate()
		{
			List<int> primes = (new SieveOfEratosthenes(Max * 10)).Numbers; //going order of magnitude higher than prime because reversing prime could end up with a higher number; ex: 17 => 71
			int maxPreloaded = (Numbers.Count > 0) ? Numbers.Last() : 0;
			for(int i = 0; i < primes.Count && primes[i] <= Max; i++)
			{
				int prime = primes[i];
				if(prime <= maxPreloaded)
					continue;
				if(IsEmirpPrime(prime, primes))
					Numbers.Add(prime);
			}
		}

		private bool IsEmirpPrime(int prime, List<int> primes)
		{
			string s = String.Join("", prime.ToString().ToArray().Select(c => c.ToString()).Reverse().ToArray());
			int p2 = Int32.Parse(s);
			if(p2 == prime)
				return false;
			return (primes.Contains(p2));
		}

		protected override string GetSaveToFolder()
		{
			return "Prime_Emirp";
		}
	}
}
