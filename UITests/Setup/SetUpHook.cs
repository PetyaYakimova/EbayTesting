using BoDi;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace UITests
{
	[Binding]
	public class SetUpHook
	{
		private readonly IConfigurationRoot configuration;
		private WebDriverWait wait;
		private readonly AppSettings settings;

		public SetUpHook(IObjectContainer objectContainer)
		{
			configuration = BuildConfiguration();
			settings = configuration.Get<AppSettings>();
			objectContainer.RegisterInstanceAs(this.settings);
		}

		[BeforeScenario]
		public void Setup(IObjectContainer objectContainer, ScenarioContext scenarioContext)
		{
			ChromeOptions options = new ChromeOptions();

			options.AddArgument("--headless");
			options.AddArgument("--enable-automation");
			options.AddArgument("--start-maximized");
			options.PageLoadStrategy = PageLoadStrategy.Normal;
			IWebDriver driver = new ChromeDriver(".", options);
			driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
			this.wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
			objectContainer.RegisterInstanceAs(driver);
			objectContainer.RegisterInstanceAs(wait);
		}

		[AfterScenario]
		public void TearDown(IObjectContainer objectContainer)
		{
			Variables.currentProductPricePerItem = 0;

			IWebDriver driver = objectContainer.Resolve<IWebDriver>();
			driver.Quit();
		}

		private static IConfigurationRoot BuildConfiguration()
		{
			ConfigurationBuilder builder = new();

#if DEBUG
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Debug.json"), optional: false, reloadOnChange: false);
#endif

			return builder.Build();
		}
	}
}
