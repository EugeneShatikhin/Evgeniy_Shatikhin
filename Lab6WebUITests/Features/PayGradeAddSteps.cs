using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using NUnit.Framework;
namespace Lab6WebUITests.Features
{
    [Binding]
    public class PayGradeAddSteps
    {
        private PayGrade pageObject;
        [AfterScenario("ScPayGrade")]
        public void Close()
        {
            pageObject.Quit();
        }
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            Global.driver = new ChromeDriver(Global.path);
            var login = new Login();
            login.EnterUsername("Admin");
            login.EnterPassword("admin123");
            login.PressLogin();
            login.GoToURL("https://opensource-demo.orangehrmlive.com/index.php/admin/viewPayGrades");
        }
        [Given(@"I want to add new Pay Grade")]
        public void IWantToAddNewPayGrade()
        {
            pageObject = new PayGrade();
            pageObject.AddPayGrade();
        }
        [Given(@"I am entering name (.*)")]
        public void GivenIAmEntering(string p0)
        {
            pageObject.Input(pageObject.name, p0);
        }
        
        [When(@"i press Save")]
        public void WhenIPressSave()
        {
            pageObject.SavePayGrade();
        }
        
        [Then(@"new Pay Grade should be created")]
        public void ThenNewPayGradeShouldBeCreated()
        {
            var msg = pageObject.GetAttribute(pageObject.GetElement(By.Id("currencyListHeading")), "innerText");
            Assert.True(msg == "Assigned Currencies", "Pay grade wasn't created");
        }
        
        [Then(@"nothing should happen")]
        public void ThenNothingShouldHappen()
        {
            Assert.True(pageObject.PayGradeErrorMessage() == "Already exists", "Pay grade was created.");
        }
    }
}
