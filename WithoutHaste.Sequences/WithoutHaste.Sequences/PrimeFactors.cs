using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WithoutHaste.Sequences.Tools;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Calculates the prime factors of integers.
	/// </summary>
	public class PrimeFactors
	{
		private const string TEXT_FILE_EXTENSION = ".txt";
		private const char FIELD_DELIMITER = ':';
		private const char FACTOR_DELIMITER = ',';

		/// <summary>
		/// Maximum number factorized.
		/// </summary>
		public int Max { get; private set; }

		/// <summary>
		/// Dict[N] = ordered list of distinct prime factors of N
		/// </summary>
		public Dictionary<int, int[]> Factors;

		/// <summary>
		/// Set to true if loading pre-generated data was able to confirm that all elements up the Max were loaded.
		/// </summary>
		private bool loadReachedMax = false;

		public PrimeFactors(int max)
		{
			Max = max;
			Factors = new Dictionary<int, int[]>();
			Load();
			if(loadReachedMax)
				return;
			Generate();
			Save();
		}

		/// <summary>
		/// Returns an ordered array of the distinct prime factors of <paramref name='n'/>.
		/// </summary>
		/// <exception cref='ArgumentException'><paramref name='n'/> must be greater than 0.</exception>
		public int[] Lookup(int n)
		{
			if(n < 1 || n > Max)
				throw new ArgumentException("Range is 1 to " + Max + ".");
			return Factors[n].ToArray();
		}

		/// <summary>
		/// Use method similar to Seive Of Eristothenes to quickly factorize all numbers from 1 to <paramref name='max'/>.
		/// Starts with an empty cache.
		/// </summary>
		private void Generate()
		{
			List<int>[] factors = new List<int>[Max + 1];

			bool[] seiveOfEristothenes = new bool[Max + 1]; //true is prime
			for(int i = 0; i < seiveOfEristothenes.Length; i++)
			{
				seiveOfEristothenes[i] = true;
			}
			seiveOfEristothenes[0] = false;
			seiveOfEristothenes[1] = false;
			for(int i = 2; i < seiveOfEristothenes.Length; i++)
			{
				if(seiveOfEristothenes[i] == false)
					continue;
				for(int j = i + i; j < seiveOfEristothenes.Length; j += i)
				{
					seiveOfEristothenes[j] = false;
					if(factors[j] == null)
						factors[j] = new List<int>();
					factors[j].Add(i);
				}
			}

			Factors.Clear();
			for(int i = 1; i < factors.Length; i++)
			{
				Factors[i] = (factors[i] == null) ? new int[0] : factors[i].ToArray();
			}
		}

		private void Load()
		{
			string path = Path.Combine(Settings.SaveToDirectory, GetSaveToFolder());
			if(!Directory.Exists(path))
				return;
			string[] filenames = Directory.GetFiles(path).Select(f => Path.GetFileName(f)).ToArray();
			Array.Sort(filenames, new StartsWithNumberComparer());
			foreach(string filename in filenames)
			{
				string[] lines = File.ReadAllLines(Path.Combine(path, filename));
				foreach(string line in lines)
				{
					string[] fields = line.Split(FIELD_DELIMITER);
					int number = Int32.Parse(fields[0]);
					if(fields.Length == 1 || String.IsNullOrEmpty(fields[1]))
					{
						Factors[number] = new int[0];
						continue;
					}
					string[] factorFields = fields[1].Split(FACTOR_DELIMITER);
					Factors[number] = factorFields.Select(n => Int32.Parse(n)).ToArray();
				}
			}
		}

		private void Save()
		{
			string path = Path.Combine(Settings.SaveToDirectory, GetSaveToFolder());
			Directory.CreateDirectory(path);

			int range = 200000;
			int min = 1;
			int[] keys = Factors.Keys.OrderBy(n => n).ToArray();
			for(int i = 0; i < keys.Length; i+=range)
			{
				int rangeMax = min + range - 1;
				if(i + range >= keys.Length)
					rangeMax = Max;
				string filename = String.Format("{0}to{1}{2}", min, rangeMax, TEXT_FILE_EXTENSION);
				using(StreamWriter writer = new StreamWriter(Path.Combine(path, filename)))
				{
					for(int j = i; j < keys.Length && j < i + range; j++)
					{
						writer.WriteLine(String.Format("{0}{1}{2}", keys[j], FIELD_DELIMITER, String.Join(FACTOR_DELIMITER.ToString(), Factors[keys[j]])));
					}
				}
			}
		}

		private string GetSaveToFolder()
		{
			return "PrimeFactor";
		}
	}
}
