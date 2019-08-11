using System;
using WithoutHaste.Sequences;

namespace Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			//Sequence sequence = new SieveOfEratosthenes(Int32.MaxValue); //out of memory exception adding 15th sieve
			Sequence sequence = new SieveOfEratosthenes(Int32.MaxValue / 2); //ran into EndOfStreamException when loading pre-generated values
			var n1 = sequence.Numbers;
			sequence.Save();
		}
	}
}
