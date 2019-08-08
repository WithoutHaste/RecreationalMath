using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WithoutHaste.Sequences.Tools
{
	/// <summary>
	/// Numerically compares strings that start with a number. Only takes the starting number into account.
	/// </summary>
	/// <remarks>
	/// Only supports integers up to <see cref='Int32.MaxValue'/>.
	/// </remarks>
	public class StartsWithNumberComparer : IComparer<string>
	{
		public int Compare(string a, string b)
		{
			int aInt = Extensions.GetStartingNumber(a);
			int bInt = Extensions.GetStartingNumber(b);
			if(aInt < bInt)
				return -1;
			if(aInt > bInt)
				return 1;
			return 0;
		}
	}
}
