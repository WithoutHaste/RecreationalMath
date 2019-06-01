using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WithoutHaste.Sequences;

namespace TestSequences
{
	[TestClass]
	public class TestSequences
	{
		/// <summary>
		/// Assert that the numbers generated are exactly equal to the expected results.
		/// </summary>
		private void TestSequence(Sequence sequence, long[] expected)
		{
			//act
			long[] results = sequence.Numbers;
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
			long[] expected = Prime.TestNumbers;
			Prime sequence = new Prime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestAdditivePrime()
		{
			//arrange
			long[] expected = AdditivePrime.TestNumbers;
			AdditivePrime sequence = new AdditivePrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestCircularPrime()
		{
			//arrange
			long[] expected = CircularPrime.TestNumbers;
			CircularPrime sequence = new CircularPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		#region RelativePrime

		[TestMethod]
		public void TestTwinPrime()
		{
			//arrange
			long[] expected = TwinPrime.TestNumbers;
			TwinPrime sequence = new TwinPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestCousinPrime()
		{
			//arrange
			long[] expected = CousinPrime.TestNumbers;
			CousinPrime sequence = new CousinPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestSexyPrime()
		{
			//arrange
			long[] expected = SexyPrime.TestNumbers;
			SexyPrime sequence = new SexyPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		#endregion

		[TestMethod]
		public void TestEmirpPrime()
		{
			//arrange
			long[] expected = EmirpPrime.TestNumbers;
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
			long[] expected = GoodPrime.TestNumbers;
			GoodPrime sequence = new GoodPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestHappy()
		{
			//arrange
			long[] expected = Happy.TestNumbers;
			Happy sequence = new Happy(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}
	}
}
