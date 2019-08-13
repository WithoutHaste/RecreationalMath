﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WithoutHaste.Sequences.Tools;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// A list or category of integer numbers, generated by some rule.
	/// </summary>
	public abstract class Sequence
	{
		/// <summary>
		/// The maximum number that can be in the sequence.
		/// </summary>
		public int Max { get; protected set; }
		/// <summary>
		/// Returns the full list of numbers, ordered least to greatest.
		/// </summary>
		public List<int> Numbers { get; protected set; }
		/// <summary>
		/// Returns element at 0-based index.
		/// </summary>
		/// <remarks>
		/// Does not protect against out of range errors.
		/// </remarks>
		public int this[int index] { get { return Numbers[index]; } }
		/// <summary>
		/// Returns the last number in the sequence, which will also be the highest number, or 0 if the sequence is empty.
		/// </summary>
		public int LastNumber { get { return (Numbers.Count == 0) ? 0 : Numbers.Last(); } }

		/// <summary>
		/// Set to true if loading pre-generated data was able to confirm that all elements up the Max were loaded.
		/// </summary>
		private bool loadReachedMax = false;

		/// <summary>
		/// List of numbers from other sources to test against.
		/// </summary>
		internal static int[] TestNumbers;

		public Sequence()
		{
		}

		/// <summary>
		/// Try loading pre-generated values first.
		/// If that is insufficient, generate the values.
		/// </summary>
		/// <param name="max"></param>
		public Sequence(int max)
		{
			Numbers = new List<int>();
			Max = max;
			Initialize();
			Load();
			if(loadReachedMax)
				return;
			Generate();
		}

		/// <summary>
		/// Only load pre-generated values. Do not attempt to generate values.
		/// </summary>
		/// <remarks>
		/// If the specified <paramref name='max'/> cannot be reached or exceeded, the recorded <see cref='Max'/> will be decreased to the highest confirmed value.
		/// </remarks>
		public Sequence(int max, string loadFromFolder)
		{
			Numbers = new List<int>();
			Max = max;
			Initialize();
			Load(loadFromFolder);
			if(!loadReachedMax)
			{
				Max = (Numbers.Count > 0) ? Numbers.Last() : 0;
			}
		}

		/// <summary>
		/// Initialize tracking and generator.
		/// Occurs before Load and Generate.
		/// </summary>
		protected virtual void Initialize()
		{
			//no statement
		}

		/// <summary>
		/// Generates the full list of numbers.
		/// </summary>
		protected virtual void Generate()
		{
			//no statement
		}

		/// <summary>
		/// Returns true if <paramref name="n"/> is in the sequence.
		/// </summary>
		public bool Contains(int n)
		{
			return Numbers.Contains(n);
		}

		/// <summary>
		/// Iterate through sequence, within the specified range.
		/// </summary>
		public IEnumerable<int> InRange(int min, int max)
		{
			for(int i = 0; i < Numbers.Count && Numbers[i] <= max; i++)
			{
				if(Numbers[i] < min)
					continue;
				yield return Numbers[i];
			}
		}

		/// <summary>
		/// Returns an intersection of the sequences.
		/// </summary>
		public Intersection Intersect(Sequence other)
		{
			return new Intersection(this, other);
		}

		/// <summary>
		/// Returns the difference of the sequences: this minus <paramref name='other'/>.
		/// </summary>
		public Difference Difference(Sequence other)
		{
			return new Difference(this, other);
		}

		/// <summary>
		/// Returns the union of the sequences.
		/// </summary>
		public Union Union(Sequence other)
		{
			return new Union(this, other);
		}

		/// <summary>
		/// Only saves files if loading data from file was insufficient.
		/// </summary>
		public void SaveIfNecessary()
		{
			if(loadReachedMax)
				return;
			Save();
		}

		/// <summary>
		/// Save sequence to file(s).
		/// </summary>
		/// <remarks>
		/// Files are saved in binary format to save space.
		/// It is one Int32 after another, with nothing between them.
		/// Therefore, the largest sequence element that can be saved is Int32.MaxValue.
		/// </remarks>
		/// <remarks>
		/// Does not remove old files.
		/// </remarks>
		public void Save()
		{
			string path = Path.Combine(Settings.SaveToDirectory, GetSaveToFolder());
			Directory.CreateDirectory(path);

			int range = Settings.SaveRangePerFile;
			int min = 1;
			List<List<int>> segments = BreakSequenceIntoSegments(range);
			for(int i = 0; i < segments.Count; i++)
			{
				List<int> segment = segments[i];
				int rangeMax = min + range - 1;
				if(i == segments.Count - 1)
					rangeMax = Max;
				string filename = String.Format("{0}to{1}{2}", min, rangeMax, Settings.IntegerFileExtension);
				using(BinaryWriter writer = new BinaryWriter(File.Open(Path.Combine(path, filename), FileMode.Create))) //create or overwrite
				{
					foreach(int number in segment)
					{
						writer.Write(number);
					}
				}
				string textFilename = String.Format("{0}to{1}.txt", min, rangeMax);
				using(StreamWriter writer = new StreamWriter(Path.Combine(path, textFilename)))
				{
					foreach(int number in segment)
					{
						writer.WriteLine(number);
					}
				}
				min += range;
			}
		}

		/// <summary>
		/// Breaks sequence into segments to save to files.
		/// </summary>
		private List<List<int>> BreakSequenceIntoSegments(int range)
		{
			List<List<int>> segments = new List<List<int>>();
			List<int> nextSegment = new List<int>();
			int segmentMax = range;
			for(int i = 0; i < this.Numbers.Count; i++)
			{
				if(this.Numbers[i] > segmentMax)
				{
					segments.Add(nextSegment);
					nextSegment = new List<int>();
					segmentMax += range;
				}
				nextSegment.Add(this.Numbers[i]);
			}
			segments.Add(nextSegment);
			return segments;
		}

		/// <summary>
		/// Load pre-generated data from file(s).
		/// Assumes files contain every element in the sequence in the file's range.
		/// </summary>
		private void Load(string loadFromFolder = null)
		{
			if(loadFromFolder == null)
				loadFromFolder = GetSaveToFolder();
			string path = Path.Combine(Settings.SaveToDirectory, loadFromFolder);
			if(!Directory.Exists(path))
				return;
			string[] filenames = Directory.GetFiles(path).Where(f => Path.GetExtension(f) == Settings.IntegerFileExtension).Select(f => Path.GetFileName(f)).ToArray();
			Array.Sort(filenames, new StartsWithNumberComparer());
			foreach(string filename in filenames)
			{
				using(BinaryReader reader = new BinaryReader(File.Open(Path.Combine(path, filename), FileMode.Open)))
				{
					while(reader.BaseStream.Position != reader.BaseStream.Length)
					{
						int number = reader.ReadInt32();
						if(number > Max)
						{
							loadReachedMax = true;
							break;
						}
						Numbers.Add(number);
					}
				}
				if(Extensions.GetEndingNumber(Path.GetFileNameWithoutExtension(filename)) >= Max)
					loadReachedMax = true;
			}
		}

		/// <summary>
		/// Folder to contain all files related to this sequence.
		/// </summary>
		public abstract string GetSaveToFolder();
	}
}
