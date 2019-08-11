using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// The numbers that survive the lucky sieving process.
	///	Let 1 be the first lucky number, and consider only the odd numbers.
	///	Keep the next surviving number, which is 3. Remove all remaining numbers in a 3-divisible position.
	///	Keep the next surviving number, which is 7. Remove all remaining numbers in a 7-divisible position.
	///	And continue like that forever.
	/// </summary>
	public class Lucky : Sequence
	{
		/// <inheritdoc/>
		internal static new int[] TestNumbers = new int[] { 1, 3, 7, 9, 13, 15, 21, 25, 31, 33, 37, 43, 49, 51, 63, 67, 69, 73, 75, 79, 87, 93, 99, 105, 111, 115, 127, 129, 133, 135, 141, 151, 159, 163, 169, 171, 189, 193, 195, 201, 205, 211, 219, 223, 231, 235, 237, 241, 259 };

		public Lucky(int max) : base(max)
		{
		}

		protected override void Generate()
		{
			List<int> numbers = new List<int>();
			for(int n = 1; n <= Max; n+=2) //initialize with odd numbers
				numbers.Add(n);
			for(int i = 1; i < numbers.Count; i++)
			{
				int n = numbers[i];
				for(int j = GreatestMultipleBelow(n, numbers.Count); j >= n; j-=n)
				{
					numbers.RemoveAt(j-1);
				}
			}
			Numbers = numbers;
		}

		/// <summary>
		/// Returns the greatest multiple of <paramref name='n'/> that is below <paramref name='limit'/>.
		/// </summary>
		private int GreatestMultipleBelow(int n, int limit)
		{
			if(n > limit)
				return 0;
			int multiple = n;
			while(multiple + n < limit)
				multiple += n;
			return multiple;
		}

		protected override string GetSaveToFolder()
		{
			return "Lucky";
		}
	}
}
