namespace Composite
{
	class MenuComponent
	{
		public virtual string Name { get; } = "";
		public virtual string Description { get; } = "";
		public virtual double Price { get; }

		public virtual void Add(MenuComponent component)
		{
			throw new NotImplementedException();
		}

		public virtual void Remove(MenuComponent component)
		{
			throw new NotImplementedException();
		}

		public virtual MenuComponent GetChild(int i)
		{
			throw new NotImplementedException();
		}

		public virtual void Print()
		{
			throw new NotImplementedException();
		}
	}

	class MenuItem : MenuComponent
	{
		public override string Name { get; }
		public override string Description { get; }
		public override double Price { get; }

		public MenuItem(string name, double price, string description)
		{
			this.Name = name;
			this.Description = description;
			this.Price = price;
		}

		public override void Print()
		{
			Console.WriteLine($"- {Name} : {Price} - {Description}");
		}
	}

	class Menu : MenuComponent
	{
		private readonly List<MenuComponent> _menuComponents = new List<MenuComponent>();

		public override string Name { get; }
		public override string Description { get; }

		public Menu(string name, string description)
		{
			this.Name = name;
			this.Description = description;
		}

		public override void Add(MenuComponent component)
		{
			this._menuComponents.Add(component);
		}

		public override void Remove(MenuComponent component)
		{
			this._menuComponents.Remove(component);
		}

		public override MenuComponent GetChild(int i)
		{
			return this._menuComponents[i];
		}

		public override void Print()
		{
			Console.WriteLine($"Menu {Name} - {Description}");
			foreach (MenuComponent component in _menuComponents)
			{
				component.Print();
			}
		}
	}

	class Client
	{
		private readonly MenuComponent _menu;

		public Client(MenuComponent menu)
		{
			this._menu = menu;
		}

		public void ReadMenu()
		{
			this._menu.Print();
		}
	}
}
