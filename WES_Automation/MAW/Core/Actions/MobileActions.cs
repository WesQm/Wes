using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
using System;

using WES.Core.TestHooks;
using WES.Core.Utils;

namespace WES.Core.Actions
{
    class MobileActions : BaseMobileTest
    {
        ITouchAction touchAction;

        /**
		 * =============================================================================
		 * Method: waitForVisible | Author: Rajesh Buddha | Date:16 Jan 2020 |
		 * Description: This method wait for element it will check every 5 sec its
		 * present or not until 60 sec | Parameters: locator | Return: element
		 * =============================================================================
		 */
        public static IWebElement WaitForElementToBeVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Browser.GetBrowser(), TimeSpan.FromSeconds(60));
            IWebElement elementFound = wait.Until(e => e.FindElement(locator));
            return elementFound;
        }



        /**
* =============================================================================
* Method: Click | Author: Rajesh Buddha | Date:16 Jan 2020 | Description: This
* method click on element | Parameters: locator, info | Return: none
* =============================================================================
*/
        public void click(By locator, String info)
        {
            WaitForElementToBeVisible(locator);
            Mobile.GetMobileDriver()
                .FindElement(locator)
                .Click();
            MobileReporter.Log.Info("Successfully clicked on - " + info);
        }

        /**
		 * =============================================================================
		 * Method: sendKeys | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method enter text input text using element | Parameters: locator, text |
		 * Return: none
		 * =============================================================================
		 */
        public void sendKeys(By locator, String text)
        {

            WaitForElementToBeVisible(locator);
            Mobile.GetMobileDriver()
               .FindElement(locator).SendKeys(text);
            MobileReporter.Log.Info("Successfully Entered text - " + text);
            Console.WriteLine("Successfully Entered text - " + text);
        }

        /**
		 * =============================================================================
		 * Method: sendKeys | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method enter text input text using element | Parameters: locator, text |
		 * Return: none
		 * =============================================================================
		 */
        public void sendKeys(By locator, String text, String info)
        {
            WaitForElementToBeVisible(locator);
            Mobile.GetMobileDriver()
               .FindElement(locator).Click();
            Mobile.GetMobileDriver()
               .FindElement(locator).SendKeys(text);
            MobileReporter.Log.Info(info + " <b style=\"color:green;\"> : " + text + "</b>");
            //LogClass.loginfo(info+" :"+text);
        }

        /**
		 * =============================================================================
		 * Method: clearAndSendKeys | Author: Rajesh Buddha | Date:16 Jan 2020 |
		 * Description: This method clear text in text box after that enter text using
		 * element | Parameters: locator, text | Return: none
		 * =============================================================================
		 */
        public void clearAndSendKeys(By locator, String text)
        {
            WaitForElementToBeVisible(locator);
            Mobile.GetMobileDriver()
               .FindElement(locator).Clear();
            Mobile.GetMobileDriver()
               .FindElement(locator).SendKeys(text);
            MobileReporter.Log.Info("Successfully Entered text -<b style=\"color:green;\"> " + text + "</b>");
            //LogClass.loginfo("Successfully Entered text - " + text);
        }

        /**
		 * =============================================================================
		 * Method: clearAndSendKeys | Author: Rajesh Buddha | Date:16 Jan 2020 |
		 * Description: This method clear text in text box after that enter text using
		 * element | Parameters: locator, text | Return: none
		 * =============================================================================
		 */
        public void clearAndSendKeys(By locator, String text, String info)
        {
            WaitForElementToBeVisible(locator);
            Mobile.GetMobileDriver()
               .FindElement(locator).Clear();
            Mobile.GetMobileDriver()
               .FindElement(locator).SendKeys(text);
            MobileReporter.Log.Info(info + "<b style=\"color:green;\"> :" + text + "</b>");
            //LogClass.loginfo(info+" : " + text);
        }
        /**
		 * =============================================================================
		 * Method: getText | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method get the text of element | Parameters: locator | Return: elmText
		 * =============================================================================
		 */
        public String getText(By locator)
        {
            WaitForElementToBeVisible(locator);
            String elmText = Mobile.GetMobileDriver()
                .FindElement(locator).Text;
            MobileReporter.Log.Info("Successfully get text - <b style=\"color:green;\">" + elmText + "</b>");
            Console.WriteLine("Successfully get text - " + elmText);
            //LogClass.loginfo("Successfully get text - " + elmText);
            return elmText;
        }
        /**
		 * =============================================================================
		 * Method: getText | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method get the text of element | Parameters: locator | Return: elmText
		 * =============================================================================
		 */
        public String getText(By locator, String info)
        {
            WaitForElementToBeVisible(locator);
            String elmText = Mobile.GetMobileDriver()
                .FindElement(locator).Text;
            MobileReporter.Log.Info("" + info + "<b style=\"color:green;\"> :" + elmText + "</b>");
            //LogClass.loginfo(""+info+" : " + elmText);
            return elmText;
        }
        /**
		 * =============================================================================
		 * Method: swipeUp | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method swipe up in mobile using touch action and enter int value number
		 * of times it should swipe| Parameters: howManySwipes | Return: none
		 * =============================================================================
		 */

        public void swipeUp(int howManySwipes)
        {
            //size = Mobile.GetMobileDriver().Manage().Window.Size;
            // calculate coordinates for vertical swipe
            int startY = (int)(Mobile.GetMobileDriver().Manage().Window.Size.Height * 0.70);
            int endY = (int)(Mobile.GetMobileDriver().Manage().Window.Size.Height * 0.30);
            int startX = (Mobile.GetMobileDriver().Manage().Window.Size.Width / 2);
            try
            {
                for (int i = 1; i <= howManySwipes; i++)
                {
                    new TouchAction(Mobile.GetMobileDriver())
                            .Press(startX, startY).MoveTo(startX, endY).Release()
                            .Perform();
                    Console.WriteLine("swipeUp");
                }
            }
            catch (Exception e)
            {
                // print error or something
            }
        }

        /**
		 * =============================================================================
		 * Method: swipeDown | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method swipe down in mobile using touch action and enter int value
		 * number of times it should swipe| Parameters: howManySwipes | Return: none
		 * =============================================================================
		 */
        public void swipeDown(int howManySwipes)
        {
            // calculate coordinates for vertical swipe
            //Dimension size = Mobile.GetMobileDriver().manage().window().getSize();
            int startY = (int)(Mobile.GetMobileDriver().Manage().Window.Size.Height * 0.70);
            int endY = (int)(Mobile.GetMobileDriver().Manage().Window.Size.Height * 0.30);
            int startX = (Mobile.GetMobileDriver().Manage().Window.Size.Width / 2);
            try
            {
                for (int i = 1; i <= howManySwipes; i++)
                {
                    new TouchAction(Mobile.GetMobileDriver())
                            .LongPress(startX, endY).MoveTo(startX, startY).Release()
                            .Perform();
                    Console.WriteLine("swipeDown");
                }
            }
            catch (Exception e)
            {
                // print error or something
            }
        }

        /**
		 * =============================================================================
		 * Method: swipeRighttoLeft | Author: Rajesh Buddha | Date:16 Jan 2020 |
		 * Description: This method swipe right to left in mobile using touch action and
		 * enter int value number of times it should swipe| Parameters: howManySwipes |
		 * Return: none
		 * =============================================================================
		 */
        public void swipeRighttoLeft(int howManySwipes)
        {
            // Dimension size = Mobile.GetMobileDriver().manage().window().getSize();
            // calculate coordinates for horizontal swipe
            int startY = (int)(Mobile.GetMobileDriver().Manage().Window.Size.Height / 2);
            int startX = (int)(Mobile.GetMobileDriver().Manage().Window.Size.Width * 0.90);
            int endX = (int)(Mobile.GetMobileDriver().Manage().Window.Size.Width * 0.10);
            try
            {
                for (int i = 1; i <= howManySwipes; i++)
                {
                    new TouchAction(Mobile.GetMobileDriver())
                            .LongPress(startX, startY).MoveTo(endX, startY).Release()
                            .Perform();
                    Console.WriteLine("swipeRighttoLeft");
                }
            }
            catch (Exception e)
            {
                // print error or something
            }
        }

        /**
		 * =============================================================================
		 * Method: swipeLefttoRight | Author: Rajesh Buddha | Date:16 Jan 2020 |
		 * Description: This method swipe left to right in mobile using touch action and
		 * enter int value number of times it should swipe| Parameters: howManySwipes |
		 * Return: none
		 * =============================================================================
		 */
        public void swipeLefttoRight(int howManySwipes)
        {
            //Dimension size = Mobile.GetMobileDriver().manage().window().getSize();
            // calculate coordinates for horizontal swipe
            int startY = (int)(Mobile.GetMobileDriver().Manage().Window.Size.Height / 2);
            int startX = (int)(Mobile.GetMobileDriver().Manage().Window.Size.Width * 0.10);
            int endX = (int)(Mobile.GetMobileDriver().Manage().Window.Size.Width * 0.90);
            try
            {
                for (int i = 1; i <= howManySwipes; i++)
                {
                    new TouchAction(Mobile.GetMobileDriver())
                            .LongPress(startX, startY).MoveTo(endX, startY).Release()
                            .Perform();
                    Console.WriteLine("swipeLefttoRight");
                }
            }
            catch (Exception e)
            {
                // print error or something
            }
        }

        /**
		 * =============================================================================
		 * Method: swipeUp_FindElementClick | Author: Rajesh Buddha | Date:16 Jan 2020 |
		 * Description: This method will swipe till element found and click| Parameters:
		 * howManySwipes, locator | Return: none
		 * =============================================================================
		 */
        public void swipeUp_FindElementClick(int howManySwipes, By locator)
        {
            //Dimension size = Mobile.GetMobileDriver().manage().window().getSize();
            // calculate coordinates for vertical swipe
            int startY = (int)(Mobile.GetMobileDriver().Manage().Window.Size.Height * 0.70);
            int endY = (int)(Mobile.GetMobileDriver().Manage().Window.Size.Height * 0.30);
            int startX = (Mobile.GetMobileDriver().Manage().Window.Size.Width / 2);
            try
            {
                for (int i = 1; i <= howManySwipes; i++)
                {
                    Boolean isElmPresent = Mobile.GetMobileDriver().FindElements(locator).Count > 0;
                    if (isElmPresent)
                    {
                        Mobile.GetMobileDriver().FindElement(locator).Click();
                        break;
                    }
                    new TouchAction(Mobile.GetMobileDriver())
                                        .LongPress(startX, startY).MoveTo(startX, endY).Release()
                                        .Perform();
                    Console.WriteLine("swipeUp");
                }
            }
            catch (Exception e)
            {
                // print error or something
            }
        }


        /**
         * =============================================================================
         * Method: rightToLeftSwipeUsingElement | Author: Rajesh Buddha | Date:16 Jan
         * 2020 | Description: This method right To Left Swipe Using Element |
         * Parameters: locator, text | Return: none
         * =============================================================================
         * 
         * @param fromLocator
         * @param toLocator
         * 
         * @throws InterruptedException
         */
        public int getTextByInt(By locator)
        {
            WaitForElementToBeVisible(locator);
            string elmText = Mobile.GetMobileDriver().FindElement(locator).Text;
            int elmIntTxt = int.Parse(elmText);
            MobileReporter.Log.Info("Successfully get Integer text - <b style=\"color:green;\">" + elmIntTxt + "</b>");
            Console.WriteLine("Successfully get Integer text- " + elmIntTxt);
            return elmIntTxt;
        }

        /**
         * =============================================================================
         * Method: clickUsingCoordinates | Author: Rajesh Buddha | Date:16 Jan 2020 |
         * Description: This method right To Left Swipe Using Element | Parameters:
         * locator, text | Return: none
         * =============================================================================
         * 
         * @param xcordinate
         * @param ycordinate
         * 
         * @param fromLocator
         * @param toLocator
         * 
         * @throws InterruptedException
         */
        public void clickUsingCoordinates(int xcordinate, int ycordinate)
        {

            new TouchAction(Mobile.GetMobileDriver()).Tap(xcordinate, ycordinate)
                    .Release().Perform();
        }

    }

}