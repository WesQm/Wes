using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using Org.BouncyCastle.Crypto.Prng;
using WES.Core.Actions;
using WES.Core.Utils;
using WESHybridFramework.Core.Utils;
using WindowsInput;

namespace WES_Web_UI_Automation.WESPageObjetPages
{
    class WESWeb_CreateWESAccount_IRCC
    {
        // =====================New Account Creation======================//

        By btn_Submit = By.XPath("//button[@type='submit']");
        By lnk_Continue = By.XPath("//a[contains(.,'Continue')]");

        //----------------------Validate Email-----------------------------
        By lnk_NewAccountCreation = By.XPath("//a[contains(.,'New to WES? Create an account.')]");
        By button_Canada = By.XPath("//button[@name='equvCtry'][contains(.,'Canada')]");
        By buttonCanada_Standard = By.XPath("//button[contains(@value,'CIC')]");
        By input_NewAccount_Email = By.Id("Email");
        By txt_Verification_Complete = By.XPath("//h2[contains(.,'Verification Complete')]");
        By txt_success_message = By.XPath("//p[contains(.,'Your email address has been successfully verified. Thank you!')]");
        //----------------------Fill create account form-----------------------------
        By input_UserFirstName = By.Name("UserFirstName");
        By input_UserLastName = By.Name("UserLastName");
        By dd_db_Month = By.XPath("//select[@name='Month']");
        By dd_db_Day = By.Id("Day");
        By dd_db_Year = By.Id("Year");
        By input_Password = By.Id("UserPassword");
        By input_ConfirmPassword = By.Id("ConfirmPassword");
        By dd_UserSecurityQuestion = By.Id("UserSecurityQuestion");
        By input_UserSecurityAnswer = By.Id("UserSecurityAnswer");
        By create_Account_btn = By.Id("btnCreateAccount");
        //---------------------Personal Information-------------------------------------
        By about_Wes = By.Id("SelectedMarketingCode");
        By Gender = By.Id("Gender");
        By select_Country = By.Id("SelectedPhoneCountry");
        By city_Code = By.Id("Telephone");
        By next_Btn = By.Id("btnMoveToNextTab");
        //--------------------Report Purpose-----------------------------
        By application_Type = By.XPath("//span[text()='Education']");
        By level_of_Education = By.Id("SelectedLevelEducation");
        By next_btn = By.XPath("//button[@id='btnMoveToNextTab']");
        //------------------Your Education----------------------------
        By add_Credential = By.Id("loadCredentialPopup");
        By country_territory = By.Id("ddlCountry");
        By type_of_Education = By.Id("ddlInstType");
        By apply_type = By.Id("ddlInstSubType");
        By institution_name = By.Id("txtInst");
        By certificate_name = By.XPath("//input[@name='Credential']");
        By given_firstname = By.Id("FirstName");
        By given_lastname = By.Id("LastName");
        By year_awarded = By.Id("ddlAttendedYear");
        By start_year = By.Id("SelectedAttendedYearFrom");
        By end_year = By.Id("SelectedAttendedYearTo");
        By save_btn = By.Id("btnSaveCreden");
        //------------------------Report Recipients------------------------
        By add_address = By.Id("btnAddMailingAddress");
        By street = By.Id("Address1");
        By city = By.Id("City");
        By delivery_method = By.Id("ddlIntlDeliveryMethod");
        By mail_address_saveBtn = By.XPath("//button[text()='Save']");
        
        //-------------Your Evaluation----------------------------------
        By select_evaluationPackage = By.XPath("//span[text()=\"Other available evaluation packages:\"]");
       
        //-----------------Review Applicant acknowledgement------------------
        By acknowledgement_checkbox1 = By.XPath("//span[text()='I authorize WES to verify the authenticity of my documents with the issuing institutions.']");
        By acknowledgement_checkbox2 = By.XPath("//span[text()='I certify that the information I am submitting is accurate and authentic.']");
        By acknowledgement_checkbox3 = By.XPath("//span[text()='I have read and accept the World Education Services, Inc. ']");
        By acknowledgement_checkbox4 = By.XPath("//label[@for='RequiredDocuments']");
        By next_ReviewBtn = By.XPath("//button[@id='btnConfirmNameAndDob']");
        By confirm_checkbox = By.XPath("//span[text()='I confirm that the name and date of birth listed above is accurate and I understand that changes after I apply will not be made.']");
        By confirm_btn = By.Id("btnConfirmAndMoveOn");
        By harmonized_Sales = By.XPath("//span[contains(.,'I am not a resident of Canada for purposes of the Excise Tax Act and I am not registered under that Act.')]");
        By Btn_Continue = By.XPath("(//input[contains(@value,'Continue')])[2]");
        //-----------------------------Payment Confirmation-------------------------------
        By select_payment = By.XPath("//span[text()='Credit Card/Debit Card']");
        By submit_btn = By.CssSelector("[value='Submit']");
        By name_of_card = By.Id("trnCardOwner");
        By card_number = By.Id("trnCardNumber");
        By exp_date = By.Id("trnExpYear");
        By cvv = By.Id("trnCardCvd");
        By payment_submit_btn = By.Id("submitButton");
       

