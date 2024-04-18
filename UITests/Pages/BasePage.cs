using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace UITests
{
	public abstract class BasePage
	{
		protected readonly AppSettings settings;
		protected readonly IWebDriver driver;
		protected readonly WebDriverWait wait;

		protected BasePage(
			AppSettings settings,
			IWebDriver driver,
			WebDriverWait wait)
		{
			this.settings = settings;
			this.driver = driver;
			this.wait = wait;
		}

		public void SwitchToTheLastOpenTab()
		{
			driver.SwitchTo().Window(driver.WindowHandles.Last());
		}

		protected double ExtractPriceFromString(string priceText)
		{
			var match = Regex.Match(priceText, "[0-9]+[\\.,][0-9]+");

			if (match == null)
			{
				throw new ArgumentException("No price can be extracted!");
			}

			double price = double.Parse(match.Value);

			return price;
		}
	}
}
