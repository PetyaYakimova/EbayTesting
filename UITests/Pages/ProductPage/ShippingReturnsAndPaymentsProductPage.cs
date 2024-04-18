using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace UITests
{
	public class ShippingReturnsAndPaymentsProductPage : BasePage
	{
		public ShippingReturnsAndPaymentsProductPage(AppSettings settings, IWebDriver driver, WebDriverWait wait) : base(settings, driver, wait)
		{
		}

		public IWebElement ShippingCountryDropdown => driver.FindElement(ShippingCountryDropdownBy);
		public By ShippingCountryDropdownBy = By.Id("shCountry");

		public IWebElement ShippingCountryDropdownOption => driver.FindElement(ShippingCountryDropdownOptionBy);
		public By ShippingCountryDropdownOptionBy = By.XPath("//select[@id='shCountry']//option//span");

		public bool CheckIfCountryIsInTheShippingCountryOptions(string countryName)
		{
			ShippingCountryDropdown.Click();

			var allCountryOptions = driver.FindElements(ShippingCountryDropdownOptionBy).Select(e => e.Text);

			return allCountryOptions.Contains(countryName);
		}
	}
}
