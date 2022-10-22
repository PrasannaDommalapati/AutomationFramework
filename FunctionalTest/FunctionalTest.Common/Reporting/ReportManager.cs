using AventStack.ExtentReports;
using System.Runtime.CompilerServices;

namespace FunctionalTest.Common.Reporting
{
    public class ReportManager
    {
        [ThreadStatic]
        public static ExtentTest _parentTest;
        
        [ThreadStatic]
        public static ExtentTest _childTest;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateParentTest(string testName, string description = null)
        {
            _parentTest = ReportService.GetReport().CreateTest(testName, description);
            return _parentTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string testName, string description = null)
        {
            _childTest =_parentTest.CreateNode(testName, description);
            return _childTest;
        }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        {
            return _childTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void LogInfo(string message)
        {
            _childTest.Log(Status.Info, message);
        }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void LogError(string message, MediaEntityModelProvider media = null)
        {
            _childTest.Log(Status.Fail, message, media);
        }
    }
}
