using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using DocumentFormat.OpenXml.InkML;
using NPOI.SS.Util;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;


namespace WES.Core.Utils
{
    class ReportProvider
    {
        public ExtentHtmlReporter htmlReporter;
        public ExtentReports extent;
        public ConcurrentDictionary<int, ExtentTest> testMap = new ConcurrentDictionary<int, ExtentTest>();


        public ReportProvider(string name)
        {



            String timeStamp = new SimpleDateFormat("dd.MM.yyyy.HH.mm.ss").Format(new DateTime());
            Console.WriteLine(timeStamp);
            String dateStamp = new SimpleDateFormat("dd.MM.yyyy").Format(new DateTime());
            Console.WriteLine("Report object created");
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;



            if (!Directory.Exists(projectPath.ToString() + "Reports"))
                Directory.CreateDirectory(projectPath.ToString() + "Reports");



            var reportPath = projectPath + "Reports" + dateStamp + "/" + "QualityMatrixTest-" + timeStamp + ".html";
            htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "QualityMatrix");
            extent.AddSystemInfo("Environment", "Test Env");
            extent.AddSystemInfo("User Name", "Rajesh");

            OperatingSystem os = Environment.OSVersion;
            extent.AddSystemInfo("Operating System: ", os.Version.ToString());




        }


        public ExtentTest getTest()
        {
            if (testMap.ContainsKey(Thread.CurrentThread.ManagedThreadId))
            {
                return testMap[Thread.CurrentThread.ManagedThreadId];
            }
            return null;
        }
        public void CreateTest(string testName)
        {

            testMap[Thread.CurrentThread.ManagedThreadId] = extent.CreateTest(testName);
        }

        public void CreateTest(string testName, string desc)
        {

            testMap[System.Threading.Thread.CurrentThread.ManagedThreadId] = extent.CreateTest(testName, desc);
        }

        public void Info(string stepDescription)
        {
            getTest().Log(Status.Info, stepDescription);
        }

        public void Pass(string stepDescription)
        {
            getTest().Log(Status.Pass, stepDescription);
        }

        public void Fail(string stepDescription)
        {
            getTest().Log(Status.Fail, stepDescription);
        }

        public void Warning(string stepDescription)
        {
            getTest().Log(Status.Warning, stepDescription);
        }
        public void TestPass()
        {
            var printMessage = "<p><b>Test PASSED</b></p>";
            getTest().Pass(printMessage);

        }
        public void TestFail(string message)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }

            getTest().Log(Status.Fail, message);

        }
        public void AddScreenshot(string base64ScreenCapture)
        {
            getTest().AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot");
        }
        public void TestSkipped()
        {
            getTest().Skip("Test skipped!");
        }
        public void Close()
        {
            extent.Flush();
        }

    }



}
