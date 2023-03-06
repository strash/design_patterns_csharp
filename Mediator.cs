namespace Mediator
{
	abstract class Mediator
	{
		public abstract void Mediate(string message, Colleague colleague);
	}

	class ManagerMediator : Mediator
	{
		public Colleague? Customer { get; set; }
		public Colleague? Programmer { get; set; }
		public Colleague? Tester { get; set; }

		public override void Mediate(string message, Colleague colleague)
		{
			if (colleague == Customer)
				Programmer?.Notify(message);
			else if (colleague == Programmer)
				Tester?.Notify(message);
			else
				Customer?.Notify(message);
		}
	}

	abstract class Colleague
	{
		private readonly Mediator _mediator;

		public Colleague(Mediator mediator)
		{
			this._mediator = mediator;
		}

		public virtual void Send(string message)
		{
			this._mediator.Mediate(message, this);
		}

		public abstract void Notify(string message);
	}

	class CustomerColleague : Colleague
	{
		public CustomerColleague(Mediator mediator) : base(mediator) { }

		public override void Notify(string message)
		{
			Console.WriteLine($"Message to customer: {message}");
		}
	}

	class ProgrammerColleague : Colleague
	{
		public ProgrammerColleague(Mediator mediator) : base(mediator) { }


		public override void Notify(string message)
		{
			Console.WriteLine($"Message to programmer: {message}");
		}
	}

	class TesterColleague : Colleague
	{
		public TesterColleague(Mediator mediator) : base(mediator) { }


		public override void Notify(string message)
		{
			Console.WriteLine($"Message to tester: {message}");
		}
	}
}
