using FunctionalTest.Common.Extensions;
using OpenQA.Selenium;

namespace FunctionalTest.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver) { }

        private readonly By SearchField = By.Name("q");
        private readonly By AcceptAllBtn = By.Id("L2AGLb");

        public void SearchText(string searchString)
        {
            SearchField.TypeInto(_driver, searchString);
        }

        public void ClickAcceptAll()
        {
            AcceptAllBtn.Click(_driver);
        }
    }
}
