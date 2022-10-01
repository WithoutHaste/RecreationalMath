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

            //Sequence sequence = new SieveOfEratosthenes(2000000);

            //Sequence sequence = new Happy(10000);
            //Sequence sequence = new AdditivePrime(10000);
            //Sequence sequence = new CircularPrime(200000);
            //Sequence sequence = new CousinPrime(200000);
            //Sequence sequence = new EmirpPrime(200000);
            //Sequence sequence = new HiggsPrime(200000);
            //PrimeFactors primeFactors = new PrimeFactors(200000);

            //Sequence sequence = new Lucky(10000);
            //Sequence sequence2 = new SieveOfEratosthenes(300000);
            //Sequence intersection = sequence.Intersect(sequence2);
            //intersection.Save();
            //Sequence sequence3 = new Happy(200000);
            //Sequence intersection2 = sequence3.Intersect(intersection);
            //intersection2.Save();

            //Sequence sequence = new TwinPrime(2000000);
            //Sequence sequence = new IsolatedPrime(2000000);
            //Sequence sequence = new SexyPrime(2000000);
            //Sequence sequence = new TripletPrime(2000000);
            //Sequence sequence = new QuadrupletPrime(2000000);

            //Sequence sequence = new Composite(10000);
            //Sequence sequence = new Abundant(10000);
            //Sequence sequence = new Deficient(10000);
            Sequence sequence = new Perfect(10000);
            sequence.Save();

			Console.WriteLine("Done");
			Console.ReadLine();
		}
	}
}
