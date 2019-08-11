﻿using System;
using WithoutHaste.Sequences;

namespace Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			//Sequence sequence = new SieveOfEratosthenes(Int32.MaxValue); //out of memory exception adding 15th sieve
			//Sequence sequence = new SieveOfEratosthenes(Int32.MaxValue / 2); //ran out of memory getting approx. 33 millionth prime from the sieve
			
			//Sequence sequence2 = new SieveOfEratosthenes(2000000);
			//sequence2.Save();
			
			//Sequence sequence = new Happy(200000);
			//Sequence sequence = new AdditivePrime(200000);
			//Sequence sequence = new CircularPrime(200000);
			//Sequence sequence = new CousinPrime(200000);
			Sequence sequence = new EmirpPrime(200000);
			var n1 = sequence.Numbers;
			sequence.Save();

			Console.WriteLine("Done");
			Console.ReadLine();
		}
	}
}
