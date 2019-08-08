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
			Sequence sequence = new SieveOfEratosthenes(5000000);
			//var n1 = sequence.Numbers;
			sequence.Save();
		}
	}
}
