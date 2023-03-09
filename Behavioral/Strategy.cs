namespace Strategy
{
	interface ISortStrategy
	{
		public IList<T> Sort<T>(IList<T> dataSet);
	}

	class BubbleSortStrategy : ISortStrategy
	{
		public IList<T> Sort<T>(IList<T> dataSet)
		{
			Console.WriteLine("Sorting using bubble sort strategy");
			// Do sorting here ...
			return dataSet;
		}
	}

	class QuickSortStrategy : ISortStrategy
	{
		public IList<T> Sort<T>(IList<T> dataSet)
		{
			Console.WriteLine("Sorting using quick sort strategy");
			// Do sorting here ...
			return dataSet;
		}
	}

	class Sorter
	{
		public IList<T> Sort<T>(IList<T> dataSet, ISortStrategy strategy)
		{
			return strategy.Sort(dataSet);
		}
	}
}
