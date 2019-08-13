using System;
using System.Collections.Generic;
using System.Linq;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Where (p, p+2, p+6, p+8) are all prime. 
	/// (5, 7, 11, 13), (11, 13, 17, 19), (101, 103, 107, 109), (191, 193, 197, 199), (821, 823, 827, 829), (1481, 1483, 1487, 1489), (1871, 1873, 1877, 1879), (2081, 2083, 2087, 2089), (3251, 3253, 3257, 3259), (3461, 3463, 3467, 3469), (5651, 5653, 5657, 5659), (9431, 9433, 9437, 9439)  
	/// </summary>
	public class QuadrupletPrime : RelatedPrime
	{
		/// <inheritdoc/>
		internal static new int[] TestNumbers = new int[] { 5, 7, 11, 13, 17, 19, 101, 103, 107, 109, 191, 193, 197, 199, 821, 823, 827, 829, 1481, 1483, 1487, 1489, 1871, 1873, 1877, 1879, 2081, 2083, 2087, 2089 };

		public QuadrupletPrime(int max) : base(max)
		{
		}

		protected override void Generate()
		{
			Sequence sexy = new SexyPrime(Max + 8);
			Sequence twin = new TwinPrime(Max + 8);

			int prevPrevPrevTerm = 0;
			int prevPrevTerm = 0;
			int prevTerm = 0;
			foreach(int prime in sexy.Numbers)
			{
				if(prime > Max)
					break;
				if(sexy.Contains(prime + 6))
				{
					if(twin.Contains(prime + 2) && twin.Contains(prime + 8))
					{
						AddNumber(prime, prevPrevTerm, prevTerm);
						AddNumber(prime + 2, prevPrevTerm, prevTerm);
						AddNumber(prime + 6, prevPrevTerm, prevTerm);
						AddNumber(prime + 8, prevPrevTerm, prevTerm);
						prevPrevPrevTerm = prime + 2;
						prevPrevTerm = prime + 6;
						prevTerm = prime + 8;
					}
				}
			}
		}

		private void AddNumber(int number, int prevPrevTerm, int prevTerm)
		{
			if(number > Max)
				return;
			if(number == prevPrevTerm || number == prevTerm)
				return;
			Numbers.Add(number);
		}

		public override string GetSaveToFolder()
		{
			return "Prime_Quadruplet";
		}
	}
}
