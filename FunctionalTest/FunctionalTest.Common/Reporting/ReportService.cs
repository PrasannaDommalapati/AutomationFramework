using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using FunctionalTest.Common.Utilities;

namespace FunctionalTest.Common.Reporting
{
    public class ReportService
    {
        public static ExtentReports _extentReports;

        public static ExtentReports GetReport()
        {
            if(_extentReports is null)
            {
                _extentReports = new ExtentReports();

                string reportingDir = Path.Combine(Utility.GetRootDir(), "TestReports");

                if(!Directory.Exists(reportingDir))
                    Directory.CreateDirectory(reportingDir);

                string path = Path.Combine(reportingDir, "index.html");
                var reporter = new ExtentHtmlReporter(path);

                reporter.Config.DocumentTitle = "Functional Report";
                reporter.Config.ReportName = "Test Automation Report";
                reporter.Config.Theme = Theme.Dark;

                _extentReports.AttachReporter(reporter);
            }

            return _extentReports;
        }
    }
}
