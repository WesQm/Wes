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
    class WES_002_CreateWESAccount_IRCC : BaseWebTest
    {
        [TestCaseSource("Data")]
        [Test, Author("Rajesh Buddha"), Description("Create WES Account"), Category("Smoke Testing")]
        public void wES_002_Web_CreateWESAccount_IRCC(DataRow row)
        {
            
            WebReporter.Log.CreateTest(TestContext.CurrentContext.Test.MethodName);
            WESWeb_CreateWESAccount_IRCC wESWeb_CreateWESAccount_IRCC = new WESWeb_CreateWESAccount_IRCC();



            wESWeb_CreateWESAccount_IRCC.CreateAccount_ValidateEmail(row);
            wESWeb_CreateWESAccount_IRCC.CreateAccount_personal_information(row);
            wESWeb_CreateWESAccount_IRCC.CreateAccount_Education_Details(row);
            wESWeb_CreateWESAccount_IRCC.CreateAccount_Report_Recipients(row);
            wESWeb_CreateWESAccount_IRCC.CreateAccount_Your_Evaluation();
            wESWeb_CreateWESAccount_IRCC.CreateAccount_Review_applicant_acknowledgement();
            wESWeb_CreateWESAccount_IRCC.CreateAccount_payment_confirmation(row);
            wESWeb_CreateWESAccount_IRCC.CreateAccount_return_account(); 
            
            
        }

        private static IEnumerable<TestCaseData> Data()
        {
            DataTable dt = ExcelDataUtils.getData(@"C:\Users\QM3\Videos\WES_Automation\MAW\TestData\Data.xlsx", 1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[0];
                yield return new TestCaseData(row);

            }
        }
    }
}
