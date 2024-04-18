using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UITests
{
	[Binding]
	public class ProductPageStepDefinitions
	{
		private readonly ProductMainPage productMainPage;
		private readonly ShippingReturnsAndPaymentsProductPage shippingReturnsAndPaymentsProductPage;

		public ProductPageStepDefinitions(ProductMainPage productMainPage, ShippingReturnsAndPaymentsProductPage shippingReturnsAndPaymentsProductPage)
		{
			this.productMainPage = productMainPage;
			this.shippingReturnsAndPaymentsProductPage = shippingReturnsAndPaymentsProductPage;
		}

		#region Actions
		[StepDefinition(@"I switch to Shipping returns and payments tab in the product page")]
		public void SwitchToShippingReturnsAndPaymentsTabOnTheProductPage()
		{
			this.productMainPage.ShippingReturnsPaymentsTab.Click();
		}

		[StepDefinition(@"I select sticker (.*) in the sticker dropdown in the product page")]
		public void SelectStickerInTheStickerDropdownInProductPage(string stickerName)
		{
			this.productMainPage.SelectSticker(stickerName);
		}

		[StepDefinition(@"I change quantity to (.*) in the product page")]
		public void ChangeQuantityInProductPage(int quantity)
		{
			this.productMainPage.SetQuantity(quantity);
		}

		[StepDefinition(@"I press Add to cart button")]
		public void PressAddToCartButton()
		{
			this.productMainPage.AddToCartButton.Click();
		}
		#endregion

		#region Asserts
		[Then(@"assert that the product title on the product page contains (.*)")]
		public void AssertThatTheProductTitleOnTheProductPageContainsKeyword(string keyword)
		{
			var productTitle = this.productMainPage.ProductTitle.Text;

			Assert.IsTrue(productTitle.Contains(keyword));
		}

		[Then(@"assert that the product price on the product page is the same as the saved one")]
		public void AssertThatTheProductPriceOnTheProductPageIsTheSameAsTheSavedOne()
		{
			var productPrice = this.productMainPage.GetProductPrice();

			Assert.AreEqual(Variables.currentProductPricePerItem, productPrice);
		}

		[Then(@"assert that the country (.*) is in the list of available shipping countries")]
		public void AssertThatCountryIsInTheListOfAvailableShippingCountries(string countryName)
		{
			bool result = this.shippingReturnsAndPaymentsProductPage.CheckIfCountryIsInTheShippingCountryOptions(countryName);

			Assert.IsTrue(result);
		}
		#endregion
	}
}
