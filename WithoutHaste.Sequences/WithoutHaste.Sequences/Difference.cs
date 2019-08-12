using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// The difference of two sequences. I.e. the elements from A that are not in B.
	/// Only stores numbers up to the lowest Max value in either sequence.
	/// </summary>
	/// <remarks>
	/// Does not store the original sequences, just the result.
	/// </remarks>
	public class Difference : Sequence
	{
		protected string saveToFolder { get; set; }

		public Difference()
		{
		}

		public Difference(int max, string loadFromFolder) : base(max, loadFromFolder)
		{
			saveToFolder = loadFromFolder;
		}

		public Difference(Sequence sequenceA, Sequence sequenceB)
		{
			saveToFolder = String.Format("({0}Except{1})", sequenceA.GetSaveToFolder(), sequenceB.GetSaveToFolder());
			Max = Math.Min(sequenceA.Max, sequenceB.Max);
			Numbers = sequenceA.Numbers.Except(sequenceB.Numbers).Where(n => n <= Max).OrderBy(n => n).ToList();
		}

		public override string GetSaveToFolder()
		{
			return saveToFolder;
		}
	}
}
