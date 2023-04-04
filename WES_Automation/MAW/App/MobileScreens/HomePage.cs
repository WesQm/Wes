
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WES.Core.Actions;
using WES.Core.Utils;

namespace WESHybridFramework.App.MobileScreens
{
    class HomePage
    {

        // ==================Login=======================
        By chk_language = By.XPath("//android.widget.TextView[@text='English']");
        By btn_continue = By.XPath("(//android.widget.Button[@resource-id='com.flipkart.android:id/select_btn'])");
        By input_phone = By.Id("com.flipkart.android:id/phone_input");
        By txt_cancel = By.Id("com.google.android.gms:id/cancel");
        By btn_senOtp = By.XPath("//android.widget.TextView[@text='Send OTP']");

        /**
		 * =============================================================================
		 * Method: login | Author: Rajesh Buddha | Date:16 Jan 2020 | Description: This
		 * method wait for element it will check every 5 sec its present or not until 60
		 * sec | Parameters: None | Return: None
		 * =============================================================================
		 */

        MobileActions mobileActions = new MobileActions();

        public void login()
        {
            mobileActions.swipeUp_FindElementClick(10, chk_language);
            mobileActions.click(chk_language, "chk_language");
            mobileActions.click(btn_continue, "btn_continue");
            Thread.Sleep(5);
            Boolean isCancel = Mobile.GetMobileDriver().FindElements(txt_cancel).Count > 0;
            if (isCancel)
            {
                if (isCancel)
                {
                    mobileActions.click(txt_cancel, "Cancel");
                }
                mobileActions.click(input_phone, "input_phone");
                Thread.Sleep(3000);
                mobileActions.clearAndSendKeys(input_phone, "8360187457");
                Thread.Sleep(15000);
                mobileActions.click(btn_senOtp, "Sent OTP");
                Thread.Sleep(60000);

            }

        }
    }
}
