using System;
using System.Collections.Generic;
using System.Linq;


namespace WithoutHaste.Sequences
{
	/*
	/// <summary>
	/// If you take a number, and take the sum of the squares of its digits,
	/// and then you repeat that
	/// if you reach 1, the original number (all others in the route) is Happy.
	/// If you enter a loop, none of those numbers are Happy.
	/// </summary>
	public class Happy : Sequence
	{
		/// <inheritdoc/>
		public override BigInteger[] Numbers { get { return (BigInteger[])numbers.Clone(); } }
		private BigInteger[] numbers;

		/// <inheritdoc/>
		internal static new BigInteger[] TestNumbers = new BigInteger[] { 1, 7, 10, 13, 19, 23, 28, 31, 32, 44, 49, 68, 70, 79, 82, 86, 91, 94, 97, 100, 103, 109, 129, 130, 133, 139, 167, 176, 188, 190, 192, 193, 203, 208, 219, 226, 230, 236, 239, 262, 263, 280, 291, 293, 301, 302, 310, 313, 319, 320, 326, 329, 331, 338, 356, 362, 365, 367, 368, 376, 379, 383, 386, 391, 392, 397, 404, 409, 440, 446, 464, 469, 478, 487, 490, 496, 536, 556, 563, 565, 566 };

		public Happy(BigInteger max) : base(max)
		{
		}

		protected override void Generate()
		{
			List<BigInteger> happys = new List<BigInteger>();
			List<BigInteger> notHappys = new List<BigInteger>();
			for(BigInteger i = 1; i <= Max; i++)
			{
				BigInteger n = i;
				List<BigInteger> route = new List<BigInteger>() { n };
				while(true)
				{
					if(n == 1 || happys.Contains(n))
					{
						happys.AddRange(route);
						break;
					}
					n = n.SumOfSquaresOfDigits();
					if(route.Contains(n) || notHappys.Contains(n))
					{
						notHappys.AddRange(route);
						break;
					}
					route.Add(n);
				}
			}
			numbers = happys.Distinct().OrderBy(n => n).ToArray();
		}
	}
	*/
}
