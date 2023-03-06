namespace Builder
{
	interface IBurger
	{
		public void ConfirmOrder();
	}

	class Burger : IBurger
	{
		protected int _size;
		protected bool _cheese = false;
		protected bool _pepperoni = false;
		protected bool _lettuce = false;
		protected bool _tomato = false;

		public Burger(BurgerBuilder builder)
		{
			this._size = builder.size;
			this._cheese = builder.cheese;
			this._pepperoni = builder.pepperoni;
			this._lettuce = builder.lettuce;
			this._tomato = builder.tomato;
		}

		public void ConfirmOrder()
		{
			string order = $"Burger size is {this._size}.";
			if (this._cheese)
				order += " + cheese";
			if (this._pepperoni)
				order += " + pepperoni";
			if (this._lettuce)
				order += " + lettuce";
			if (this._tomato)
				order += " + tomato";
			Console.WriteLine(order);
		}
	}


	class BurgerBuilder
	{
		public int size;
		public bool cheese = false;
		public bool pepperoni = false;
		public bool lettuce = false;
		public bool tomato = false;

		public BurgerBuilder(int size)
		{
			this.size = size;
		}

		public BurgerBuilder AddChese()
		{
			this.cheese = true;
			return this;
		}

		public BurgerBuilder AddPepperoni()
		{
			this.pepperoni = true;
			return this;
		}

		public BurgerBuilder AddLettuce()
		{
			this.lettuce = true;
			return this;
		}

		public BurgerBuilder AddTomato()
		{
			this.tomato = true;
			return this;
		}

		public Burger Build()
		{
			return new Burger(this);
		}
	}
}
