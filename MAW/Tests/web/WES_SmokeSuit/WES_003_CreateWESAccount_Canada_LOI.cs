using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WES.Core.Actions;
using WES.Core.TestHooks;
using WES.Core.Utils;
using WES_Web_UI_Automation.WESPageObjetPages;
using WESHybridFramework.Core.Utils;
using WindowsInput;



namespace WES.Tests.web.login
{
    [TestFixture]
    class WES_003_CreateWESAccount_Canada_LOI : BaseWebTest
    {
        [TestCaseSource("Data")]
        [Test, Author("Rajesh Buddha"), Description("Create WES Account"), Category("Smoke Testing")]
        public void wES_003_Web_CreateWESAccount_Canada_LOI(DataRow row)
        {
            
            WebReporter.Log.CreateTest(TestContext.CurrentContext.Test.MethodName);
            WESWeb_CreateWESAccount_Canada_LOI wESWeb_WESAccountCreation = new WESWeb_CreateWESAccount_Canada_LOI();
           


            wESWeb_WESAccountCreation.CreateAccount_ValidateEmail(row);
            wESWeb_WESAccountCreation.CreateAccount_personal_information(row);
            wESWeb_WESAccountCreation.CreateAccount_Report_Purpose();
            wESWeb_WESAccountCreation.CreateAccount_Education_Details(row);
            wESWeb_WESAccountCreation.CreateAccount_Applicant_Recipients(row);
            wESWeb_WESAccountCreation.CreateAccount_Institution_Recipients(row);
            wESWeb_WESAccountCreation.CreateAccount_Your_Evaluation();
            wESWeb_WESAccountCreation.CreateAccount_Review_applicant_acknowledgement();
            wESWeb_WESAccountCreation.CreateAccount_payment_confirmation(row);
            wESWeb_WESAccountCreation.CreateAccount_return_account(); 
            
            
        }

        private static IEnumerable<TestCaseData> Data()
        {
            DataTable dt = ExcelDataUtils.getData(@"C:\Users\QM3\Videos\WES_Automation\MAW\TestData\Data.xlsx", 2);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[0];
                yield return new TestCaseData(row);

            }
        }
    }
}
