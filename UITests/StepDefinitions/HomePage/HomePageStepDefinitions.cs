using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace UITests
{
	[Binding]
	public class HomePageStepDefinitions
	{
		private readonly HomePage homePage;

		public HomePageStepDefinitions(HomePage homePage)
		{
			this.homePage = homePage;
		}

		#region Actions
		[StepDefinition(@"I navigate to the home page")]
		public void NavigateToTheHomePage()
		{
			this.homePage.OpenHomePage();

		}

		[StepDefinition(@"I select category (.*) from the category filter dropdown")]
		public void ISelectCategoryFromTheCategoryFilterDropdown(string categoryName)
		{
			this.homePage.SelectCategoryInTheCategoryFilterDropdown(categoryName);
		}


		[StepDefinition(@"I search by keyword (.*)")]
		public void SearchByKeyword(string keyword)
		{
			this.homePage.SearchByKeyword(keyword);
		}

		[StepDefinition(@"I press the Search button")]
		public void PressSearchButton()
		{
			this.homePage.SearchButton.Click();
		}

		[StepDefinition(@"I save the price for the first item")]
		public void SaveThePriceForTheFirstItem()
		{
			Variables.currentProductPricePerItem = this.homePage.GetPriceOfTheFirstItem();
		}

		[StepDefinition(@"I click on the first result")]
		public void ClickOnTheFirstResult()
		{
			this.homePage.FirstResultProductTitle.Click();
		}

		[StepDefinition(@"I switch to the last tab")]
		public void SwitchToTheLastTab()
		{
			this.homePage.SwitchToTheLastOpenTab();
		}
		#endregion

		#region Asserts
		[Then(@"assert that I see the Ebay logo")]
		public void AssertThatISeeTheEbayLogo()
		{
			var expectedAltText = HomePage.LogoImageAltText;

			IWebElement logoImage = this.homePage.LogoImage;

			Assert.IsTrue(logoImage.Displayed);
			Assert.AreEqual(expectedAltText, logoImage.GetAttribute("alt"));
		}

		[Then(@"assert that the first result has (.*) in the title")]
		public void AssertThatTheFirstResultHasKeywordInTheTitle(string keyword)
		{
			var firstResultTitle = this.homePage.FirstResultProductTitle.Text;

			Assert.IsTrue(firstResultTitle.Contains(keyword));
		}

		[Then(@"assert that the first result has (.*) shipping")]
		public void AssertThatTheFirstResultHasShippingType(string shippingType)
		{
			var firstResultShipping = this.homePage.FirstResultProductShippingInfo.Text;

			Assert.IsTrue(firstResultShipping.Contains(shippingType));
		}

		[Then(@"assert that the first result has a price")]
		public void AssertThatTheFirstResultHasPrice()
		{
			var firstResultPrice = this.homePage.FirstResultProductPrice;

			Assert.IsTrue(firstResultPrice.Displayed);
			Assert.IsTrue(firstResultPrice.Text.Contains("$"));
		}

		#endregion
	}
}
