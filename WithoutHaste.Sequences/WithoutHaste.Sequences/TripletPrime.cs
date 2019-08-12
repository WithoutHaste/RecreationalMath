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
			Sequence sexy = new SexyPrime(Max);
			Sequence twin = new TwinPrime(Max);
			Sequence cousin = new CousinPrime(Max);

			Intersection sexyAndTwin = sexy.Intersect(twin);
			Intersection sexyAndCousin = sexy.Intersect(cousin);
			Union triplet = sexyAndTwin.Union(sexyAndCousin);

			Numbers = triplet.Numbers;
		}

		public override string GetSaveToFolder()
		{
			return "Prime_Triplet";
		}
	}
}
