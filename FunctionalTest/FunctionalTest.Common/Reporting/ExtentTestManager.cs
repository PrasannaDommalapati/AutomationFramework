using AventStack.ExtentReports;
using System.Runtime.CompilerServices;

namespace FunctionalTest.Common.Reporting
{
    public class ExtentTestManager
    {
        [ThreadStatic]
        public static ExtentTest _parentTest;
        
        [ThreadStatic]
        public static ExtentTest _childTest;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateParentTest(string testName, string description = null)
        {
            _parentTest = ExtentService.GetReport().CreateTest(testName, description);
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
    }
}
