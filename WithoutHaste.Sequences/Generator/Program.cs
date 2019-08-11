using WithoutHaste.Sequences;

namespace Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			Sequence sequence = new SieveOfEratosthenes(10000000);
			var n1 = sequence.Numbers;
			sequence.Save();
		}
	}
}
