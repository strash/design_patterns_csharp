namespace Bridge
{
	abstract class WebPage
	{
		protected ITheme theme;

		public WebPage(ITheme theme)
		{
			this.theme = theme;
		}

		public abstract string GetContent();
	}

	class AboutWebPage : WebPage
	{
		public AboutWebPage(ITheme theme) : base(theme)
		{
		}

		public override string GetContent()
		{
			return $"About page in {this.theme.GetColor()}";
		}
	}

	class CareersWebPage : WebPage
	{
		public CareersWebPage(ITheme theme) : base(theme)
		{
		}

		public override string GetContent()
		{
			return $"Careers page in {this.theme.GetColor()}";
		}
	}

	interface ITheme
	{
		public string GetColor();
	}

	class DarkTheme : ITheme
	{
		public string GetColor()
		{
			return "Dark Black";
		}
	}

	class LightTheme : ITheme
	{
		public string GetColor()
		{
			return "Off White";
		}
	}
}