        //-----------------------------Return Account-------------------------------
        By get_success_message = By.XPath("//h1[@class='text-center']");
        By get_reference_number = By.XPath("//h1[@class='text-center']");
        By return_MyAccount = By.XPath("//a[@class='exclude btn saveBtn']");
        By logout_MyAccount = By.XPath("//a[@class='saveBtn']");
        By account_TimeLine_Message = By.XPath("//p[@class='evalStatus-subHead red-text']");
     

        String reference_Number;
        BrowserActions browserActions = new BrowserActions();

     

        /**
      * =============================================================================
      * Method:CreateAccount_ValidateEmail | Author: Rajesh Buddha | Date:14 Nov 2022 | Description:
      * Email&Personal Details Validation  from the application | Parameters: None, None | Return: None
      * =============================================================================
      */

        public void CreateAccount_ValidateEmail(DataRow row)
        {
            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================Email&Personal Details Validation ===============" + "</b>");
            //=============Unit_Creation_code ===========
            string FName = (string)row["firstName"];
            string LName = (string)row["lastName"];
            string Password = (string)row["password"];
            string Month = (string)row["month"];
            string Day = (string)row["day"];
            string Year = (string)row["year"];
            string ConfirmPassword = (string)row["confirmPassword"];
            string SecurityAnswer = (string)row["securityAnswer"];


            browserActions.ClickJSE(lnk_NewAccountCreation, "New account Creation");
            browserActions.ClickJSE(button_Canada, "Canada");
            browserActions.ClickJSE(buttonCanada_Standard, "Canada-Standard");
            Random random = new Random();   
            String Email= String.Format("Qmperformance1+{0:0000}@gmail.com", random.Next(10000));
            browserActions.SendKeys(input_NewAccount_Email, Email);
            browserActions.verifyText(Email, Email);
            browserActions.ClickJSE(btn_Submit, "Submit");
            Thread.Sleep(30000);
            browserActions.ClickJSE(btn_Submit, "Submit");
            browserActions.GetEleText(txt_Verification_Complete);
            browserActions.GetEleText(txt_success_message);
            browserActions.ClickJSE(lnk_Continue, "Continue");
            browserActions.SendKeys(input_UserFirstName, FName);
            browserActions.verifyText(FName, FName);
            browserActions.SendKeys(input_UserLastName, LName);
            browserActions.verifyText(LName, LName);

            //=====================Date of Birth=====================
            browserActions.selectByVisibleText(dd_db_Month, Month);
            browserActions.selectByVisibleText(dd_db_Day, Day);
            browserActions.selectByVisibleText(dd_db_Year, Year);
            browserActions.SendKeys(input_Password, Password);
            browserActions.verifyText(Password, Password);
            browserActions.SendKeys(input_ConfirmPassword, ConfirmPassword);
            browserActions.verifyText(ConfirmPassword, ConfirmPassword);
            browserActions.selectByVisibleText(dd_UserSecurityQuestion, "What is your favorite color?");
            browserActions.SendKeys(input_UserSecurityAnswer, SecurityAnswer);
            browserActions.verifyText(SecurityAnswer, SecurityAnswer);
            browserActions.Click(create_Account_btn, "create account submit button");

            

            Browser.GetScreenshotBase64();

            WebReporter.Log.Pass("<b style=\"color:green;\">" + "Successfully Entered Email&Personal Details" + "</b>");

            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================Successfully validated Email&Personal Information===============" + "</b>");
        }

        /**
       * =============================================================================
       * Method:CreateAccount_personal_information | Author: Rajesh Buddha | Date:25 May 2021 | Description:
       * CreateAccount_personal_information from the application | Parameters: None, None | Return: None
       * =============================================================================
       */
        public void CreateAccount_personal_information(DataRow row)
        {
            string WES = (string)row["Wes"];
            string gender = (string)row["Gender"];
            string MobileNumber = (string)row["mobileNumber"];

            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================CreateAccount_personal_information===============" + "</b>");
            
            browserActions.selectByVisibleText(Gender, gender);
            browserActions.verifyText(gender, gender);
            browserActions.selectByVisibleText(select_Country, "India (91)");
            browserActions.SendKeys(city_Code, MobileNumber);
            browserActions.verifyText(MobileNumber, MobileNumber);
            browserActions.Click(next_Btn, "click next button");

            Browser.GetScreenshotBase64();

            WebReporter.Log.Pass("<b style=\"color:green;\">" + "Successfully Entered Personal Information" + "</b>");
            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================Personal Page Information Ended===============" + "</b>");
        }


