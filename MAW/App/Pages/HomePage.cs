using System;
using System.Collections.Generic;
using System.Text;

using NSelene;
using OpenQA.Selenium;
using WES.Core.Utils;

namespace WES.App.Pages
{
    class HomePage
    {
        public void Serach(String data)
        {
            Reporter.Info("Search something: " + data);

            Browser.GetBrowser().FindElement(By.CssSelector("[name='q']"))
                .SendKeys(data);

            /*Selene
                .S("[name='q']")
               .SetValue(data)
               .PressEnter();*/

        }

        internal void login()
        {
            throw new NotImplementedException();
        }
    }
}
