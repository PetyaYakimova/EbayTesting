using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITests
{
	public class CartPage : BasePage
	{
		public CartPage(AppSettings settings, IWebDriver driver, WebDriverWait wait) : base(settings, driver, wait)
		{
		}

		public IWebElement FirstItemQuantitySelectedOption => driver.FindElement(FirstItemQuantitySelectedOptionBy);
		public By FirstItemQuantitySelectedOptionBy = By.XPath("//div[@class='line-item-ctr'][1]//div[@class='quantity']//select//option[@selected]");

		public IWebElement FirstItemTotalPrice => driver.FindElement(FirstItemTotalPriceBy);
		public By FirstItemTotalPriceBy = By.XPath("//div[@class='line-item-ctr'][1]//div[@class='price-details']//span");


		public bool AmIOnCartPage()
		{
			return driver.Url == settings.DomainSettings.CartPage;
		}

		public string GetFirstItemInTheCartQuantity()
		{
			return FirstItemQuantitySelectedOption.Text;
		}

		public double GetFirstItemInTheCartTotalPrice()
		{
			string priceText = FirstItemTotalPrice.Text;

			return ExtractPriceFromString(priceText);
		}
	}
}
