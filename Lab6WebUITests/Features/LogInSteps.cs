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
    public class LogInSteps
    {
        private Login pageObject;
        [AfterScenario("ScLogin")]
        public void Close()
        {
            pageObject.Quit();
        }
        [Given(@"I am trying to log in")]
        public void GivenIAmTryingToLogIn()
        {
            Global.driver = new ChromeDriver(Global.path);
            pageObject = new Login();
        }
        
        [Given(@"I entered username (.*)")]
        public void GivenIEnteredUsername(string user)
        {
            pageObject.EnterUsername(user);
        }
        
        [Given(@"entered password (.*)")]
        public void GivenEnteredPassword(string pass)
        {
            pageObject.EnterPassword(pass);
        }
        
        [When(@"i pressed Login")]
        public void WhenIPressedLogin()
        {
            pageObject.PressLogin();
        }
        
        [Then(@"i should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            Assert.True(Global.driver.Url == "https://opensource-demo.orangehrmlive.com/index.php/dashboard", "Failed logging in.");
        }
        
        [Then(@"i should see Invalid credentials")]
        public void ThenIShouldSeeInvalidCredentials()
        {
            Assert.True(pageObject.ErrorMessage() == "Invalid credentials", "Successfully logged in.");
        }
    }
}
