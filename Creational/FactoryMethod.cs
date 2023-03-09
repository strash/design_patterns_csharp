namespace Factory
{
	interface IInterviewer
	{
		public void AskQuestions();
	}

	class Developer : IInterviewer
	{
		public void AskQuestions()
		{
			Console.WriteLine("Ask about design patterns");
		}
	}

	class CommunityExecutive : IInterviewer
	{
		public void AskQuestions()
		{
			Console.WriteLine("Ask about community buildnig");
		}
	}

	abstract class HiringManager
	{
		// Factory method
		protected abstract IInterviewer MakeInterviewer();

		public void TakeInterview()
		{
			IInterviewer interviewer = MakeInterviewer();
			interviewer.AskQuestions();
		}
	}

	class DevelopmentManager : HiringManager
	{
		protected override IInterviewer MakeInterviewer()
		{
			return new Developer();
		}
	}

	class MarketingManager : HiringManager
	{
		protected override IInterviewer MakeInterviewer()
		{
			return new CommunityExecutive();
		}
	}
}
