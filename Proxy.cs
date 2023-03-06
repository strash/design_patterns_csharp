namespace Proxy
{
	interface IDoor
	{
		public void Open();
		public void Close();
	}

	class LabDoor : IDoor
	{
		public void Open()
		{
			Console.WriteLine("Opening lab door");
		}

		public void Close()
		{
			Console.WriteLine("Closing lab door");
		}
	}

	class Password
	{
		public string Value { get; }

		public Password(string name)
		{
			this.Value = name;
		}
	}

	// Proxy
	class SecuredDoor : IDoor
	{
		private readonly IDoor _realDoor;
		private readonly Password _password;

		public SecuredDoor(Password password)
		{
			this._password = password;
			this._realDoor = new LabDoor();
		}

		public void Open()
		{
			if (this._password.Value == "secret_password")
				this._realDoor.Open();
			else
				Console.WriteLine("You can't do this!");
		}

		public void Close()
		{
			this._realDoor.Close();
		}
	}
}
