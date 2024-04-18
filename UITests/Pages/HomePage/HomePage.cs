using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITests
{
	public class HomePage : BasePage
	{
		public HomePage(AppSettings settings, IWebDriver driver, WebDriverWait wait) : base(settings, driver, wait)
		{
		}

		public const string LogoImageAltText = "eBay Home";

		public IWebElement LogoImage => driver.FindElement(LogoImageBy);
		public By LogoImageBy = By.Id("gh-logo");

		public IWebElement CategoryFilterDropdown => driver.FindElement(CategoryFilterDropdownBy);
		public By CategoryFilterDropdownBy = By.Id("gh-cat");

		public IWebElement SearchInputField => driver.FindElement(SearchInputFieldBy);
		public By SearchInputFieldBy = By.Id("gh-ac");

		public IWebElement SearchButton => driver.FindElement(SearchButtonBy);
		public By SearchButtonBy = By.Id("gh-btn");

		public IWebElement FirstResultProductTitle => driver.FindElement(FirstResultProductTitleBy);
		public By FirstResultProductTitleBy = By.XPath("//ul[contains(@class, 'results')]//li[contains(@class, 'item')][1]//div[contains(@class, 'title')]");

		public IWebElement FirstResultProductShippingInfo => driver.FindElement(FirstResultProductShippingInfoBy);
		public By FirstResultProductShippingInfoBy = By.XPath("//ul[contains(@class, 'results')]//li[contains(@class, 'item')][1]//span[contains(@class, 'shipping')]");

		public IWebElement FirstResultProductPrice => driver.FindElement(FirstResultProductPriceBy);
		public By FirstResultProductPriceBy = By.XPath("//ul[contains(@class, 'results')]//li[contains(@class, 'item')][1]//span[contains(@class, 'price')]");


		public void OpenHomePage()
		{
			driver.Navigate().GoToUrl(settings.DomainSettings.Domain);
		}

		public void SelectCategoryInTheCategoryFilterDropdown(string categoryName)
		{
			CategoryFilterDropdown.Click();

			IWebElement categoryElement =
				driver.FindElement(By.XPath($"//option[text()='{categoryName}']"));
			categoryElement.Click();
		}

		public void SearchByKeyword(string keyword)
		{
			SearchInputField.Click();
			SearchInputField.SendKeys(keyword);
		}

		public double GetPriceOfTheFirstItem()
		{
			string priceAsText = FirstResultProductPrice.Text;

			return ExtractPriceFromString(priceAsText);
		}

	}
}
