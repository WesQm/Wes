
using AventStack.ExtentReports;
using DocumentFormat.OpenXml.InkML;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WES.Core.Utils;

namespace WES.Core.TestHooks
{
    class BaseWebTest : BaseTest
    {

        [SetUp]
        public void setUp()
        {

            Browser.LaunchBrowser();
            Browser.GetBrowser().Navigate().GoToUrl("https://mfilestest.wes.org/createaccount/login/login");
            
        }

        [TearDown]
        public void tearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                WebReporter.Log.TestFail(TestContext.CurrentContext.Result.StackTrace);
                WebReporter.Log.AddScreenshot(Browser.GetScreenshotBase64());
            }

            WebReporter.Log.Close();
            Browser.CloseBrowser();
        }
    }
}
