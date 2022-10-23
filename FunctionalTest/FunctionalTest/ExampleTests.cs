using FunctionalTest.Common.Reporting;
using FunctionalTest.Pages;

namespace FunctionalTest
{
    [TestFixture]
    public class ExampleTests : BaseTest
    {
        private SearchPage _searchPage;

        [SetUp]
        public void SetUp()
        {
            ReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
            _driver = _driverUtil.GetDriver(_browser);
            _driver.Navigate().GoToUrl(_url);
            _searchPage = new SearchPage(_driver);
        }

        [Test]
        public void Test1()
        {
            _searchPage.ClickAcceptAll();
            ReportManager.LogInfo("Step1");
            Assert.True(_driver.Title.Contains("Gooogle"));
            _searchPage.SearchText("hello");
            ReportManager.LogError("Step2");
            ReportManager.LogInfo("Step3");
            ReportManager.LogError("Step4");
            Assert.True(_driver.Title.Contains("Gooogle"));
        }

        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
    }
}