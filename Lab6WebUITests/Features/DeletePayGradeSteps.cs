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
    public class DeletePayGradeSteps
    {
        private PayGrade pageObject;
        private string gradeName;

        [AfterScenario("ScDeletePayGrade")]
        public void Close()
        {
            pageObject.Quit();
        }
        [Given(@"Pay Grade exists")]
        public void GivenPayGradeExists()
        {
            pageObject = new PayGrade();
        }
        
        [Given(@"pay grade (.*) is selected")]
        public void GivenPayGradeIsSelected(string p0)
        {
            gradeName = p0;
            var txt = pageObject.GetAttribute(pageObject.GetElement(By.LinkText(p0)), "href");
            txt = txt.Split("=")[1];
            pageObject.Click(pageObject.GetElement(By.Id("ohrmList_chkSelectRecord_" + txt)));
        }
        
        [When(@"I click Remove")]
        public void WhenIClickRemove()
        {
            pageObject.Click(pageObject.GetElement(By.Id("btnDelete")));
            pageObject.Click(pageObject.GetElement(By.Id("dialogDeleteBtn")));
        }
        
        [Then(@"pay grade should be deleted")]
        public void ThenPayGradeShouldBeDeleted()
        {
            Assert.True(Global.driver.FindElements(By.LinkText(gradeName)).Count == 0, "Pay Grade " + gradeName + " was not deleted.");
        }
    }
}
