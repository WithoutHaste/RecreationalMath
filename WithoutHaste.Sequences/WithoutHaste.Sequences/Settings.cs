using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Library-wide settings.
	/// </summary>
	public static class Settings
	{
		/// <summary>
		/// Generated sequences are saved to files in this directory.
		/// This directory is also searched for pre-generated data.
		/// </summary>
		public static string SaveToDirectory = "Sequences";

		/// <summary>
		/// Break sequences into multiple files.
		/// The first holds all elements from 1 to <see cref='SaveRangePerFile'/>, the next holds all elements from <see cref='SaveRangePerFile'/> + 1 to 2 * <see cref='SaveRangePerFile'/>, and so on.
		/// So you can look up a number by the range it is in.
		/// </summary>
		public static int SaveRangePerFile = 5000000;

		/// <summary>
		/// File extension for binary-format integer files.
		/// </summary>
		/// <remarks>
		/// Include the period at the beginning.
		/// </remarks>
		public static string IntegerFileExtension = ".int";
	}
}
