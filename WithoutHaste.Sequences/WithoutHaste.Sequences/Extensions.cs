using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WithoutHaste.Sequences
{
	internal static class Extensions
	{
		/// <summary>
		/// Returns the sum of the digits of <paramref name='n'/>.
		/// </summary>
		internal static int SumOfDigits(this int n)
		{
			int sum = 0;
			foreach(char c in n.ToString())
			{
				switch(c)
				{
					case '0': break;
					case '1': sum += 1; break;
					case '2': sum += 2; break;
					case '3': sum += 3; break;
					case '4': sum += 4; break;
					case '5': sum += 5; break;
					case '6': sum += 6; break;
					case '7': sum += 7; break;
					case '8': sum += 8; break;
					case '9': sum += 9; break;
				}
			}
			return sum;
		}
	}
}
