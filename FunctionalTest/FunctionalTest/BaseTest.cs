using AventStack.ExtentReports;
using FunctionalTest.Common.Reporting;
using FunctionalTest.Common.Utilities;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace FunctionalTest
{
    public class BaseTest
    {
        private IWebDriver _driver;
        private DriverUtil _driverUtil;
        private string _url = "https://www.google.co.uk";
        private Browser _browser= Browser.CHROME;

        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            _driverUtil = new DriverUtil();
            ExtentTestManager.CreateParentTest(GetType().Name);
        }

        [OneTimeTearDown]
        public void GlobalCleanUp()
        {
            ExtentService.GetReport().Flush();
        }

        [SetUp]
        public void SetUp()
        {
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
           _driver = _driverUtil.GetDriver(_browser);
            _driver.Navigate().GoToUrl(_url);
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var resultMessage = TestContext.CurrentContext.Result.Message;
            var trace = TestContext.CurrentContext.Result.StackTrace;

            var errorMessage = string.IsNullOrWhiteSpace(resultMessage) ? "" : $"<pre>{resultMessage}</pre>";
            var stackTrace = string.IsNullOrWhiteSpace(trace) ? "" : $"<pre>{trace}</pre>"; ;

            try
            {
                switch (status)
                {
                    case TestStatus.Passed:
                        ReportLog.Pass("Test Passed");
                        break;
                    case TestStatus.Skipped:
                        ReportLog.Pass("Test Skipped");
                        break;
                    case TestStatus.Failed:
                        ReportLog.Fail("Test Failed");
                        ReportLog.Fail(errorMessage);
                        ReportLog.Fail(stackTrace);
                        ReportLog.Fail("Screenshot", CaptureScreenshot(TestContext.CurrentContext.Test.Name));
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception:- {ex.Message}");
            }
            finally
            {
                _driver.Quit();
            }
        }

        private MediaEntityModelProvider CaptureScreenshot(string name)
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromPath(name, screenshot)
                                     .Build();
        }
    }
}
