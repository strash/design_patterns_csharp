namespace Prototype
{
	class Sheep
	{
		public required string Name;
		public required string Category;

		public Sheep ShallowCopy()
		{
			return (Sheep)this.MemberwiseClone();
		}

		public Sheep DeepCopy()
		{
			Sheep clone = (Sheep)this.MemberwiseClone();
			clone.Name = Name;
			clone.Category = Category;
			return clone;
		}
	}
}
