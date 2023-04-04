using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using NSelene;
using OpenQA.Selenium.IE;
using System.Collections.Concurrent;
using OpenQA.Selenium.Support.UI;

namespace WES.Core.Utils
{
    class Browser
    {
        static ConcurrentDictionary<int, IWebDriver> browserMap = new ConcurrentDictionary<int, IWebDriver>();
        public static double DEFAULT_WAIT = 50;

        public static String CURRENT_BROWSER { get; set; }

        public static void LaunchBrowser()
        {

            // string val = ConfigurationManager.AppSettings["browser"];
            string val = "chrome";

            Console.WriteLine("Current browser: " + val);
            switch (val)
            {
                case "firefox":
                    Console.WriteLine("Firefox going to launch");
                    LaunchFirefoxBrowser();
                    break;
                case "edge":
                    Console.WriteLine("Edge going to launch");
                    LaunchEdgeBrowser();
                    break;
                case "ie":
                    Console.WriteLine("Edge going to launch");
                    LaunchIEBrowser();
                    break;

                default:
                    Console.WriteLine("Chrome going to launch");
                    LaunchChromeBrowser();
                    break;
            }


            // Selene.SetWebDriver(_webDriver);
            browserMap[System.Threading.Thread.CurrentThread.ManagedThreadId].Manage().Window.Maximize();

        }

        private static void LaunchChromeBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            browserMap[System.Threading.Thread.CurrentThread.ManagedThreadId] = new ChromeDriver();
        }

        private static void LaunchFirefoxBrowser()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            browserMap[System.Threading.Thread.CurrentThread.ManagedThreadId] = new FirefoxDriver();

        }

        private static void LaunchEdgeBrowser()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            browserMap[System.Threading.Thread.CurrentThread.ManagedThreadId] = new EdgeDriver();
        }

        private static void LaunchIEBrowser()
        {
            new DriverManager().SetUpDriver(new InternetExplorerConfig());
            browserMap[System.Threading.Thread.CurrentThread.ManagedThreadId] = new InternetExplorerDriver();
        }

        public static void CloseBrowser()
        {
            //_webDriver.Quit();
            //  Selene.GetWebDriver().Quit();
            browserMap[System.Threading.Thread.CurrentThread.ManagedThreadId].Quit();


        }


        public static IWebDriver GetBrowser()
        {
            return browserMap[System.Threading.Thread.CurrentThread.ManagedThreadId];

        }

        public void Open(string url)
        {
            Selene.Open(url);
            //_webDriver.Navigate().GoToUrl(url);
        }

        public void Click(By locator)
        {
            // _webDriver.FindElement(locator).Click();
            Selene.S(locator).Click();
        }

        public static string GetScreenshotBase64()
        {
            ITakesScreenshot screenshotDriver = GetBrowser() as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            return screenshot.AsBase64EncodedString;

        }

        public static DefaultWait<IWebDriver> Wait()
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(GetBrowser());
            fluentWait.Timeout = TimeSpan.FromSeconds(DEFAULT_WAIT);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(450);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";
            return fluentWait;
        }

       
    }
}
