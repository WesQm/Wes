using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;


namespace WES.Core.Utils
{
    class Reporter
    {
        static ExtentHtmlReporter htmlReporter;
        static ExtentReports extent;
        static ConcurrentDictionary<int, ExtentTest> testMap = new ConcurrentDictionary<int, ExtentTest>();


        static Reporter()
        {
            Console.WriteLine("Report object created");
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";
            htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            OperatingSystem os = Environment.OSVersion;
            extent.AddSystemInfo("Operating System: ", os.Version.ToString());
        }


        public static ExtentTest getTest()
        {
            if (testMap.ContainsKey(Thread.CurrentThread.ManagedThreadId))
            {
                return testMap[Thread.CurrentThread.ManagedThreadId];
            }
            return null;
        }
        public static void CreateTest(string testName)
        {

            testMap[Thread.CurrentThread.ManagedThreadId] = extent.CreateTest(testName);
        }

        public static void CreateTest(string testName, string desc)
        {

            testMap[System.Threading.Thread.CurrentThread.ManagedThreadId] = extent.CreateTest(testName, desc);
        }

        public static void Info(string stepDescription)
        {
            getTest().Log(Status.Info, stepDescription);
        }

        public static void Pass(string stepDescription)
        {
            getTest().Log(Status.Pass, stepDescription);
        }

        public static void Fail(string stepDescription)
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
        public static void TestFail(string message)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }

            getTest().Log(Status.Fail, message);

        }
        public static void AddScreenshot(string base64ScreenCapture)
        {
            getTest().AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot");
        }
        public static void TestSkipped()
        {
            getTest().Skip("Test skipped!");
        }
        public static void Close()
        {
            extent.Flush();
        }

    }



}
