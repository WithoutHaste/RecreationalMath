
namespace WithoutHaste.Sequences
{
	/// <summary>
	/// Where (p, p+6) are both prime. 
	/// (5, 11), (7, 13), (11, 17), (13, 19), (17, 23), (23, 29), (31, 37), (37, 43), (41, 47), (47, 53), (53, 59), (61, 67), (67, 73), (73, 79), (83, 89), (97, 103), (101, 107), (103, 109), (107, 113), (131, 137), (151, 157), (157, 163), (167, 173), (173, 179), (191, 197), (193, 199)
	/// </summary>
	public class SexyPrime : RelatedPrime
	{
		/// <inheritdoc/>
		internal static new int[] TestNumbers = new int[] { 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 131, 137, 151, 157, 163, 167, 173, 179, 191, 193, 197, 199 };

		/// <inheritdoc/>
		protected override int X { get { return 6; } }

		public SexyPrime(int max) : base(max)
		{
		}

		public override string GetSaveToFolder()
		{
			return "Prime_Sexy";
		}
	}
}
