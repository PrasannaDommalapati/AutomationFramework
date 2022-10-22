using FunctionalTest.Common.Reporting;
using FunctionalTest.Pages;

namespace FunctionalTest
{
    [TestFixture]
    public class ExampleTests : BaseTest
    {
        private SearchPage _searchPage;

        [SetUp, Order(1)]
        public void SetUpp()
        {
            _searchPage = new SearchPage(_driver);
        }

        [Test]
        public void Test1()
        {
            _searchPage.ClickAcceptAll();
            ReportManager.LogInfo("Step1");
            _searchPage.SearchText("hello");
            ReportManager.LogError("Step2");
            ReportManager.LogInfo("Step3");
            ReportManager.LogError("Step4");
            Assert.Pass();
        }
        
        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
    }
}