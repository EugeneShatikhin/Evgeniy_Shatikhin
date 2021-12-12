using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Lab6WebUITests.Features
{
    [Binding]
    public class AddCurrencySteps
    {
        public WebDriver driver;
        private PayGrade pageObject;
        public int curtableelemCounter;
        public bool empty;
        [AfterScenario("ScAddCurrency")]
        public void Close()
        {
            driver.Quit();
        }
        [Given(@"EvgShat Pay Grade is already created")]
        public void GivenEvgShatPayGradeIsAlreadyCreated()
        {
            driver = new ChromeDriver(Global.path);
            var login = new Login(driver);
            login.EnterUsername("Admin");
            login.EnterPassword("admin123");
            login.PressLogin();
            login.GoToURL("https://opensource-demo.orangehrmlive.com/index.php/admin/viewPayGrades");
            pageObject = new PayGrade(driver);
            pageObject.Click(pageObject.GetElement(By.LinkText("EvgShat")));
            pageObject.AddCurrency();
            curtableelemCounter = pageObject.CountTableIntros(); // default 1, 1 after one insertion, 2 after two insertions.
            empty = pageObject.IsTableEmpty();
        }
        
        [Given(@"currency (.*) is entered")]
        public void GivenCurrencyIsEntered(string p0)
        {
            pageObject.EnterCurrency(p0);
        }
        
        [Given(@"minimum salary (.*) is entered")]
        public void GivenMinimumSalaryIsEntered(string p0)
        {
            pageObject.EnterMinimumSalary(p0);
        }
        
        [Given(@"maximum salary (.*) is entered")]
        public void GivenMaximumSalaryIsEntered(string p0)
        {
            pageObject.EnterMaximumSalary(p0);
        }
        
        [When(@"I click Save")]
        public void WhenIClickSave()
        {
            pageObject.SaveCurrency();
        }
        
        [When(@"data is valid")]
        public void WhenDataIsValid()
        {
            bool cond = pageObject.CurrencyValidate() && pageObject.MinimumSalaryValidate() && pageObject.MaximumSalaryValidate();
            Assert.True(cond, "Data is not valid.");
        }
        
        [When(@"data is invalid")]
        public void WhenDataIsInvalid()
        {
            bool cond = pageObject.CurrencyValidate() && pageObject.MinimumSalaryValidate() && pageObject.MaximumSalaryValidate();
            Assert.True(!cond, "Data is valid.");
        }
        
        [Then(@"new currency should be added")]
        public void ThenNewCurrencyShouldBeAdded()
        {
            bool res = (pageObject.IsTableEmpty() ^ empty) || (pageObject.CountTableIntros() > curtableelemCounter);
            Assert.True(res, "New currency wasn't added");
        }
        
        [Then(@"new currency is not added")]
        public void ThenNewCurrencyIsNotAdded()
        {
            bool res = (pageObject.IsTableEmpty() ^ empty) || (pageObject.CountTableIntros() > curtableelemCounter);
            Assert.True(!res, "New currency was added");
        }
        
        [Then(@"I receive (.*)")]
        public void ThenIReceive(string p0)
        {
            string message = "No error.", m1, m2, m3;
            m1 = pageObject.CurrencyErrorMessage();
            m2 = pageObject.MinimumSalaryErrorMessage();
            m3 = pageObject.MaximumSalaryErrorMessage();
            if (m1 != "No error.") message = m1;
            if (m2 != "No error.") message = m2;
            if (m3 != "No error.") message = m3;
            Assert.AreEqual(p0, message);
        }
    }
}
