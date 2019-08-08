using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace WithoutHaste.Sequences.Tools
{
	internal static class Extensions
	{
		/// <summary>
		/// Returns the sum of the digits of <paramref name='n'/>.
		/// </summary>
		internal static BigInteger SumOfDigits(this BigInteger n)
		{
			BigInteger sum = 0;
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
		internal static BigInteger SumOfSquaresOfDigits(this BigInteger n)
		{
			BigInteger sum = 0;
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
		internal static BigInteger Primorial(this BigInteger n, BigInteger[] primes)
		{
			BigInteger primorial = 1;
			for(BigInteger i = primes.Length - 1; i >= 0; i--)
			{
				if(primes[(long)i] <= n) //todo what if i is bigger than long?
				{
					primorial *= primes[(long)i];
				}
			}
			return primorial;
		}
		/*
				/// <summary>
				/// Cototient(n) = n - Totient(n)
				/// </summary>
				/// <exception cref='ArgumentException'><paramref name='n'/> must be greater than 1.</exception>
				internal static BigInteger Cototient(this BigInteger n)
				{
					if(n <= 1)
						throw new ArgumentException("Number must be greater than 1.");
					return n - Totient(n);
				}
		*/
		/*
				/// <summary>
				/// Only valid for integers greater than 1.
				/// Totient (or phi(N)) means the number of positive integers (including 1) less than N that are coprime to N
				/// </summary>
				/// <remarks>
				/// The totient of a prime number N = N - 1
				/// </remarks>
				/// <exception cref='ArgumentException'><paramref name='n'/> must be greater than 1.</exception>
				internal static BigInteger Totient(this BigInteger n)
				{
					if(n <= 1)
						throw new ArgumentException("Number must be greater than 1.");
					//tried checking for n being prime here, but it slowed down noticably
					//Prime prime = new Prime(n);
					//if(prime.Contains(n))
					//	return n - 1;
					BigInteger count = 0;
					for(BigInteger x = 1; x < n; x++)
					{
						if(n.Coprime(x))
							count++;
					}
					return count;
				}
		*/
		/*
				/// <summary>
				/// <paramref name='a'/> and <paramref name='b'/> are coprime if they share no prime factors.
				/// </summary>
				internal static bool Coprime(this BigInteger a, BigInteger b)
				{
					BigInteger[] primeFactorsA = PrimeFactors.Lookup(a);
					BigInteger[] primeFactorsB = PrimeFactors.Lookup(b);
					foreach(BigInteger p in primeFactorsA)
					{
						if(primeFactorsB.Contains(p))
							return false;
					}
					return true;
				}
		*/
		/// <summary>
		/// If <pararef name="s"/> starts with a number, it is parsed into an integer and returned. Zero is returned by default.
		/// </summary>
		internal static int GetStartingNumber(string s)
		{
			Match match = Regex.Match(s, @"^\d+");
			int result = 0;
			if(!match.Success)
				return result;
			Int32.TryParse(match.Value, out result);
			return result;
		}
	}
}