        /**
       * =============================================================================
       * Method:CreateAccount_Education_Details | Author: Rajesh Buddha | Date:14 Nov 2021 | Description:
       * CreateAccount_Education_Details from the application | Parameters: None, None | Return: None
       * =============================================================================
       */
        public void CreateAccount_Education_Details(DataRow row)
        {
            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================CreateAccount_Education_Details===============" + "</b>");
            string CountryTerritory = (string)row["countryTerritory"];
            string TypeOfEducation = (string)row["typeOfEducation"];
            string ApplyType = (string)row["applyType"];
            string InstitutionName = (string)row["institutionName"];
            string FName = (string)row["firstName"];
            string LName = (string)row["lastName"];
            string CertificateName = (string)row["certificateName"];
            string YearAwarded = (string)row["awardyear"];
            string StartYear = (string)row["startyear"];
            string Endyear = (string)row["endyear"];



            browserActions.Click(add_Credential, "add credentials button");
            browserActions.selectByVisibleText(country_territory, CountryTerritory);
            browserActions.verifyText(CountryTerritory, CountryTerritory);
            Thread.Sleep(3000);
            browserActions.selectByVisibleText(type_of_Education, TypeOfEducation);
            browserActions.verifyText(TypeOfEducation, TypeOfEducation);
            Thread.Sleep(3000);
            browserActions.selectByVisibleText(apply_type, ApplyType);
            browserActions.verifyText(ApplyType, ApplyType);
            browserActions.SendKeys(institution_name, InstitutionName);
            browserActions.verifyText(InstitutionName, InstitutionName);
            browserActions.SendKeys(given_firstname, FName);
            browserActions.verifyText(FName, FName);
            browserActions.SendKeys(given_lastname, LName);
            browserActions.verifyText(LName, LName);
            browserActions.selectByVisibleText(year_awarded, YearAwarded);
            browserActions.selectByVisibleText(start_year, StartYear);
            browserActions.selectByVisibleText(end_year, Endyear);
            browserActions.SendKeys(certificate_name, CertificateName);
            browserActions.verifyText(CertificateName, CertificateName);
            browserActions.Click(save_btn, "click on save button");
            Thread.Sleep(5000);
            browserActions.Click(next_Btn, "click next button");

            Browser.GetScreenshotBase64();

            WebReporter.Log.Pass("<b style=\"color:green;\">" + "Successfully Entered Education Details" + "</b>");
            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================Education Details Ended===============" + "</b>");
        }
        /**
     * =============================================================================
     * Method:CreateAccount_Report_Recipients | Author: Rajesh Buddha | Date:14 Nov 2022 | Description:
     * CreateAccount_Report_Recipients from the application | Parameters: None, None | Return: None
     * =============================================================================
     */
        public void CreateAccount_Report_Recipients(DataRow row)
        {
            string CountryTerritory = (string)row["countryTerritory"];
            string StreetName = (string)row["Street"];
            string City = (string)row["City"];
            string DeliveryMethod = (string)row["deliveryMethod"];
            


            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================CreateAccount_Report_Recipients===============" + "</b>");
            browserActions.ClickJSE(add_address, "Add+Address");
            Thread.Sleep(3000);
            browserActions.selectByVisibleText(country_territory, CountryTerritory);
            browserActions.verifyText(CountryTerritory, CountryTerritory);
            browserActions.SendKeys(street, StreetName);
            browserActions.verifyText(StreetName, StreetName);
            browserActions.SendKeys(city, City);
            browserActions.verifyText(City, City);
            Thread.Sleep(4000);
            browserActions.selectByVisibleText(delivery_method, DeliveryMethod);
            browserActions.verifyText(DeliveryMethod, DeliveryMethod);
           

            browserActions.Click(mail_address_saveBtn, "click on save button");
            Thread.Sleep(5000);
            browserActions.Click(next_Btn, "click on next");

            Browser.GetScreenshotBase64();

            WebReporter.Log.Pass("<b style=\"color:green;\">" + "Successfully Entered CreateAccount_Report_Recipients Details" + "</b>");
            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================CreateAccount_Report_RecipientsPage end===============" + "</b>");
        }



