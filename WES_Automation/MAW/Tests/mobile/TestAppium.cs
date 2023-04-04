
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WES.App.Pages;
using WES.Core.TestHooks;
using WES.Core.Utils;

namespace WES.Tests.mobile
{
    class TestAppium : BaseMobileTest
    {

        [Test]
        public void test()
        {
            MobileReporter.Log.CreateTest("This is  sample");
            HomePage homePage = new HomePage();
            Mobile.LaunchAndroid();
            homePage.login();
            Mobile.Close();
            MobileReporter.Log.Close();



        }

    }
}
