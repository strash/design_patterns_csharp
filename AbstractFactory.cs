namespace Factory
{
	interface IDoorInfo
	{
		public void Description();
	}

	interface IDoorFittingExpert
	{
		public void Description();
	}

	class WoodenDoorInfo : IDoorInfo
	{
		public void Description()
		{
			Console.WriteLine("I'm a wooden door");
		}
	}

	class IronDoorInfo : IDoorInfo
	{
		public void Description()
		{
			Console.WriteLine("I'm an iron door");
		}
	}

	class Carpenter : IDoorFittingExpert
	{
		public void Description()
		{
			Console.WriteLine("I can only fit wooden doors");
		}
	}

	class Welder : IDoorFittingExpert
	{
		public void Description()
		{
			Console.WriteLine("I can only fit iron doors");
		}
	}

	interface IDoorFactory
	{
		public IDoorInfo MakeDoor();
		public IDoorFittingExpert HireExpert();
	}

	class WoodenDoorFactory : IDoorFactory
	{
		public IDoorInfo MakeDoor()
		{
			return new WoodenDoorInfo();
		}

		public IDoorFittingExpert HireExpert()
		{
			return new Carpenter();
		}
	}

	class IronDoorFactory : IDoorFactory
	{
		public IDoorInfo MakeDoor()
		{
			return new IronDoorInfo();
		}

		public IDoorFittingExpert HireExpert()
		{
			return new Welder();
		}
	}
}