        /**
    * =============================================================================
    * Method:CreateAccount_Your_Evaluation | Author: Rajesh Buddha | Date:14 Nov 2022 | Description:
    * CreateAccount_Your_Evaluation from the application | Parameters: None, None | Return: None
    * =============================================================================
    */
        public void CreateAccount_Your_Evaluation()
        {
            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================CreateAccount_Your_Evaluation Page Started===============" + "</b>");
            
            Thread.Sleep(5000);
            
            browserActions.Click(next_Btn, "click on next button");
            Thread.Sleep(5000);
            browserActions.Click(next_Btn, "click on next button");

            Browser.GetScreenshotBase64();

            WebReporter.Log.Pass("<b style=\"color:green;\">" + "Successfully Entered CreateAccount_Your_Evaluation Details" + "</b>");
            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================CreateAccount_Your_Evaluation Page end===============" + "</b>");
        }

        /**
    * =============================================================================
    * Method:CreateAccount_Review_applicant_acknowledgement | Author: Rajesh Buddha | Date:14 Nov 2022 | Description:
    * CreateAccount_Review_applicant_acknowledgement from the application | Parameters: None, None | Return: None
    * =============================================================================
    */
        public void CreateAccount_Review_applicant_acknowledgement()
        {
            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================CreateAccount_Review_applicant_acknowledgement page started===============" + "</b>");
            Thread.Sleep(5000);
            browserActions.ClickJSE(acknowledgement_checkbox1, "click checkbox1");
            browserActions.ClickJSE(acknowledgement_checkbox2, "click checkbox2");
            browserActions.ClickJSE(acknowledgement_checkbox3, "click checkbox3");
            browserActions.ClickJSE(acknowledgement_checkbox4, "click checkbox4");
            Thread.Sleep(5000);
            browserActions.ClickJSE(next_ReviewBtn, "click on next button");
            Thread.Sleep(5000);
            browserActions.ClickJSE(confirm_checkbox, "click on confirm checkbox");
            browserActions.ClickJSE(confirm_btn, "click confirm button");
            browserActions.ClickJSE(harmonized_Sales, "Accepted Harmonized Sales Tax Eligibility");
            browserActions.ClickJSE(Btn_Continue, "Selected Continue Button");


            Browser.GetScreenshotBase64();

            WebReporter.Log.Pass("<b style=\"color:green;\">" + "Successfully Entered CreateAccount_Review_applicant_acknowledgement Details" + "</b>");
            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================CreateAccount_Review_applicant_acknowledgement page end===============" + "</b>");
        }

        /**
   * =============================================================================
   * Method:CreateAccount_payment_confirmation | Author: Rajesh Buddha | Date:14 Nov 2022 | Description:
   * CreateAccount_payment_confirmation from the application | Parameters: None, None | Return: None
   * =============================================================================
   */
        public void CreateAccount_payment_confirmation(DataRow row)
        {
            string CardName = (string)row["cardName"];
            string CardNumber = (string)row["cardNumber"];
            string cVV = (string)row["CVV"];

            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================CreateAccount_payment_confirmation page started===============" + "</b>");
            Thread.Sleep(5000);
            browserActions.Click(select_payment, "select payment type");
            Thread.Sleep(3000);
            browserActions.Click(submit_btn, "click submit");
            browserActions.SendKeys(name_of_card, CardName);
            browserActions.verifyText(CardName, CardName);
            browserActions.SendKeys(card_number, CardNumber);
            browserActions.verifyText(CardNumber, CardNumber);
            browserActions.selectByVisibleText(exp_date, "2024");
            Thread.Sleep(5000);
            browserActions.SendKeys(cvv, cVV);
            browserActions.Click(payment_submit_btn, "payment submit button");

            Browser.GetScreenshotBase64();

            WebReporter.Log.Pass("<b style=\"color:green;\">" + "Successfully Entered CreateAccount_payment_confirmation details" + "</b>");
            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================CreateAccount_payment_confirmation end===============" + "</b>");
        }

        /**
* =============================================================================
* Method:CreateAccount_return_account | Author: Rajesh Buddha | Date:14 Nov 2022 | Description:
* CreateAccount_return_account from the application | Parameters: None, None | Return: None
* =============================================================================
*/
        public void CreateAccount_return_account()
        {
            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================CreateAccount_return_account page started===============" + "</b>");
            Thread.Sleep(3000);
            browserActions.GetEleText(get_success_message);
            String referenceNumber = browserActions.GetEleText(get_reference_number);
            reference_Number = Regex.Replace(referenceNumber, @"\D+", "");
            Console.WriteLine(reference_Number);
            Thread.Sleep(3000);
            browserActions.ClickJSE(return_MyAccount, "Return To MyAccount");
            browserActions.GetEleText(account_TimeLine_Message);
            browserActions.ClickJSE(logout_MyAccount, "Logout MyAccount");

            Browser.GetScreenshotBase64();

            WebReporter.Log.Pass("<b style=\"color:green;\">" + "Successfully entered CreateAccount_return_account details" + "</b>");
            WebReporter.Log.Info("<b style=\"color:blue;\">" + "====================CreateAccount_return_account page end===============" + "</b>");
        }

        



    }
}
