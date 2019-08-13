using System;
using System.Collections.Generic;
using System.Linq;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Where (p, p+2, p+6) or (p, p+4, p+6) are all prime.
	/// It isn't possible to have a set of primes (p, p+2, p+4) since one of any three sequential odd numbers will be a multiple of 3 and therefore not prime.
	/// (5, 7, 11), (7, 11, 13), (11, 13, 17), (13, 17, 19), (17, 19, 23), (37, 41, 43), (41, 43, 47), (67, 71, 73), (97, 101, 103), (101, 103, 107), (103, 107, 109), (107, 109, 113), (191, 193, 197), (193, 197, 199), (223, 227, 229), (227, 229, 233), (277, 281, 283), (307, 311, 313), (311, 313, 317), (347, 349, 353)
	/// </summary>
	public class TripletPrime : RelatedPrime
	{
		/// <inheritdoc/>
		internal static new int[] TestNumbers = new int[] { 5, 7, 11, 13, 17, 19, 23, 37, 41, 43, 47, 67, 71, 73, 97, 101, 103, 107, 109, 113, 191, 193, 197, 199, 223, 227, 229, 233, 277, 281, 283 };

		public TripletPrime(int max) : base(max)
		{
		}

		protected override void Generate()
		{
			Sequence sexy = new SexyPrime(Max + 6);
			Sequence twin = new TwinPrime(Max + 6);
			Sequence cousin = new CousinPrime(Max + 6);

			int prevPrevTerm = 0;
			int prevTerm = 0;
			foreach(int prime in sexy.Numbers)
			{
				if(prime > Max)
					break;
				if(sexy.Contains(prime + 6))
				{
					if(twin.Contains(prime + 2))
					{
						AddNumber(prime, prevPrevTerm, prevTerm);
						AddNumber(prime + 2, prevPrevTerm, prevTerm);
						AddNumber(prime + 6, prevPrevTerm, prevTerm);
						prevPrevTerm = prime + 2;
						prevTerm = prime + 6;
					}
					else if(cousin.Contains(prime + 4))
					{
						AddNumber(prime, prevPrevTerm, prevTerm);
						AddNumber(prime + 4, prevPrevTerm, prevTerm);
						AddNumber(prime + 6, prevPrevTerm, prevTerm);
						prevPrevTerm = prime + 4;
						prevTerm = prime + 6;
					}
				}
			}
		}

		private void AddNumber(int number, int prevPrevTerm, int prevTerm)
		{
			if(number == prevPrevTerm || number == prevTerm)
				return;
			Numbers.Add(number);
		}

		public override string GetSaveToFolder()
		{
			return "Prime_Triplet";
		}
	}
}
