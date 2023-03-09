namespace Template
{
	abstract class BuildTemplate
	{
		public void Build()
		{
			this.Test();
			this.Lint();
			this.Assemble();
			this.Deploy();
		}

		protected abstract void Test();
		protected abstract void Lint();
		protected abstract void Assemble();
		protected abstract void Deploy();
	}

	class AndroidBuildTemplate : BuildTemplate
	{
		protected override void Test()
		{
			Console.WriteLine("Running android tests");
		}

		protected override void Lint()
		{
			Console.WriteLine("Linting the android code");
		}

		protected override void Assemble()
		{
			Console.WriteLine("Assembling the android build");
		}

		protected override void Deploy()
		{
			Console.WriteLine("Deploying android to server");
		}
	}

	class IosBuildTemplate : BuildTemplate
	{
		protected override void Test()
		{
			Console.WriteLine("Running ios tests");
		}

		protected override void Lint()
		{
			Console.WriteLine("Linting the ios code");
		}

		protected override void Assemble()
		{
			Console.WriteLine("Assembling the ios build");
		}

		protected override void Deploy()
		{
			Console.WriteLine("Deploying ios to server");
		}
	}
}
