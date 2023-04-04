using NUnit.Framework;
using OpenDialogWindowHandler;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using WES.Core.Utils;

namespace WES.Core.Actions
{
	class BrowserActions
	{

		public IWebElement WaitForElementExists(By locator)
		{
			WebDriverWait wait = new WebDriverWait(Browser.GetBrowser(), TimeSpan.FromSeconds(120));
			IWebElement elementc = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
			return elementc;
		}
		public void scrollUpUsingJS2()
		{

			IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.GetBrowser();
			js.ExecuteScript("window.scrollBy(0,-750)", "");
		}

		public void scrollDownUsingJS2()
		{

			IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.GetBrowser();
			js.ExecuteScript("window.scrollBy(0,550)", "");
		}
		public string randomIntegerThresholdDaily(int length)
		{
			const string chars = "012";
			return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[random.Next(s.Length)]).ToArray());
		}

		public string randomIntegerThresholdMonthly(int length)
		{
			const string chars = "012";
			return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[random.Next(s.Length)]).ToArray());
		}

		public string randomIntegerThresholdWeekly(int length)
		{
			const string chars = "01234567";
			return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[random.Next(s.Length)]).ToArray());
		}
		public static ReadOnlyCollection<IWebElement> elements(By locator)
		{
			return Browser.GetBrowser().FindElements(locator);

		}

		public static IWebElement element(By locator)
		{
			return Browser.Wait()
			   .Until(el => el.FindElement(locator));
		}

		public static void ClickJS(By locator)
		{
			// NSelene.Selene.GetWebBrowser.GetBrowser()();
			//NSelene.Selene.ExecuteScript("arg[0].click();",locator);
		}

		public static void ClearAndSendKey(By locator)
		{
			/* NSelene.Selene
				 .GetWebBrowser.GetBrowser()()
				 .FindElement(locator).Click();*/
			//NSelene.Selene.ExecuteScript("arg[0].click();",locator);
		}

		IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)Browser.GetBrowser();
		//Actions action = new Actions(Browser.GetBrowser());

		/**
		 * =============================================================================
		 * Method: waitForVisible | Author: Rajesh Buddha | Date:16 Jan 2020 |
		 * Description: This method wait for element it will check every 5 sec its
		 * present or not until 60 sec | Parameters: locator | Return: element
		 * =============================================================================
		 */
		public IWebElement WaitForElementToBeVisible(By locator)
		{
			WebDriverWait wait = new WebDriverWait(Browser.GetBrowser(), TimeSpan.FromSeconds(120));
			IWebElement elementFound = wait.Until(e => e.FindElement(locator));
			return elementFound;
		}


		/**
		 * =============================================================================
		 * Method: openURL | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method open url | Parameters: URL | Return: none
		 * =============================================================================
		 */
		public void openURL(string URL)
		{
			Browser.GetBrowser().Navigate().GoToUrl(URL);
			string strURL = Browser.GetBrowser().Url;

			WebReporter.Log.Info("Successfully Entered URL - " + "<b style=\"color:green;\">" + URL + "</b>");
			Console.WriteLine("Successfully Entered URL - " + URL);
		}

		/**
		 * =============================================================================
		 * Method: Click | Author: Rajesh Buddha | Date:16 Jan 2020 | Description: This
		 * method click on element | Parameters: locator, info | Return: none
		 * =============================================================================
		 */
		public void Click(By locator, String info)
		{
			WaitForElementToBeVisible(locator);
			Browser.GetBrowser().FindElement(locator).Click();
			WebReporter.Log.Info("Successfully clicked on - " + "<b style=\"color:green;\">" + info + "</b>");
			Console.WriteLine("Successfully clicked on - " + info);
		}

		public void waitForPagetoLoadComplete()
		{
			IJavaScriptExecutor j = (IJavaScriptExecutor)Browser.GetBrowser();
            j.ExecuteScript("return document.readyState").ToString().Equals("complete");
		}

		public void selectByVisibleTextWithSleep(By locator, string value)
		{
			WaitForElementToBeVisible(locator);
			Thread.Sleep(20000);
			IWebElement selElm = Browser.GetBrowser().FindElement(locator);
			SelectElement SelectAnEducation = new SelectElement(selElm);
			SelectAnEducation.SelectByText(value);
			WebReporter.Log.Info("Successfully selected dropdown value - " + "<b style=\"color:green;\">" + value + "</b>");
		}

		public void WaitForElementToBeVisible1(By locator)
		{
			WebDriverWait wait = new WebDriverWait(Browser.GetBrowser(), TimeSpan.FromSeconds(60));
			wait.Until(ExpectedConditions.ElementToBeClickable(locator));
		}

		public void scrollUpUsingJS()
		{

			javascriptExecutor.ExecuteScript(
		   "window.scrollBy(document.body.scrollHeight,0 || 0)", "document.documentElement.scrollHeight");
		}



		/**
		 * =============================================================================
		 * Method: Click | Author: Rajesh Buddha | Date:16 Jan 2020 | Description: This
		 * method click on element | Parameters: locator, info | Return: none
		 * =============================================================================
		 */
		public string GetEleText(By locator)
		{
			WaitForElementToBeVisible(locator);
			string elmText = Browser.GetBrowser().FindElement(locator).Text;
			WebReporter.Log.Info("Successfully get element text - " + "<b style=\"color:green;\">" + elmText + "</b>");
			Console.WriteLine("Successfully get element text - " + elmText);
			return elmText;
		}

		/**
		 * =============================================================================
		 * Method: ClickJSE | Author: Rajesh Buddha | Date:16 Jan 2020 | Description: This
		 * method click using java script on element | Parameters: locator, info | Return: none
		 * =============================================================================
		 */
		public void sendkeysJSE(By locator, string value)
		{
			WaitForElementToBeVisible(locator);
			Browser.GetBrowser().FindElement(locator).Clear();
			IWebElement element = Browser.GetBrowser().FindElement(locator);
			javascriptExecutor.ExecuteScript("arguments[0].click();", Browser.GetBrowser().FindElement(locator));
			IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.GetBrowser();
			js.ExecuteScript("arguments[0].value='" + value + "';", element);
			WebReporter.Log.Info("Successfully Entered text -" + value);
			Console.WriteLine("Successfully Entered text - " + value);

		}
		public void ClickJSE(By locator, String info)
		{
			WaitForElementToBeVisible(locator);
			javascriptExecutor.ExecuteScript("arguments[0].click();", Browser.GetBrowser().FindElement(locator));
			WebReporter.Log.Info("Successfully clicked on - " + "<b style=\"color:green;\">" + info + "</b>");
			Console.WriteLine("Successfully clicked on - " + info);
		}

		/**
		 * =============================================================================
		 * Method: sendKeys | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method enter text input text using element | Parameters: locator, text |
		 * Return: none
		 * =============================================================================
		 */
		public void SendKeys(By locator, String text)
		{
			WaitForElementToBeVisible(locator);
			ClickJSE(locator, "");
			Browser.GetBrowser().FindElement(locator).SendKeys(text);
			WebReporter.Log.Info("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
			Console.WriteLine("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
		}
		public void SendKeysInfo(By locator, String text, String info)
		{
			WaitForElementToBeVisible(locator);
			ClickJSE(locator, "");
			Browser.GetBrowser().FindElement(locator).SendKeys(text);
			WebReporter.Log.Info("Successfully Entered text - " + info + " :" + "<b style=\"color:green;\">" + text + "</b>");
		}

		public void UploadFile(string filepath, string filename)
		{
			HandleOpenDialog hndOpen = new HandleOpenDialog();
			hndOpen.fileOpenDialog(filepath, filename);
		}
		/**
		 * =============================================================================
		 * Method: sendKeys | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method enter text input text using element | Parameters: locator, text |
		 * Return: none
		 * =============================================================================
		 */
		public void sendKeyswithoutClick(By locator, String text)
		{
			WaitForElementToBeVisible(locator);
			Browser.GetBrowser().FindElement(locator).SendKeys(text);
			WebReporter.Log.Info("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
			Console.WriteLine("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
		}

        public void sendKeyswithClick(By locator, String text)
        {
            WaitForElementToBeVisible(locator);
            Browser.GetBrowser().FindElement(locator).SendKeys(text);
            Browser.GetBrowser().FindElement(locator).Click();
            WebReporter.Log.Info("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
            Console.WriteLine("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
        }
        public void sendKeyswithoutClickInfo(By locator, String text, String info)
		{
			WaitForElementToBeVisible(locator);
			Browser.GetBrowser().FindElement(locator).SendKeys(text);
			WebReporter.Log.Info("Successfully Entered text - " + info + " :" + "<b style=\"color:green;\">" + text + "</b>");
		}

		internal void clearAndSendKeys(object firstName, object fname)
		{
			throw new NotImplementedException();
		}
		public void sendKeysWithInfo(By locator, String text, String info)
		{
			WaitForElementToBeVisible(locator);
			Browser.GetBrowser().FindElement(locator).Clear();
			Browser.GetBrowser().FindElement(locator).SendKeys(text);
			WebReporter.Log.Info("Successfully Entered text - " + info + " :" + "<b style=\"color:green;\">" + text + "</b>");
		}

		/**
		 * =============================================================================
		 * Method: fileUploadsendKeys | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method upload file | Parameters: locator, text |
		 * Return: none
		 * =============================================================================
		 * @throws IOException 
		 */
		/*public void fileUploadsendKeys(By locator, String path){
		WaitForElementToBeVisible(locator);
		Thread.Sleep(2000);
		File f = new File(path); //file name will be entered by user at runtime
      //  Console.WriteLine(f.exists()); //will print "true" if the file name given by user exists, false otherwise

        if(f.exists())
        {
        	Browser.GetBrowser().FindElement(locator).Click();
        	Console.WriteLine("File exists at give path");
		StringSelection ss = new StringSelection(path);
		Toolkit.getDefaultToolkit().getSystemClipboard().setContents(ss, null); // copy the above string to clip board
		Robot robot;
		robot = new Robot();
		robot.delay(1000);
    		robot.keyPress(KeyEvent.VK_ENTER);
    		robot.keyRelease(KeyEvent.VK_ENTER);
    		robot.delay(2000);
    		robot.keyPress(KeyEvent.VK_CONTROL);
    		robot.keyPress(KeyEvent.VK_V);
    		robot.keyRelease(KeyEvent.VK_V);
    		robot.delay(2000);
    		robot.keyRelease(KeyEvent.VK_CONTROL); // paste the copied string into the dialog box
    		robot.keyPress(KeyEvent.VK_ENTER);
    		robot.keyRelease(KeyEvent.VK_ENTER); // enter
        }else {
        	BufferedImage image = new Robot().createScreenCapture(new Rectangle(Toolkit.getDefaultToolkit().getScreenSize()));
	ImageIO.write(image, "png", new File("D:\\POCs\\Maxval\\Reports\\Screenshots\\screenshot.png"));
        	Console.WriteLine("File Not exists at give pat");
	ReportManager.logScreenshotInfo();
        	ReportManager.logFail("File Not exists at give path");;
    		assertEquals(f.exists(), true);
}
		
		
	}*/




		/**
         * =============================================================================
         * Method: sendKeysfromKeyboard | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
         * This method will keyboard actions | Parameters: locator, text |
         * Return: none
         * =============================================================================
         */
		public void sendKeysfromKeyboard(By locator, string keyboardAction)
		{
			WaitForElementToBeVisible(locator);
			Browser.GetBrowser().FindElement(locator).SendKeys(keyboardAction + Keys.Enter);
			WebReporter.Log.Info("Successfully Entered text - " + keyboardAction);
			Console.WriteLine("Successfully Entered text - " + keyboardAction);
		}

		public Boolean isDisplayed(By locator, String info)
		{
			WaitForElementToBeVisible(locator);
			Boolean isPresent = Browser.GetBrowser().FindElement(locator).Displayed;
			if (isPresent)
			{
				WebReporter.Log.Info("Successfully element displayed: " + "<b style=\"color:green;\">" + info + "</b>");
				Console.WriteLine("Successfully element displayed: " + "<b style=\"color:green;\">" + info + "</b>");
			}
			else
			{
				WebReporter.Log.Info("element not displayed: " + "<b style=\"color:green;\">" + info + "</b>");
				Console.WriteLine("element not displayed: " + info);
			}
			return isPresent;
		}

		public Boolean isEnabled(By locator, String info)
		{
			WaitForElementToBeVisible(locator);
			Boolean isPresent = Browser.GetBrowser().FindElement(locator).Enabled;
			if (isPresent)
			{
				WebReporter.Log.Info("Successfully element displayed: " + "<b style=\"color:green;\">" + info + "</b>");
				Console.WriteLine("Successfully element displayed: " + "<b style=\"color:green;\">" + info + "</b>");
			}
			else
			{
				WebReporter.Log.Info("element not displayed: " + "<b style=\"color:green;\">" + info + "</b>");
				Console.WriteLine("element not displayed: " + "<b style=\"color:green;\">" + info + "</b>");
			}
			return isPresent;
		}
		public void clearAndSendKeysInfo(By locator, String text, String info)
		{
			WaitForElementToBeVisible(locator);
			Browser.GetBrowser().FindElement(locator).Clear();
			Browser.GetBrowser().FindElement(locator).SendKeys(text);
			WebReporter.Log.Info("Successfully Entered text - " + info + " :" + "<b style=\"color:green;\">" + text + "</b>");
		}

		public void clearAndSendKeys(By locator, String text)
		{
			WaitForElementToBeVisible(locator);
			Browser.GetBrowser().FindElement(locator).Clear();
			Browser.GetBrowser().FindElement(locator).SendKeys(text);
			WebReporter.Log.Info("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
			Console.WriteLine("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
		}

		public void verifyText(String actualText, String expectedText)
		{
			WebReporter.Log.Info("Actual Text - " + "<b style=\"color:green;\">" + actualText + "</b>");
			WebReporter.Log.Info("Expected Text - " + "<b style=\"color:green;\">" + expectedText + "</b>");
			Console.WriteLine("Actual Text - " + actualText);
			Console.WriteLine("Expected Text - " + expectedText);
			Assert.AreEqual(expectedText, actualText);
		}

		public void verifyIntValues(int actualValue, int expectedValue)
		{
			WebReporter.Log.Info("Actual Value - " + actualValue);
			WebReporter.Log.Info("Expected Value - " + expectedValue);
			Console.WriteLine("Actual Value - " + actualValue);
			Console.WriteLine("Expected Value - " + expectedValue);
			Assert.AreEqual(actualValue, expectedValue);
		}

		public String getAttributeValue(By locator, String name)
		{
			WaitForElementToBeVisible(locator);
			String attributeText = Browser.GetBrowser().FindElement(locator).GetAttribute(name);
			WebReporter.Log.Info("Successfully get attribute text - " + attributeText);
			Console.WriteLine("Successfully get attribute text - " + attributeText);
			return attributeText;
		}

		public Boolean isScrollPresent()
		{
			String execScript = "return document.documentElement.scrollHeight>document.documentElement.clientHeight;";
			Boolean isScroll_Present = (Boolean)(javascriptExecutor.ExecuteScript(execScript));
			return isScroll_Present;

		}

		public void scrollDownUsingJS()
		{

			javascriptExecutor.ExecuteScript(
					"window.scrollBy(0,document.body.scrollHeight || document.documentElement.scrollHeight)", "1000");
		}

		/*public void mouseHover(By locator)
		{
					WaitForElementToBeVisible(locator);
			action.moveToElement(Browser.GetBrowser().FindElement(locator)).build().perform();
			String Browser.GetBrowser().FindElement(locator)Text = Browser.GetBrowser().FindElement(locator).getText();
			WebReporter.Log.Info("Successfully mouse hover and get text - " + Browser.GetBrowser().FindElement(locator)Text);
			Console.WriteLine("Successfully mouse hover and get text - " + Browser.GetBrowser().FindElement(locator)Text);
		}*/

		public void switchToFrame(By locator)
		{
			WaitForElementToBeVisible(locator);
			Browser.GetBrowser().SwitchTo().Frame(Browser.GetBrowser().FindElement(locator));
			WebReporter.Log.Info("Successfully switched to frame ");
			Console.WriteLine("Successfully switched to frame ");
		}

		public ReadOnlyCollection<IWebElement> getListofElements(By locator, String name)
		{
			WaitForElementToBeVisible(locator);
			ReadOnlyCollection<IWebElement> lst_Elements = Browser.GetBrowser().FindElements(locator);
			WebReporter.Log.Info("Successfully get element size - " + lst_Elements.Count);
			Console.WriteLine("Successfully get element size - " + lst_Elements.Count);
			return lst_Elements;
		}

		public void selectByVisibleText(By locator, string value)
		{
			WaitForElementToBeVisible(locator);
			IWebElement selElm = Browser.GetBrowser().FindElement(locator);
			SelectElement SelectAnEducation = new SelectElement(selElm);
			SelectAnEducation.SelectByText(value);
			WebReporter.Log.Info("Successfully selected dropdown value - " + "<b style=\"color:green;\">" + value + "</b>");

		}
		public void selectByIndex(By locator, int value)
		{
			WaitForElementToBeVisible(locator);
			IWebElement selElm = Browser.GetBrowser().FindElement(locator);
			SelectElement SelectAnEducation = new SelectElement(selElm);
			SelectAnEducation.SelectByIndex(value);
			WebReporter.Log.Info("Successfully selected dropdown value - " + "<b style=\"color:green;\">" + value + "</b>");
		}
		public void switchTab()
		{
			

            WebDriverWait wait = new WebDriverWait(Browser.GetBrowser(), TimeSpan.FromSeconds(10));

			string originalWindow = Browser.GetBrowser().CurrentWindowHandle;

			//Check we don't have other windows open already
			Assert.AreEqual(Browser.GetBrowser().WindowHandles.Count, 1);

			//Click the link which opens in a new window
			Browser.GetBrowser().FindElement(By.LinkText("new window")).Click();

			//Wait for the new window or tab

			wait.Until(wd => wd.WindowHandles.Count == 2);

			//Loop through until we find a new window handle
			foreach (string window in Browser.GetBrowser().WindowHandles)
			{
				if (originalWindow != window)
				{
					Browser.GetBrowser().SwitchTo().Window(window);
					break;
				}
			}
			//Wait for the new tab to finish loading content
			wait.Until(wd => wd.Title == "Selenium documentation");
		}



		public void switchDefaultWindow()
		{

			Browser.GetBrowser().SwitchTo().DefaultContent();

		}

		private Random random = new Random();

		public string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}

		public string RandomInteger(int length)
		{
			const string chars = "1234567890";
			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());



		}

        public string RandomEmail(int length)
        {
            const string chars = "1234567890";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());



        }

       



        public void Validate(string actual, string expected)
		{
			Assert.AreEqual(actual, expected);
		}

		internal void ClickJSE(object home_icon, string v)
		{
			throw new NotImplementedException();
		}

		internal void Click(object rental_Agreement, string v)
		{
			throw new NotImplementedException();
		}

		internal void verifyText(By expectedpage_tittle, string v)
		{
			throw new NotImplementedException();
		}

        internal string getElmText(By evaluation_subType)
        {
            throw new NotImplementedException();
        }
    }


}
