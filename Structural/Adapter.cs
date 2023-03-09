namespace Adapter
{
	interface ILion
	{
		public void Roar();
	}

	class AfricanLion : ILion
	{
		public void Roar()
		{
			Console.WriteLine("Ooga booga. I'm an african lion");
		}
	}

	class AsianLion : ILion
	{
		public void Roar()
		{
			Console.WriteLine("Myao. I'm an asian lion");
		}
	}

	class WildDog
	{
		public void Bark()
		{
			Console.WriteLine("Woof. I'm a wild dog");
		}
	}

	class WildDogAdaptor : ILion
	{
		protected WildDog dog;

		public WildDogAdaptor(WildDog dog)
		{
			this.dog = dog;
		}

		public void Roar()
		{
			this.dog.Bark();
		}
	}

	class Hunter
	{
		public void Hunt(ILion lion)
		{
			lion.Roar();
		}
	}
}
