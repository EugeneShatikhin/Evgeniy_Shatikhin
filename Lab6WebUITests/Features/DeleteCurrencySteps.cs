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
    public class DeleteCurrencySteps
    {
        private PayGrade pageObject;
        private string curr;
        [AfterScenario("ScDeleteCurrency")]
        public void Close()
        {
            pageObject.Quit();
        }
        [Given(@"Currency exists")]
        public void GivenCurrencyExists()
        {
            pageObject = new PayGrade();
            pageObject.Click(pageObject.GetElement(By.LinkText("EvgShat")));
        }
        [Given(@"some (.*) is selected")]
        public void GivenSomeCurrencyIsSelected(string p0)
        {
            curr = p0;
            pageObject.Click(pageObject.GetElement(By.XPath("//input[@value='" + p0 + "']")));
        }
        
        [When(@"I click Delete")]
        public void WhenIClickDelete()
        {
            pageObject.Click(pageObject.GetElement(By.Id("btnDeleteCurrency")));
        }
        
        [Then(@"it should be deleted")]
        public void ThenItShouldBeDeleted()
        {
            var elems = Global.driver.FindElements(By.XPath("//input[@value='" + curr + "']")).Count;
            Assert.True(elems == 0, curr + "was not deleted");
        }
    }
}
