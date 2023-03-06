using System.Collections;

namespace Iterator
{
	class RadioStation
	{
		public readonly float Frequency;

		public RadioStation(float frequency)
		{
			this.Frequency = frequency;
		}
	}

	class Stations : IEnumerable
	{
		private readonly RadioStation[] _stations;

		public Stations(RadioStation[] stations)
		{
			this._stations = new RadioStation[stations.Length];
			for (int i = 0; i < stations.Length; i++)
			{
				this._stations[i] = stations[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => new StationsEnum(this._stations);
	}

	class StationsEnum : IEnumerator
	{
		public readonly RadioStation[] Stations;

		private int _position = -1;

		public StationsEnum(RadioStation[] stations)
		{
			this.Stations = stations;
		}

		public bool MoveNext()
		{
			this._position++;
			return (_position < this.Stations.Length);
		}

		public void Reset()
		{
			this._position = -1;
		}

		object IEnumerator.Current
		{
			get { return Current; }
		}

		public RadioStation Current
		{
			get
			{
				try
				{
					return Stations[_position];
				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}
	}
}
