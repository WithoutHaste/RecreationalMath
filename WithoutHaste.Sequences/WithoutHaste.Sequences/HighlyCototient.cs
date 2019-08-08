using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace WithoutHaste.Sequences
{
	/*
	/// <summary>
	/// a highly cototient number is a positive integer k which is above 1 and has more solutions to the equation
	/// x - totient(x) = k
	/// than any other integer below k and above 1. 
	/// </summary>
	/// <remarks>
	/// Looking through examples on https://en.wikipedia.org/wiki/Highly_cototient_number
	/// it appears that you don't need to search higher than (k*k) for solutions to (x - totient(x) = k).
	/// I don't know why, though.
	/// </remarks>
	public class HighlyCototient : Sequence
	{
		/// <inheritdoc/>
		public override BigInteger[] Numbers { get { return (BigInteger[])numbers.Clone(); } }
		private BigInteger[] numbers;

		/// <inheritdoc/>
		internal static new BigInteger[] TestNumbers = new BigInteger[] { 2, 4, 8, 23, 35, 47, 59, 63, 83, 89, 113, 119, 167, 209, 269, 299, 329, 389, 419, 509, 629, 659, 779, 839, 1049, 1169, 1259, 1469, 1649, 1679, 1889 };

		public HighlyCototient(BigInteger max) : base(max)
		{
		}

		protected override void Generate()
		{
			PrimeFactors.QuickFactorize(Max * Max); //prep cache
			//Prime prime = new Prime(Max * Max); //prep cache

			List<BigInteger> highlyCototient = new List<BigInteger>();
			List<BigInteger> solutions = new List<BigInteger>(); //correlated to previous list; number of solutions

			Debug.WriteLine("Cache x - totient(x)");
			BigInteger[] xMinusTotient = new BigInteger[(int)(Max * Max)]; //list[x] = x - totient(x)
			for(BigInteger x = 2; x < xMinusTotient.Length; x++)
			{
				xMinusTotient[(int)x] = x - x.Totient();
			}

			for(BigInteger k = 2; k <= Max; k++)
			{
				Debug.WriteLine("Is " + k + " highly cototient?");
				BigInteger countSolutions = 0;
				for(BigInteger x = 2; x <= k*k; x++)
				{
					if(xMinusTotient[(int)x] == k) //TODO list length limited by int
						countSolutions++;
				}
				if(solutions.Count == 0 || countSolutions > solutions.Last())
				{
					highlyCototient.Add(k);
					solutions.Add(countSolutions);
				}
			}
			numbers = highlyCototient.ToArray();
		}
	}
	*/
}
