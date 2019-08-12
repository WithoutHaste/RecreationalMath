using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// The intersection of two sequences. I.e. the elements that occur in both sequences.
	/// Only stores numbers up to the lowest Max value in either sequence.
	/// </summary>
	/// <remarks>
	/// Does not store the original sequences, just the result.
	/// </remarks>
	public class Intersection : Sequence
	{
		protected string saveToFolder { get; set; }

		public Intersection(int max, string loadFromFolder) : base(max, loadFromFolder)
		{
			saveToFolder = loadFromFolder;
		}

		public Intersection(Sequence sequenceA, Sequence sequenceB)
		{
			saveToFolder = String.Format("({0}Intersect{1})", sequenceA.GetSaveToFolder(), sequenceB.GetSaveToFolder());
			Max = Math.Min(sequenceA.Max, sequenceB.Max);
			Numbers = sequenceA.Numbers.Intersect(sequenceB.Numbers).Where(n => n <= Max).OrderBy(n => n).ToList();
		}

		public override string GetSaveToFolder()
		{
			return saveToFolder;
		}
	}
}
