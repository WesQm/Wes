using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Appium.Enums;

using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using System.Threading;
using System.IO;
using NUnit.Framework;

namespace WES.Core.Utils
{
    class Mobile
    {
        private static AppiumLocalService LocalService;

        static ConcurrentDictionary<int, AppiumDriver<AppiumWebElement>> appiumMap = new ConcurrentDictionary<int, AppiumDriver<AppiumWebElement>>();
        public static double DEFAULT_WAIT = 30;

        public static String CURRENT_MOBILE { get; set; }


        public static void LaunchMobile()
        {

            string currentPlatform = "android";
            if (currentPlatform.Equals("android"))
            {

                LaunchAndroid();
            }
            else
            {
                LaunchIos();
            }
        }


        public static void LaunchAndroid()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus API 28");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\user\Downloads\com.flipkart.android.1290008.apk");

            //emulator-5554
            appiumMap[Thread.CurrentThread.ManagedThreadId] = new AndroidDriver<AppiumWebElement>(LocalService, appiumOptions);

            Console.WriteLine("WebDriver response received.");


        }

        public static void LaunchIos()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus API 28");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "IOS");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "5554");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\sukh\Downloads\com.flipkart.android.1290008\com.flipkart.android.1290008.apk");

            //emulator-5554
            appiumMap[Thread.CurrentThread.ManagedThreadId] = new AndroidDriver<AppiumWebElement>(LocalService, appiumOptions);

            Console.WriteLine("WebDriver response received.");

        }

        public static void StartAppiumServer()
        {

            OptionCollector args = new OptionCollector()
                .AddArguments(GeneralOptionList.CallbackAddress("0.0.0.0"))
                .AddArguments(GeneralOptionList.OverrideSession());
            try
            {
                LocalService = new AppiumServiceBuilder().WithArguments(args).Build();
                LocalService.Start();
                Assert.IsTrue(LocalService.IsRunning);
                Console.WriteLine(LocalService.ServiceUrl.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while starting appium server: " + ex.Message);
            }
        }


        public static AppiumDriver<AppiumWebElement> GetMobileDriver()
        {
            return appiumMap[System.Threading.Thread.CurrentThread.ManagedThreadId];

        }

        public static void StopAppiumServer()
        {
            if (LocalService != null && LocalService.IsRunning)
            {
                LocalService.Dispose();
                LocalService = null;
            }
        }

        public static void Close()
        {

            try
            {
                appiumMap[Thread.CurrentThread.ManagedThreadId].Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while closing driver:" + ex.Message);
            }

            finally
            {

            }


        }


    }
}
