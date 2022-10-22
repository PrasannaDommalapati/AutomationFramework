using OpenQA.Selenium;

namespace FunctionalTest.Pages
{
    public class BasePage
    {
        public IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
