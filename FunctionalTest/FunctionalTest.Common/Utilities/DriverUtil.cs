using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FunctionalTest.Common.Utilities
{
    public class DriverUtil
    {
        private IWebDriver _driver;

        public IWebDriver GetDriver(Browser browser = Browser.CHROME, bool headless = false)
        {
            try
            {
                switch (browser)
                {
                    case Browser.CHROME:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        ChromeOptions chromeOptions = new ();
                        chromeOptions.AddArguments("start-maximized");
                        chromeOptions.AddArguments("--disable-gpu");
                        if (headless)
                            chromeOptions.AddArguments("--headless");
                        _driver = new ChromeDriver();
                        break;
                    case Browser.FIREFOX:
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        FirefoxOptions firefoxOPtions = new();
                        firefoxOPtions.AddArguments("start-maximized");
                        firefoxOPtions.AddArguments("--disable-gpu");
                        if (headless)
                            firefoxOPtions.AddArguments("--headless");
                        _driver = new FirefoxDriver(firefoxOPtions);
                        break;
                    case Browser.EDGE:
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        EdgeOptions edgeOptions = new();
                        edgeOptions.AddArguments("start-maximized");
                        edgeOptions.AddArguments("--disable-gpu");
                        if (headless)
                            edgeOptions.AddArguments("--headless");
                        _driver = new EdgeDriver(edgeOptions);
                        break;
                    default:
                        Assert.Fail("Invalid Browser");
                        break;
                }

                _driver.Manage().Window.Maximize();
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }

            return _driver;
        }
    }
}
