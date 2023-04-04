using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WES.Core.Utils;

namespace WES.Core.TestHooks
{
    class BaseMobileTest : BaseTest
    {

        [OneTimeSetUp]
        public void suiteSetUp()
        {
            Mobile.StartAppiumServer();
        }

        [OneTimeTearDown]
        public void suiteTearDown()
        {
            Mobile.StopAppiumServer();
        }

    }
}
