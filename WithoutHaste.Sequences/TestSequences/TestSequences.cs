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
		private void TestSequence(Sequence sequence, int[] expected)
		{
			//act
			int[] results = sequence.Numbers.ToArray();
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
			int[] expected = Prime.TestNumbers;
			Prime sequence = new SieveOfEratosthenes(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestAdditivePrime()
		{
			//arrange
			int[] expected = AdditivePrime.TestNumbers;
			AdditivePrime sequence = new AdditivePrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestCircularPrime()
		{
			//arrange
			int[] expected = CircularPrime.TestNumbers;
			CircularPrime sequence = new CircularPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		#region RelatedPrime

		[TestMethod]
		public void TestTwinPrime()
		{
			//arrange
			int[] expected = TwinPrime.TestNumbers;
			TwinPrime sequence = new TwinPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestCousinPrime()
		{
			//arrange
			int[] expected = CousinPrime.TestNumbers;
			CousinPrime sequence = new CousinPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestSexyPrime()
		{
			//arrange
			int[] expected = SexyPrime.TestNumbers;
			SexyPrime sequence = new SexyPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestIsolatedPrime()
		{
			//arrange
			int[] expected = IsolatedPrime.TestNumbers;
			IsolatedPrime sequence = new IsolatedPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestTripletPrime()
		{
			//arrange
			int[] expected = TripletPrime.TestNumbers;
			TripletPrime sequence = new TripletPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		#endregion

		[TestMethod]
		public void TestEmirpPrime()
		{
			//arrange
			int[] expected = EmirpPrime.TestNumbers;
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

		//[TestMethod]
		//public void TestGoodPrime()
		//{
		//	//arrange
		//	int[] expected = GoodPrime.TestNumbers;
		//	GoodPrime sequence = new GoodPrime(expected.Last());
		//	//act assert
		//	TestSequence(sequence, expected);
		//}

		[TestMethod]
		public void TestHappy()
		{
			//arrange
			int[] expected = Happy.TestNumbers;
			Happy sequence = new Happy(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestLucky()
		{
			//arrange
			int[] expected = Lucky.TestNumbers;
			Lucky sequence = new Lucky(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		[TestMethod]
		public void TestHiggsPrime()
		{
			//arrange
			int[] expected = HiggsPrime.TestNumbers;
			HiggsPrime sequence = new HiggsPrime(expected.Last());
			//act assert
			TestSequence(sequence, expected);
		}

		//[TestMethod]
		//public void TestHighlyCototient()
		//{
		//	//arrange
		//	int[] expected = HighlyCototient.TestNumbers;
		//	HighlyCototient sequence = new HighlyCototient(expected.Last());
		//	//act assert
		//	TestSequence(sequence, expected);
		//}
	}
}
