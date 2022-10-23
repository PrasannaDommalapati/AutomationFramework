using AventStack.ExtentReports;
using FunctionalTest.Common.Reporting;
using FunctionalTest.Common.Utilities;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace FunctionalTest
{
    public class BaseTest
    {
        public IWebDriver _driver;
        public DriverUtil _driverUtil;
        public string _url;
        public Browser _browser;

        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Utility.GetRootDir())
                 .AddJsonFile("local.settings.json")
                 .AddJsonFile("qa.settings.json", optional: true, reloadOnChange: true)
                 .AddJsonFile("prod.settings.json", optional: true, reloadOnChange: true)
                 .Build();
            _url = config.GetValue<string>("baseUrl");
            _browser = Enum.Parse<Browser>(config.GetValue<string>("browser"));
            _driverUtil = new DriverUtil();
            ReportManager.CreateParentTest(GetType().Name);
        }

        [OneTimeTearDown]
        public void GlobalCleanUp()
        {
            ReportService.GetReport().Flush();
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
                        StatusLog.Pass("Test Passed");
                        break;
                    case TestStatus.Skipped:
                        StatusLog.Pass("Test Skipped");
                        break;
                    case TestStatus.Failed:
                        StatusLog.Fail("Test Failed");
                        StatusLog.Fail(errorMessage);
                        StatusLog.Fail(stackTrace);
                        StatusLog.Fail("Screenshot", CaptureScreenshot(TestContext.CurrentContext.Test.Name));
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
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot.AsBase64EncodedString, name).Build();
        }
    }
}
