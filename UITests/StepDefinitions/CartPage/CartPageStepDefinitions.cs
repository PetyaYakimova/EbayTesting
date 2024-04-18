using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UITests
{
	[Binding]
	public class CartPageStepDefinitions
	{
		private readonly CartPage cartPage;

		public CartPageStepDefinitions(CartPage cartPage)
		{
			this.cartPage = cartPage;
		}

		#region Asserts
		[Then(@"assert that I am on the cart payment page")]
		public void AssertThatIAmOnTheCartPaymentPage()
		{
			Assert.IsTrue(this.cartPage.AmIOnCartPage());
		}

		[Then(@"assert that the quantity of the first item in the cart is (.*)")]
		public void AssertThatTheQuantityOfTheFirstItemInTheCartsIs(string quantity)
		{
			var actualQuantity = this.cartPage.GetFirstItemInTheCartQuantity();

			Assert.AreEqual(quantity, actualQuantity);
		}

		[Then(@"assert that the price of the first item in the cart is for (.*) items with the saved price")]
		public void AssertThatThePriceOfTheFirstItemInTheCartIdForNumberOfItemsWithTheSavedPrice(int numberOfItems)
		{
			double expectedPrice = numberOfItems * Variables.currentProductPricePerItem;

			double actualPrice = this.cartPage.GetFirstItemInTheCartTotalPrice();

			Assert.AreEqual(expectedPrice, actualPrice);
		}
		#endregion
	}
}
