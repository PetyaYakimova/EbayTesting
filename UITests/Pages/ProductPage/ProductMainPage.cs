using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace UITests
{
	public class ProductMainPage : BasePage
	{
		public ProductMainPage(AppSettings settings, IWebDriver driver, WebDriverWait wait) : base(settings, driver, wait)
		{
		}

		public IWebElement ProductTitle => driver.FindElement(ProductTitleBy);
		public By ProductTitleBy = By.XPath("//h1[contains(@class, 'item-title')]//span");

		public IWebElement ProductPrice => driver.FindElement(ProductPriceBy);
		public By ProductPriceBy = By.XPath("//div[contains(@class, 'price-primary')]//span");

		public IWebElement ShippingReturnsPaymentsTab => driver.FindElement(ShippingReturnsPaymentsTabBy);
		public By ShippingReturnsPaymentsTabBy = By.Id("TABS_SPR");

		public IWebElement StickerSelectDropdown => driver.FindElement(StickerSelectDropdownBy);
		public By StickerSelectDropdownBy = By.XPath("//select[contains(@id, 'select-box')]");

		public IWebElement QuantityField => driver.FindElement(QuantityFieldBy);
		public By QuantityFieldBy = By.Id("qtyTextBox");

		public IWebElement AddToCartButton => driver.FindElement(AddToCartButtonBy);
		public By AddToCartButtonBy = By.XPath("//span[text()='Add to cart']");

		public double GetProductPrice()
		{
			string priceAsText = ProductPrice.Text;
			return ExtractPriceFromString(priceAsText);
		}

		public void SelectSticker(string stickerName)
		{
			StickerSelectDropdown.Click();

			IWebElement optionElement =
				driver.FindElement(By.XPath($"//option[contains(text(), '{stickerName}')]"));
			optionElement.Click();
		}

		public void SetQuantity(int quantity)
		{
			QuantityField.Clear();
			QuantityField.SendKeys(quantity.ToString());
		}
	}
}
