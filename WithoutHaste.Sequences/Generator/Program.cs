using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WithoutHaste.Sequences;

namespace Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			Sequence sequence = new SieveOfEratosthenes(10);
			var n1 = sequence.Numbers;
			sequence.Save();
			Sequence sequence2 = new SieveOfEratosthenes(11);
			var n2 = sequence2.Numbers;
		}
	}
}
