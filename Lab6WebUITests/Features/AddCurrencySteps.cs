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
        private PayGrade pageObject;
        public int curtableelemCounter;
        public bool empty;
        [AfterScenario("ScAddCurrency")]
        public void Close()
        {
            pageObject.Quit();
        }
        [Given(@"EvgShat Pay Grade is already created")]
        public void GivenEvgShatPayGradeIsAlreadyCreated()
        {
            pageObject = new PayGrade();
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
