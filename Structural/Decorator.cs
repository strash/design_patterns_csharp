namespace Decorator
{
	interface ICoffee
	{
		public int GetCost();
		public string GetDescription();
	}

	class SimpleCoffee : ICoffee
	{
		public int GetCost() => 10;

		public string GetDescription() => "Simple coffee";
	}

	abstract class Topping : ICoffee
	{
		protected readonly ICoffee coffee;

		public Topping(ICoffee coffee)
		{
			this.coffee = coffee;
		}

		public virtual int GetCost() => this.coffee.GetCost();

		public virtual string GetDescription() => this.coffee.GetDescription();
	}

	class MilkTopping : Topping
	{
		public MilkTopping(ICoffee coffee) : base(coffee)
		{
		}

		public override int GetCost() => base.coffee.GetCost() + 2;

		public override string GetDescription() => base.coffee.GetDescription() + ", milk";
	}

	class VanillaTopping : Topping
	{
		public VanillaTopping(ICoffee coffee) : base(coffee)
		{
		}

		public override int GetCost() => base.coffee.GetCost() + 3;

		public override string GetDescription() => base.coffee.GetDescription() + ", vanilla";
	}

	class BaristaBuilder
	{
		private bool _hasMilk = false;
		private bool _hasVanilla = false;

		public BaristaBuilder AddMilk()
		{
			_hasMilk = true;
			return this;
		}

		public BaristaBuilder AddVanilla()
		{
			_hasVanilla = true;
			return this;
		}

		public ICoffee MakeCoffee()
		{
			ICoffee coffee = new SimpleCoffee();
			if (_hasMilk)
				coffee = new MilkTopping(coffee);
			if (_hasVanilla)
				coffee = new VanillaTopping(coffee);
			return coffee;
		}
	}
}
