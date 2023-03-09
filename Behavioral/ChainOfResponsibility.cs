namespace ChainOfResponsibility
{
	abstract class Account
	{
		private Account? _next;
		protected double balance;

		private bool CanPay(double amount) => this.balance >= amount;

		public void SetNext(Account? account) => this._next = account;

		public void Pay(double amount)
		{
			if (this.CanPay(amount))
			{
				Console.WriteLine($"Paid {amount} using {this.GetType()}");
			} else if (this._next is not null)
			{
				Console.WriteLine($"Can't pay using {this.GetType()}");
				this._next.Pay(amount);
			} else
			{
				throw new Exception("You're broke.");
			}
		}
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
