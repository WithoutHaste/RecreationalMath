﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// There is no standard name for this category.
	/// A prime where p + x is also prime, or p - x is also prime (both sides of pair are saved).
	/// Includes twin primes, cousin primes, and sexy primes.
	/// </summary>
	public abstract class RelativePrime : Sequence
	{
		/// <inheritdoc/>
		public override int[] Numbers { get { return (int[])numbers.Clone(); } }
		private int[] numbers;

		/// <summary>
		/// The constant to add to each prime. Ex: Cousin Primes use x = 4.
		/// </summary>
		protected virtual int X { get; }

		/// <param name="x">The constant to add to each prime. Ex: Cousin Primes use x = 4.</param>
		public RelativePrime(int max) : base(max)
		{
		}

		protected override void Generate()
		{
			int[] primes = new Prime(Max + X).Numbers;
			List<int> relativePrimes = new List<int>();
			foreach(int p in primes.Where(p => p <= Max))
			{
				int p2 = p + X;
				if(primes.Contains(p2))
				{
					relativePrimes.Add(p);
					if(p2 <= Max)
						relativePrimes.Add(p2);
				}
			}
			numbers = relativePrimes.Distinct().OrderBy(n => n).ToArray();
		}
	}
}
