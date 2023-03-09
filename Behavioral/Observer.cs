namespace Observer
{
	class JobPost
	{
		public string Title { get; }

		public JobPost(string title)
		{
			this.Title = title;
		}
	}

	class Observer : IObserver<JobPost>
	{
		public string Name { get; }

		public Observer(string name)
		{
			this.Name = name;
		}

		public void OnCompleted()
		{
			throw new NotImplementedException();
		}

		public void OnError(Exception error)
		{
			throw new NotImplementedException();
		}

		public void OnNext(JobPost value)
		{
			Console.WriteLine($"Hi, {Name}. New job posted: {value.Title}");
		}

		public IDisposable Register(Agency subject) => subject.Subscribe(this);
	}

	class Agency : IObservable<JobPost>
	{
		public List<IObserver<JobPost>> Observers { get; set; }

		public Agency()
		{
			this.Observers = new();
		}

		public IDisposable Subscribe(IObserver<JobPost> observer)
		{
			if (!Observers.Contains(observer))
				Observers.Add(observer);
			return new Unsubscriber(observer, Observers);
		}

		public void Emit(string message)
		{
			foreach (var observer in Observers)
				observer.OnNext(new(message));
		}
	}

	class Unsubscriber : IDisposable
	{
		private readonly IObserver<JobPost>? _observer;
		private readonly IList<IObserver<JobPost>> _observers;

		public Unsubscriber(
			IObserver<JobPost> observer,
			IList<IObserver<JobPost>> observers)
		{
			this._observer = observer;
			this._observers = observers;
		}

		public void Dispose()
		{
			if (this._observer is not null
				&& this._observers.Contains(this._observer))
				this._observers.Remove(this._observer);
			GC.SuppressFinalize(this);
		}
	}
}
