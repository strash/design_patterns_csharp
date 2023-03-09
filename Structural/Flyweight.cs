namespace Flyweight
{
	class Flyweight
	{
		private static readonly Dictionary<string, Flyweight> _cache = new();

		public string Name { get; }

		private Flyweight(string name)
		{
			this.Name = name;
		}

		public static Flyweight Intern(string name)
		{
			if (!Flyweight._cache.TryGetValue(name, out var cache))
			{
				cache = new(name);
				Flyweight._cache.Add(name, cache);
			}
			return cache;
		}

		public static int Count() => Flyweight._cache.Count;

		public override string ToString() => $"{this.Name}";
	}

	class FlyweightFactory
	{
		private readonly int _id;
		private readonly Flyweight _item;

		private FlyweightFactory(Flyweight item, int id)
		{
			this._id = id;
			this._item = item;
		}

		public static FlyweightFactory Create(string name, int id)
		{
			Flyweight item = Flyweight.Intern(name);
			return new FlyweightFactory(item, id);
		}

		public override string ToString()
		{
			return $"Serving {this._item.ToString()} to table {this._id}";
		}
	}

	class Client
	{
		private readonly List<FlyweightFactory> _orders = new();

		public void TakeOrder(string order, int tableNumber)
		{
			this._orders.Add(FlyweightFactory.Create(order, tableNumber));
		}

		public void Serve()
		{
			Console.WriteLine($"{Flyweight.Count()} objects in cache");
			Console.WriteLine($"{this._orders.Count} orders to serve");
			foreach (FlyweightFactory order in _orders)
				Console.WriteLine(order.ToString());
		}
	}
}
