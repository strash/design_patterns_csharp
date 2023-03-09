namespace Interpreter
{
	class Context
	{
		public Stack<string> Result = new();
	}

	interface IExpression
	{
		public void Interpret(Context context);
	}

	class Expression : IExpression
	{
		public required string Value { private get; set; }

		public void Interpret(Context context)
		{
			context.Result.Push(Value);
		}
	}

	abstract class OperatorExpression : IExpression
	{
		public required IExpression Left { private get; set; }
		public required IExpression Right { private get; set; }

		protected abstract void DoInterpret(Context context, string lhs, string rhs);

		public void Interpret(Context context)
		{
			Left.Interpret(context);
			string leftResult = context.Result.Pop();

			Right.Interpret(context);
			string rightResult = context.Result.Pop();

			DoInterpret(context, leftResult, rightResult);
		}
	}

	class EqualOperatorExpression : OperatorExpression
	{
		protected override void DoInterpret(Context context, string lhs, string rhs)
		{
			context.Result.Push(lhs == rhs ? "true" : "false");
		}
	}

	class OrOperatorExpression : OperatorExpression
	{
		protected override void DoInterpret(Context context, string lhs, string rhs)
		{
			context.Result.Push((lhs == "true" || rhs == "true") ? "true" : "false");
		}
	}
}
