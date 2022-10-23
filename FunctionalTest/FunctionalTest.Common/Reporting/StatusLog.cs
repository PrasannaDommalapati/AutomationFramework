using AventStack.ExtentReports;

namespace FunctionalTest.Common.Reporting
{
    public class StatusLog
    {
        public static void Pass(string message)
        {
            ReportManager.GetTest().Pass(message);
        }
        
        public static void Fail(string message, MediaEntityModelProvider media = null)
        {
            ReportManager.GetTest().Fail(message, media);
        }

        public static void Skip(string message)
        {
            ReportManager.GetTest().Skip(message);
        }
    }
}
