using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WithoutHaste.Sequences;

namespace TestSequences
{
	[TestClass]
	public class TestSieveOfEratosthenes
	{
		[TestMethod]
		public void TestGetPrimes_To10()
		{
			//arrange
			int max = 10;
			//act
			Sequence sequence = new SieveOfEratosthenes(max);
			List<int> primes = sequence.Numbers;
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
			int max = 100;
			//act
			Sequence sequence = new SieveOfEratosthenes(max);
			List<int> primes = sequence.Numbers;
			//assert
			Assert.AreEqual(25, primes.Count);
			Assert.AreEqual(2, primes[0]);
			Assert.AreEqual(97, primes[primes.Count - 1]);
		}

		[TestMethod]
		public void TestGetPrimes_To104729()
		{
			//arrange
			int max = 104729;
			//act
			Sequence sequence = new SieveOfEratosthenes(max);
			List<int> primes = sequence.Numbers;
			//assert
			Assert.AreEqual(10000, primes.Count);
			Assert.AreEqual(2, primes[0]);
			Assert.AreEqual(104729, primes[primes.Count - 1]);
		}

		[TestMethod]
		public void TestGetPrimes_MultipleSievesRequired()
		{
			//arrange
			int max = 150000000;
			//act
			Sequence sequence = new SieveOfEratosthenes(max);
			List<int> primes = sequence.Numbers;
			//assert no error
		}
	}
}
