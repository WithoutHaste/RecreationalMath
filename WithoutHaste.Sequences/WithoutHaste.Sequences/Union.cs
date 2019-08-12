using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// The union of two sequences. I.e. the elements from A combined with the elements of B, without duplicating values.
	/// Only stores numbers up to the lowest Max value in either sequence.
	/// </summary>
	/// <remarks>
	/// Does not store the original sequences, just the result.
	/// </remarks>
	public class Union : Sequence
	{
		protected string saveToFolder { get; set; }

		public Union()
		{
		}

		public Union(int max, string loadFromFolder) : base(max, loadFromFolder)
		{
			saveToFolder = loadFromFolder;
		}

		public Union(Sequence sequenceA, Sequence sequenceB)
		{
			saveToFolder = String.Format("({0}Union{1})", sequenceA.GetSaveToFolder(), sequenceB.GetSaveToFolder());
			Max = Math.Min(sequenceA.Max, sequenceB.Max);
			Numbers = sequenceA.Numbers.Union(sequenceB.Numbers).Where(n => n <= Max).OrderBy(n => n).ToList();
		}

		public override string GetSaveToFolder()
		{
			return saveToFolder;
		}
	}
}
