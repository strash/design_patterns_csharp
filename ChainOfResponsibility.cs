namespace ChainOfResponsibility
{
	abstract class Account
	{
		private Account? _successor;
		protected double balance;

		public void SetNext(Account? account)
		{
			this._successor = account;
		}

		public void Pay(double amount)
		{
			if (this.CanPay(amount))
			{
				Console.WriteLine($"Paid {amount} using {this.GetType()}");
			} else if (this._successor is not null)
			{
				Console.WriteLine($"Can't pay using {this.GetType()}");
				this._successor.Pay(amount);
			} else
			{
				throw new Exception("You're broke.");
			}
		}

		private bool CanPay(double amount) => this.balance >= amount;
	}

	class Bank : Account
	{
		public Bank(double balance)
		{
			this.balance = balance;
		}
	}

	class Paypal : Account
	{
		public Paypal(double balance)
		{
			this.balance = balance;
		}
	}

	class Bitcoin : Account
	{
		public Bitcoin(double balance)
		{
			this.balance = balance;
		}
	}
}
