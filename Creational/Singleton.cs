namespace Singleton
{
	class President
	{
		private static readonly Lazy<President> _instance = new Lazy<President>(() => new President());

		private President()
		{
			Console.WriteLine("President elected");
		}

		public static President GetInstance() => _instance.Value;
	}
}
