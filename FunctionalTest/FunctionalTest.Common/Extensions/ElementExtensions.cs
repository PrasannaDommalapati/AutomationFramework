using FunctionalTest.Common.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FunctionalTest.Common.Extensions
{
    public static class ElementExtensions
    {
        public static void TypeInto(this By identifier, IWebDriver driver, string text)
        {
            try
            {
                driver.WebElement(identifier).SendKeys(text);
            }
            catch (Exception ex)
            {
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static void EnterKeys(this By identifier, IWebDriver driver)
        {
            try
            {
                driver.WebElement(identifier).SendKeys(Keys.Enter);
            }
            catch (Exception ex)
            {
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static void Clear(this By identifier, IWebDriver driver)
        {
            try
            {
                driver.WebElement(identifier).Clear();
            }
            catch (Exception ex)
            {
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static void Click(this By identifier, IWebDriver driver)
        {
            try
            {
                driver.WebElement(identifier).Click();
            }
            catch (Exception ex)
            {
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static string GetText(this By identifier, IWebDriver driver)
        {
            try
            {
                return driver.WebElement(identifier).Text;
            }
            catch (Exception ex)
            {
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static bool IsEnabled(this By identifier, IWebDriver driver)
        {
            try
            {
                return driver.WebElement(identifier).Enabled;
            }
            catch (Exception ex)
            {
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static bool IsDisplayed(this By identifier, IWebDriver driver)
        {
            try
            {
                return driver.WebElement(identifier).Displayed;
            }
            catch (Exception ex)
            {
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static bool IsSelected(this By identifier, IWebDriver driver)
        {
            try
            {
                return driver.WebElement(identifier).Selected;
            }
            catch (Exception ex)
            {
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static SelectElement SelectElement(this By identifier, IWebDriver driver)
        {
            try
            {
                var element = driver.WebElement(identifier);
                return new SelectElement(element);
            }
            catch (Exception ex)
            {
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static void SelectByValue(this By identifier, IWebDriver driver, string text)
        {
            var element = SelectElement(identifier, driver);

            element.SelectByValue(text);
        }

        public static void SelectByIndex(this By identifier, IWebDriver driver, int index)
        {
            var element = SelectElement(identifier, driver);

            element.SelectByIndex(index);
        }

        public static void SelectByText(this By identifier, IWebDriver driver, string text)
        {
            var element = SelectElement(identifier, driver);

            element.SelectByText(text);
        }
    }
}