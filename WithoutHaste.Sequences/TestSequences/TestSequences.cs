using System;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WithoutHaste.Sequences;

namespace TestSequences
{
	/*
	[TestClass]
	public class TestSequences
	{
		/// <summary>
		/// Assert that the numbers generated are exactly equal to the expected results.
		/// </summary>
		private void TestSequence(Sequence sequence, BigInteger[] expected)
		{
			//act
			BigInteger[] results = sequence.Numbers;
			//assert
			Assert.AreEqual(expected.Length, results.Length);
			for(int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], results[i]);
			}
		}

		/// <summary>
		/// Assert that the numbers generated are exactly equal to the expected results.
		/// </summary>
		private void TestIntersection(Sequence sequenceA, Sequence sequenceB, BigInteger[] expected)
		{
			//act
			BigInteger[] results = sequenceA.Intersect(sequenceB);
			//assert
			Assert.AreEqual(expected.Length, results.Length);
			for(int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], results[i]);
			}
		}

		[TestMethod]
		public void TestPrime()
		{
			//arrange
			BigInteger[] expected = Prime.TestNumbers;
			Prime sequence = new Prime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestAdditivePrime()
		{
			//arrange
			BigInteger[] expected = AdditivePrime.TestNumbers;
			AdditivePrime sequence = new AdditivePrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestCircularPrime()
		{
			//arrange
			BigInteger[] expected = CircularPrime.TestNumbers;
			CircularPrime sequence = new CircularPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		#region RelativePrime

		[TestMethod]
		public void TestTwinPrime()
		{
			//arrange
			BigInteger[] expected = TwinPrime.TestNumbers;
			TwinPrime sequence = new TwinPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestCousinPrime()
		{
			//arrange
			BigInteger[] expected = CousinPrime.TestNumbers;
			CousinPrime sequence = new CousinPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestSexyPrime()
		{
			//arrange
			BigInteger[] expected = SexyPrime.TestNumbers;
			SexyPrime sequence = new SexyPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		#endregion

		[TestMethod]
		public void TestEmirpPrime()
		{
			//arrange
			BigInteger[] expected = EmirpPrime.TestNumbers;
			EmirpPrime sequence = new EmirpPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		//[TestMethod]
		//public void TestFortunate()
		//{
		//	//arrange
		//	long[] expected = Fortunate.TestNumbers;
		//	Fortunate sequence = new Fortunate(expected.Last());
		//	//act assert
		//	TestSequence(sequence, expected);
		//}

		[TestMethod]
		public void TestGoodPrime()
		{
			//arrange
			BigInteger[] expected = GoodPrime.TestNumbers;
			GoodPrime sequence = new GoodPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestHappy()
		{
			//arrange
			BigInteger[] expected = Happy.TestNumbers;
			Happy sequence = new Happy(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestHappyPrime()
		{
			//arrange
			BigInteger[] expected = new BigInteger[] { 7, 13, 19, 23, 31, 79, 97, 103, 109, 139, 167, 193, 239, 263, 293, 313, 331, 367, 379, 383, 397, 409, 487, 563, 617, 653, 673, 683, 709, 739, 761, 863, 881, 907, 937, 1009, 1033, 1039, 1093 };
			Happy happy = new Happy(expected.Last());
			Prime prime = new Prime(expected.Last());
			//act assert
			TestIntersection(happy, prime, expected);
		}

		[TestMethod]
		public void TestHiggsPrime()
		{
			//arrange
			BigInteger[] expected = HiggsPrime.TestNumbers;
			HiggsPrime sequence = new HiggsPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestHighlyCototient()
		{
			//arrange
			BigInteger[] expected = HighlyCototient.TestNumbers;
			HighlyCototient sequence = new HighlyCototient(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}
	}
	*/
}
