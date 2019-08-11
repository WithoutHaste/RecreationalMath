using System;
using WithoutHaste.Sequences;

namespace Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			//Sequence sequence = new SieveOfEratosthenes(Int32.MaxValue); //out of memory exception adding 15th sieve
			//Sequence sequence = new SieveOfEratosthenes(Int32.MaxValue / 2); //ran out of memory getting approx. 33 millionth prime from the sieve
			Sequence sequence = new SieveOfEratosthenes(200000);
			//Sequence sequence = new Happy(200000);
			var n1 = sequence.Numbers;
			sequence.Save();

			Console.WriteLine("Done");
			Console.ReadLine();
		}
	}
}
