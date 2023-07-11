using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TurnUp.Pages;
using NUnit.Framework;
using TurnUp.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;

namespace TurnUp.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
    
        [SetUp]
        public void TM_SetUp()
        {
            // Open Chrome Browser
            IWebDriver driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }


        [Test, Order(1), Description("This test checks if a user is able to create a new time record")]
        public void CreateTime_Test()
        {

            // TM page object initialization and definition
            TM_Page tmPageObj = new TM_Page();
            tmPageObj.CreateTimeRecord(driver, "Test1", "Test1");
        }

       [Test, Order(2)]
        public void EditTime_Test()
        {
            //Edit Time record
           TM_Page tmPageObj = new TM_Page();
            tmPageObj.EditTimeRecord(driver);
        }

       [Test, Order(3)]
        public void DeleteTime_Test()
        {
            //Delete Time record
            TM_Page tmPageObj = new TM_Page();
            tmPageObj.DeleteTimeRecord(driver);
        }
    

    [TearDown]
    public void ClosingSteps()
    {
            driver.Quit();
    }

}
        
}
