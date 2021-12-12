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
        public WebDriver driver;
        private PayGrade pageObject;
        private string curr;
        [AfterScenario("ScDeleteCurrency")]
        public void Close()
        {
            driver.Quit();
        }
        [Given(@"Currency exists")]
        public void GivenCurrencyExists()
        {
            driver = new ChromeDriver(Global.path);
            var login = new Login(driver);
            login.EnterUsername("Admin");
            login.EnterPassword("admin123");
            login.PressLogin();
            login.GoToURL("https://opensource-demo.orangehrmlive.com/index.php/admin/viewPayGrades");
            pageObject = new PayGrade(driver);
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
            var elems = driver.FindElements(By.XPath("//input[@value='" + curr + "']")).Count;
            Assert.True(elems == 0, curr + "was not deleted");
        }
    }
}
