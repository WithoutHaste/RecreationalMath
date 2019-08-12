
namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Where (p, p+4) are both prime. 
	/// (3, 7), (7, 11), (13, 17), (19, 23), (37, 41), (43, 47), (67, 71), (79, 83), (97, 101), (103, 107), (109, 113), (127, 131), (163, 167), (193, 197), (223, 227), (229, 233), (277, 281) 
	/// </summary>
	public class CousinPrime : RelatedPrime
	{
		/// <inheritdoc/>
		internal static new int[] TestNumbers = new int[] { 3, 7, 11, 13, 17, 19, 23, 37, 41, 43, 47, 67, 71, 79, 83, 97, 101, 103, 107, 109, 113, 127, 131, 163, 167, 193, 197, 223, 227, 229, 233, 277, 281 };

		/// <inheritdoc/>
		protected override int X { get { return 4; } }

		public CousinPrime(int max) : base(max)
		{
		}

		public override string GetSaveToFolder()
		{
			return "Prime_Cousin";
		}
	}
}
