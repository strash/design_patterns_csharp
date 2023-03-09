namespace Facade
{
	class Computer
	{
		public void GetElectricShock()
		{
			Console.WriteLine("Ouch!");
		}

		public void MakeSound()
		{
			Console.WriteLine("Beep beep!");
		}

		public void ShowLoadingScreen()
		{
			Console.WriteLine("Loading...");
		}

		public void Bam()
		{
			Console.WriteLine("Ready to be used!");
		}

		public void CloseEverything()
		{
			Console.WriteLine("Bup bup buzzzzz!");
		}

		public void PullCurrent()
		{
			Console.WriteLine("Haah!");
		}

		public void Sooth()
		{
			Console.WriteLine("Zzzzzz");
		}
	}

	class ComputerFacade
	{
		private readonly Computer _computer;

		public ComputerFacade(Computer computer)
		{
			this._computer = computer;
		}

		public void TurnOn()
		{
			this._computer.GetElectricShock();
			this._computer.MakeSound();
			this._computer.ShowLoadingScreen();
			this._computer.Bam();
		}

		public void TurnOff()
		{
			this._computer.CloseEverything();
			this._computer.PullCurrent();
			this._computer.Sooth();
		}
	}
}
