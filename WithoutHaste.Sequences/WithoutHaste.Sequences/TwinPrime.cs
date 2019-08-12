
namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Where (p, p+2) are both prime. 
	/// (3, 5), (5, 7), (11, 13), (17, 19), (29, 31), (41, 43), (59, 61), (71, 73), (101, 103), (107, 109), (137, 139), (149, 151), (179, 181), (191, 193), (197, 199), (227, 229), (239, 241), (269, 271), (281, 283), (311, 313), (347, 349), (419, 421), (431, 433), (461, 463)
	/// </summary>
	public class TwinPrime : RelatedPrime
	{
		/// <inheritdoc/>
		internal static new int[] TestNumbers = new int[] { 3, 5, 7, 11, 13, 17, 19, 29, 31, 41, 43, 59, 61, 71, 73, 101, 103, 107, 109, 137, 139, 149, 151, 179, 181, 191, 193, 197, 199, 227, 229, 239, 241, 269, 271, 281, 283, 311, 313, 347, 349, 419, 421, 431, 433, 461, 463 };

		/// <inheritdoc/>
		protected override int X { get { return 2; } }

		public TwinPrime(int max) : base(max)
		{
		}

		public override string GetSaveToFolder()
		{
			return "Prime_Twin";
		}
	}
}
