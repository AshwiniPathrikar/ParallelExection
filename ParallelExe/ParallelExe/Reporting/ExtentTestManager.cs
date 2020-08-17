using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParallelExe.Reporting
{
    class ExtentTestManager
    {
        /*When an object has a field annotated with ThreadStatic, that field is shared within a given thread, but unique across threads. */
        [ThreadStatic]
        private static ExtentTest _parentTest;

        [ThreadStatic]
        private static ExtentTest _childTest;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateParentTest(string testName, string description = null)
        {
            _parentTest = ExtentManager.Instance.CreateTest(testName, description);
            _childTest = _parentTest.CreateNode(testName, description);
            return _parentTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string testName, string description = null)
        {
            _childTest = _parentTest.CreateNode(testName, description);
            return _childTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateNodeFailed(string testName, string description = null)
        {
            //ExtentTest
            _childTest.Log(Status.Fail, testName);
            //_childTest = _parentTest.CreateNode(testName, Status.Info.ToString());   
           ExtentManager.Instance.Flush();

            return _childTest;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateNodePassed(string testName, string description = null)
        {
            _childTest.Log(Status.Pass, testName);
            //_childTest = _parentTest.CreateNode(testName, Status.Info.ToString()); 
            return _childTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        {
            return _childTest;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void TestPass(string message, string description = null)
        {
            _childTest.Pass(message);
            //_childTest = _parentTest.CreateNode(testName, description);
            // return _childTest;
        }
    }

}
