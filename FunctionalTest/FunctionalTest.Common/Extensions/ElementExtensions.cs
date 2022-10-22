using FunctionalTest.Common.Exceptions;
using FunctionalTest.Common.Reporting;
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
                ReportManager.LogInfo($"Entered text {text}");
            }
            catch (Exception ex)
            {
                ReportManager.LogError(ex.Message);
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static void EnterKeys(this By identifier, IWebDriver driver)
        {
            try
            {
                driver.WebElement(identifier).SendKeys(Keys.Enter);
                ReportManager.LogInfo($"Entered key {Keys.Enter}");
            }
            catch (Exception ex)
            {
                ReportManager.LogError(ex.Message);
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static void Clear(this By identifier, IWebDriver driver)
        {
            try
            {
                driver.WebElement(identifier).Clear();
                ReportManager.LogInfo($"Cleared text in {identifier}");
            }
            catch (Exception ex)
            {
                ReportManager.LogError(ex.Message);
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static void Click(this By identifier, IWebDriver driver)
        {
            try
            {
                driver.WebElement(identifier).Click();
                ReportManager.LogInfo($"Clicked on the element {identifier}");
            }
            catch (Exception ex)
            {
                ReportManager.LogError(ex.Message);
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static string GetText(this By identifier, IWebDriver driver)
        {
            try
            {
                var text = driver.WebElement(identifier).Text;
                ReportManager.LogInfo($"Get Text {identifier}");
                return text;
            }
            catch (Exception ex)
            {
                ReportManager.LogError(ex.Message);
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static bool IsEnabled(this By identifier, IWebDriver driver)
        {
            try
            {
                var enabled = driver.WebElement(identifier).Enabled;
                ReportManager.LogInfo($"Element enabled {identifier}");
                return enabled;
            }
            catch (Exception ex)
            {
                ReportManager.LogError(ex.Message);
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static bool IsDisplayed(this By identifier, IWebDriver driver)
        {
            try
            {
                var displayed = driver.WebElement(identifier).Displayed;
                ReportManager.LogInfo($"Element displayed {identifier}");
                return displayed;
            }
            catch (Exception ex)
            {
                ReportManager.LogError(ex.Message);
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static bool IsSelected(this By identifier, IWebDriver driver)
        {
            try
            {
                var selected = driver.WebElement(identifier).Selected;
                ReportManager.LogInfo($"Element selected {identifier}");
                return selected;
            }
            catch (Exception ex)
            {
                ReportManager.LogError(ex.Message);
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static SelectElement SelectElement(this By identifier, IWebDriver driver)
        {
            try
            {
                var element = driver.WebElement(identifier);
                ReportManager.LogInfo($"Element Select {identifier}");
                return new SelectElement(element);
            }
            catch (Exception ex)
            {
                ReportManager.LogError(ex.Message);
                throw new FunctionalTestException(ex.Message);
            }
        }

        public static void SelectByValue(this By identifier, IWebDriver driver, string value)
        {
            var element = SelectElement(identifier, driver);

            element.SelectByValue(value);
            ReportManager.LogInfo($"Select By Value element: {identifier} value: {value}");
        }

        public static void SelectByIndex(this By identifier, IWebDriver driver, int index)
        {
            var element = SelectElement(identifier, driver);

            element.SelectByIndex(index);
            ReportManager.LogInfo($"Select By Index");
        }

        public static void SelectByText(this By identifier, IWebDriver driver, string text)
        {
            var element = SelectElement(identifier, driver);

            element.SelectByText(text);
            ReportManager.LogInfo($"Select By Value element: {identifier} text: {text}");
        }
    }
}