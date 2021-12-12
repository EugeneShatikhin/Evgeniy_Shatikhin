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
        public WebDriver driver;
        private PayGrade pageObject;
        [AfterScenario("ScPayGrade")]
        public void Close()
        {
            driver.Quit();
        }
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            driver = new ChromeDriver(Global.path);
            var login = new Login(driver);
            login.EnterUsername("Admin");
            login.EnterPassword("admin123");
            login.PressLogin();
            login.GoToURL("https://opensource-demo.orangehrmlive.com/index.php/admin/viewPayGrades");
            pageObject = new PayGrade(driver);
            pageObject.AddPayGrade();
        }
        [Given(@"I am entering name (.*)")]
        public void GivenIAmEntering(string p0)
        {
            pageObject.Input(pageObject.name, p0);
        }
        
        [Given(@"it is valid")]
        public void GivenItIsValid()
        {
            Assert.True(pageObject.PayGradeErrorMessage() == "No error.", "Pay grade name not valid.");
        }
        
        [Given(@"it is already taken")]
        public void GivenItIsAlreadyTaken()
        {
            Assert.True(pageObject.PayGradeErrorMessage() == "Already exists", "Pay grade name is valid.");
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
            //Assert.True(pageObject.GetAttribute(pageObject.save, "value") == "Edit", "Pay grade wasn't created");
        }
        
        [Then(@"nothing should happen")]
        public void ThenNothingShouldHappen()
        {
            Assert.True(pageObject.PayGradeErrorMessage() == "Already exists", "Pay grade was created.");
        }
    }
}
