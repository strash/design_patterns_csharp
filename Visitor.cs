namespace Visitor
{
	interface IAnimal
	{
		public void Accept(IAnimalOperation op);
	}

	interface IAnimalOperation
	{
		public void VisitMonkey(Monkey monkey);
		public void VisitLion(Lion lion);
		public void VisitDolphin(Dolphin dolphin);
	}

	class Monkey : IAnimal
	{
		public void Speak()
		{
			Console.WriteLine("Ooh oo aa aa!");
		}

		public void Accept(IAnimalOperation operation)
		{
			operation.VisitMonkey(this);
		}
	}

	class Lion : IAnimal
	{
		public void Speak()
		{
			Console.WriteLine("Roaaar!");
		}

		public void Accept(IAnimalOperation operation)
		{
			operation.VisitLion(this);
		}
	}

	class Dolphin : IAnimal
	{
		public void Speak()
		{
			Console.WriteLine("Tuut tuttu tuutt!");
		}

		public void Accept(IAnimalOperation operation)
		{
			operation.VisitDolphin(this);
		}
	}

	class Speak : IAnimalOperation
	{
		public void VisitMonkey(Monkey monkey)
		{
			monkey.Speak();
		}

		public void VisitLion(Lion lion)
		{
			lion.Speak();
		}

		public void VisitDolphin(Dolphin dolphin)
		{
			dolphin.Speak();
		}
	}
}
