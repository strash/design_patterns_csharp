namespace Command
{
	// Receiver
	class Light
	{
		public void TurnOn()
		{
			Console.WriteLine("Light is on");
		}

		public void TurnOff()
		{
			Console.WriteLine("Light is off");
		}
	}

	interface ICommand
	{
		public void Execute();
		public void Undo();
		public void Redo();
	}

	// Concrete command #1
	class TurnOn : ICommand
	{
		private readonly Light _light;

		public TurnOn(Light light)
		{
			this._light = light;
		}

		public void Execute()
		{
			this._light.TurnOn();
		}

		public void Undo()
		{
			this._light.TurnOff();
		}

		public void Redo()
		{
			this.Execute();
		}
	}

	// Concrete command #2
	class TurnOff : ICommand
	{
		private readonly Light _light;

		public TurnOff(Light light)
		{
			this._light = light;
		}

		public void Execute()
		{
			this._light.TurnOff();
		}

		public void Undo()
		{
			this._light.TurnOn();
		}

		public void Redo()
		{
			this.Execute();
		}
	}

	// Invoker
	class RemoteControl
	{
		private readonly List<ICommand> _history = new();

		public void DoTheThing(ICommand command)
		{
			command.Execute();
			this._history.Add(command);
		}

		public void UndoThatLastThing()
		{
			int count = this._history.Count();
			if (count > 0)
			{
				this._history.Last().Undo();
				this._history.RemoveAt(count - 1);
			}
		}

		// Redo implementation ...
	}
}
