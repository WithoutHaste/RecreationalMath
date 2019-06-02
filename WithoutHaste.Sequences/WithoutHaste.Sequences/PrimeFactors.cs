using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Calculates the prime factors of integers.
	/// </summary>
	public static class PrimeFactors
	{
		/// <summary>
		/// Dict[N] = ordered list of distinct prime factors of N
		/// </summary>
		private static Dictionary<BigInteger, List<BigInteger>> CacheFactors = new Dictionary<BigInteger, List<BigInteger>>() { { 1, new List<BigInteger>() } };

		/// <summary>
		/// Returns an ordered array of the distinct prime factors of <paramref name='n'/>.
		/// </summary>
		/// <exception cref='ArgumentException'><paramref name='n'/> must be greater than 0.</exception>
		public static BigInteger[] Lookup(BigInteger n)
		{
			Factorize(n);
			return CacheFactors[n].ToArray();
		}

		/// <summary>
		/// Use method similar to Seive Of Eristothenes to quickly factorize all numbers from 1 to <paramref name='max'/>.
		/// Starts with an empty cache.
		/// </summary>
		public static void QuickFactorize(BigInteger max)
		{
			Debug.WriteLine("Quick factorize to " + max);

			CacheFactors = new Dictionary<BigInteger, List<BigInteger>>() { { 1, new List<BigInteger>() } };

			bool[] seiveOfEristothenes = new bool[(long)max + 1]; //true is prime //todo what if seive is longer than int or long allow?
			for(BigInteger i = 0; i < seiveOfEristothenes.Length; i++)
			{
				seiveOfEristothenes[(long)i] = true;
			}
			seiveOfEristothenes[0] = false;
			seiveOfEristothenes[1] = false;
			for(BigInteger i = 2; i < seiveOfEristothenes.Length; i++)
			{
				if(seiveOfEristothenes[(long)i] == false)
					continue;
				if(!CacheFactors.ContainsKey(i))
					CacheFactors[i] = new List<BigInteger>() { i };
				for(BigInteger j = i + i; j < seiveOfEristothenes.Length; j += i)
				{
					seiveOfEristothenes[(long)j] = false;
					if(!CacheFactors.ContainsKey(j))
						CacheFactors[j] = new List<BigInteger>();
					CacheFactors[j].Add(i);
				}
			}
		}

		private static void Factorize(BigInteger n)
		{
			if(n <= 0)
				throw new ArgumentException("Number must be greater than 0.");
			if(CacheFactors.ContainsKey(n))
				return;

			Debug.WriteLine("Factorize " + n);

			Prime prime;
			if(Prime.CacheMax < n)
				prime = new Prime(n + 1000); //generate a lot at once to save time - expected repeated queries
			else
				prime = new Prime(n); //must go up to n in case it is prime

			if(prime.Contains(n))
			{
				CacheFactors[n] = new List<BigInteger>() { n };
				return;
			}
			List<BigInteger> primeFactors = new List<BigInteger>();
			BigInteger nWorking = n + 0; //clone
			foreach(BigInteger p in prime.Numbers)
			{
				if(nWorking == 1)
					break;
				if(CacheFactors.ContainsKey(nWorking))
				{
					primeFactors.AddRange(CacheFactors[nWorking]);
					break;
				}
				if(nWorking % p == 0)
				{
					primeFactors.Add(p);
					while(nWorking % p == 0)
						nWorking = nWorking / p;
				}
			}
			CacheFactors[n] = primeFactors.Distinct().OrderBy(x => x).ToList();
		}
	}
}
