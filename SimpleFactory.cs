namespace Factory
{
	public interface IDoor
	{
		public int GetWidth();
		public int GetHeight();
	}

	public class WoodenDoor : IDoor
	{
		protected int _width;
		protected int _height;

		public WoodenDoor(int width, int height)
		{
			this._width = width;
			this._height = height;
		}

		public int GetWidth() => this._width;
		public int GetHeight() => this._height;
	}

	// Factory
	public class DoorFactory
	{
		public static IDoor MakeDoor(int width, int height)
		{
			return new WoodenDoor(width, height);
		}
	}
}
