using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WithoutHaste.Sequences;
using WithoutHaste.Sequences.Tools;

namespace TestSequences
{
	[TestClass]
	public class TestSieveOfEratosthenes
	{
		[TestMethod]
		public void TestGetPrimes_To10()
		{
			//arrange
			BigInteger max = 10;
			//act
			List<BigInteger> primes = SieveOfEratosthenes.GetPrimes(max);
			//assert
			Assert.AreEqual(4, primes.Count);
			Assert.AreEqual(2, primes[0]);
			Assert.AreEqual(3, primes[1]);
			Assert.AreEqual(5, primes[2]);
			Assert.AreEqual(7, primes[3]);
		}

		[TestMethod]
		public void TestGetPrimes_To100()
		{
			//arrange
			BigInteger max = 100;
			//act
			List<BigInteger> primes = SieveOfEratosthenes.GetPrimes(max);
			//assert
			Assert.AreEqual(25, primes.Count);
			Assert.AreEqual(2, primes[0]);
			Assert.AreEqual(97, primes[primes.Count - 1]);
		}

		[TestMethod]
		public void TestGetPrimes_To104729()
		{
			//arrange
			BigInteger max = 104729;
			//act
			List<BigInteger> primes = SieveOfEratosthenes.GetPrimes(max);
			//assert
			Assert.AreEqual(10000, primes.Count);
			Assert.AreEqual(2, primes[0]);
			Assert.AreEqual(104729, primes[primes.Count - 1]);
		}

		[TestMethod]
		public void TestGetPrimes_MultipleSievesRequired()
		{
			//arrange
			BigInteger max = 150000000;
			//act
			List<BigInteger> primes = SieveOfEratosthenes.GetPrimes(max);
			//assert no error
		}
	}
}
