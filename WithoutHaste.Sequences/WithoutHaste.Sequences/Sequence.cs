﻿namespace WithoutHaste.Sequences
{
	/// <summary>
	/// A list or category of integer numbers, generated by some rule.
	/// </summary>
	public abstract class Sequence
	{
		/// <summary>
		/// The maximum number that can be in the sequence.
		/// </summary>
		public int Max { get; private set; }
		/// <summary>
		/// Returns the full list of numbers, ordered least to greatest.
		/// </summary>
		public abstract int[] Numbers { get; }
		/// <summary>
		/// List of numbers from other sources to test against.
		/// </summary>
		internal static int[] TestNumbers;

		public Sequence(int max)
		{
			Max = max;
			Generate();
		}

		/// <summary>
		/// Generates the full list of numbers.
		/// </summary>
		protected abstract void Generate();
	}
}
