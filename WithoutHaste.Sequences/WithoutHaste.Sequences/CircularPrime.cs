using System;
using System.Collections.Generic;
using System.Linq;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// A circular prime number is a number that remains prime on any cyclic rotation of its digits (in base 10). 
	/// 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, 97, 113, 131, 197, 199, 311, 337, 373, 719, 733, 919, 971, 991, 1193, 1931, 3119, 3779, 7793, 7937, 9311, 9377, 11939, 19391, 19937, 37199, 39119, 71993, 91193, 93719, 93911, 99371, 193939, 199933, 319993, 331999, 391939, 393919, 919393, 933199, 939193, 939391, 993319, 999331
	/// </summary>
	public class CircularPrime : Sequence
	{
		/// <inheritdoc/>
		internal static new int[] TestNumbers = new int[] { 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, 97, 113, 131, 197, 199, 311, 337, 373, 719, 733, 919, 971, 991, 1193, 1931, 3119, 3779, 7793, 7937, 9311, 9377, 11939, 19391, 19937, 37199, 39119, 71993, 91193, 93719, 93911, 99371, 193939, 199933 };

		public CircularPrime(int max) : base(max)
		{
		}

		protected override void Generate()
		{
			Sequence primes = new SieveOfEratosthenes(Max * 10); //going order of magnitude higher than prime because rotating prime could end up with a higher number; ex: 17 => 71
			foreach(int prime in primes.InRange(LastNumber, Max))
			{
				if(IsCircularPrime(prime, primes))
					Numbers.Add(prime);
			}
		}

		private bool IsCircularPrime(int prime, Sequence primes)
		{
			if(prime < 10)
				return true;
			string s = prime.ToString();
			if(ContainsEvenDigit(s))
				return false;
			for(int i = 1; i < s.Length; i++)
			{
				s = s.Substring(1) + s.Substring(0, 1);
				int p2 = Int32.Parse(s);
				if(!primes.Contains(p2))
					return false;
			}
			return true;
		}

		private bool ContainsEvenDigit(string s)
		{
			if(s.IndexOf('0') > -1) return true;
			if(s.IndexOf('2') > -1) return true;
			if(s.IndexOf('4') > -1) return true;
			if(s.IndexOf('6') > -1) return true;
			if(s.IndexOf('8') > -1) return true;
			return false;
		}

		public override string GetSaveToFolder()
		{
			return "Prime_Circular";
		}
	}
}
