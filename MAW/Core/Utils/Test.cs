using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMailOTP
{
    class Program
    {
        public static void Gmailotp() 
        {
            IWebDriver driver = new ChromeDriver();             // Navigate to the Gmail login page
            driver.Navigate().GoToUrl("https://accounts.google.com/v3/signin/identifier?dsh=S-855445043%3A1679494828601825&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ifkv=AQMjQ7SzNwYeXPWEYq1yLZS4mP_AEddCbTZ6P4a7FnuBBjM42O4xICxV7TFqQe7HhcHl1Lv4G3nx_g&rip=1&sacu=1&service=mail&flowName=GlifWebSignIn&flowEntry=ServiceLogin");             // Enter login credentials
            driver.FindElement(By.Id("identifierId")).SendKeys("wesqms@gmail.com");
            driver.FindElement(By.XPath("//span[contains(.,'Next')]")).Click();
            driver.FindElement(By.XPath("//input[contains(@type,'password')]")).SendKeys("Wesqms@123");
            driver.FindElement(By.XPath("//span[contains(.,'Next')]")).Click();             // Wait for page to load and navigate to inbox
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.FindElement(By.XPath("//table[@id=':22']//tbody//tr[1]")).Click();             // Search for email containing OTP
            driver.FindElement(By.CssSelector("input[placeholder='Search']")).SendKeys("OTP");
            driver.FindElement(By.CssSelector("button[title='Search']")).Click();             // Extract OTP from email content
            string otp = driver.FindElement(By.XPath("//td[contains(text(),'OTP')]")).Text; Console.WriteLine("OTP: " + otp); driver.Quit();
        }
    }
}