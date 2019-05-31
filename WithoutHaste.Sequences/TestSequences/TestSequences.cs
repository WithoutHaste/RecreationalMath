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
			int[] results = sequence.Numbers;
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
			Prime sequence = new Prime(expected.Last());
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

		#region RelativePrime

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

		#endregion
	}
}
