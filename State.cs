namespace State
{
	interface IState
	{
		public IState PickUp();
		public IState HangUp();
		public IState Dial();
	}

	class PhoneIdle : IState
	{
		public IState PickUp()
		{
			Console.WriteLine("Phone is picked up");
			return new PhonePickedUp();
		}

		public IState HangUp()
		{
			throw new Exception("Already idle");
		}

		public IState Dial()
		{
			throw new Exception("Unable to dial in idle state");
		}
	}

	class PhonePickedUp : IState
	{
		public IState PickUp()
		{
			throw new Exception("Already picked up");
		}

		public IState HangUp()
		{
			Console.WriteLine("Phone in idle state");
			return new PhoneIdle();
		}

		public IState Dial()
		{
			Console.WriteLine("Phone in calling state");
			return new PhoneDial();
		}
	}

	class PhoneDial : IState
	{
		public IState PickUp()
		{
			throw new Exception("Already picked up");
		}

		public IState HangUp()
		{
			Console.WriteLine("Phone in idle state");
			return new PhoneIdle();
		}

		public IState Dial()
		{
			throw new Exception("Already dialing");
		}
	}


	class Phone
	{
		private IState _state;

		public Phone()
		{
			this._state = new PhoneIdle();
		}

		public void PickUp()
		{
			this._state = this._state.PickUp();
		}

		public void HangUp()
		{
			this._state = this._state.HangUp();
		}

		public void Dial()
		{
			this._state = this._state.Dial();
		}
	}
}
