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
		internal static long SumOfDigits(this long n)
		{
			long sum = 0;
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

		/// <summary>
		/// Returns the sum of the squares of the digits of <paramref name='n'/>.
		/// </summary>
		internal static long SumOfSquaresOfDigits(this long n)
		{
			long sum = 0;
			foreach(char c in n.ToString())
			{
				switch(c)
				{
					case '0': break;
					case '1': sum += 1*1; break;
					case '2': sum += 2*2; break;
					case '3': sum += 3*3; break;
					case '4': sum += 4*4; break;
					case '5': sum += 5*5; break;
					case '6': sum += 6*6; break;
					case '7': sum += 7*7; break;
					case '8': sum += 8*8; break;
					case '9': sum += 9*9; break;
				}
			}
			return sum;
		}

		/// <summary>
		/// Primorial is similar to Factorial. Symbol: n# instead of n!
		/// There are two conflicting definitions. The one used here is:
		///   n# = the product of all primes less than or equal to n
		/// </summary>
		/// <remarks>
		/// Assumes <paramref name='primes'/> contains all the necessary primes.
		/// </remarks>
		internal static long Primorial(this long n, long[] primes)
		{
			long primorial = 1;
			for(long i = primes.Length - 1; i >= 0; i--)
			{
				if(primes[i] <= n)
				{
					primorial *= primes[i];
				}
			}
			return primorial;
		}
	}
}
