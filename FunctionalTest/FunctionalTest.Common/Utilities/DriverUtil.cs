using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalTest.Common.Utilities
{
    public class DriverUtil
    {
        private IWebDriver _driver;

        public IWebDriver GetDriver(Browser browser = Browser.CHROME)
        {
            try
            {
                _driver = SetDriver(browser);
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }

            return _driver;
        }

        private IWebDriver SetDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.CHROME:
                    _driver = new ChromeDriver();
                    break;
                case Browser.FIREFOX:
                    _driver = new FirefoxDriver();
                    break;               
                case Browser.EDGE:
                    _driver = new EdgeDriver();
                    break;
                default:
                    Assert.Fail("Invalid Browser");
                    break;
            }

            _driver.Manage().Window.Maximize();
            return _driver;
        }
    }
}
