using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelExe.Reporting
{
    class ExtentManager
    {
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return _lazy.Value; } }
        static ExtentReports extent;
        static ExtentManager()
        {
            //var htmlReporter = new ExtentHtmlReporter(TestContext.CurrentContext.TestDirectory + "\\Extent.html");
            //htmlReporter.Configuration().Theme = Theme.Standard;
            //htmlReporter.Configuration().DocumentTitle = "Document Title";
            //htmlReporter.Configuration().ReportName = "Report Name";
            //Instance.AttachReporter(htmlReporter);

            string currentDate = DateTime.Now.ToString("dddd, dd MMMM yyyy ");
            string currentTime = DateTime.Now.ToShortTimeString().ToString().Replace(":", ".");
            string currentDateTime = currentDate + currentTime;
            string Path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string ActualPath = Path.Substring(0, Path.LastIndexOf("bin"));
            string ProjectPath = new Uri(ActualPath + "\\TestReport").LocalPath;
           // string ProjectPath = new Uri(ActualPath + @"\TestResult\").LocalPath;
            string ReportPath = ProjectPath + @"AutomationReports" + currentDateTime + ".html";


            var htmlReport = new ExtentHtmlReporter(ReportPath);
            htmlReport.Configuration().Theme = Theme.Standard;
            htmlReport.Configuration().DocumentTitle = "Document Title";
            htmlReport.Configuration().ReportName = "Report Name";
            Instance.AttachReporter(htmlReport);

            htmlReport.Start();
            extent = new ExtentReports();
            htmlReport.AppendExisting = true;
            extent.AttachReporter(htmlReport);
            //ExtentTest test = extent.CreateTest("ExtentManagerFie");
            //ExtentTestManager.CreateTest("Test");
        }
    }
}
