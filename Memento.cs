namespace Memento
{
	class Memento
	{
		private readonly string _content = "";

		public string Content { get => this._content; }

		public Memento(string content)
		{
			this._content = content;
		}
	}

	class Originator
	{
		private string _content = "";

		public void Edit(string content)
		{
			this._content += content;
		}

		public string GetContent() => this._content;

		public Memento Save() => new(this._content);

		public void Restore(Memento memento)
		{
			this._content = memento.Content;
		}
	}
}
