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
        public WebDriver driver;
        private Login pageObject;
        private string username;
        private string password;
        [AfterScenario("ScLogin")]
        public void Close()
        {
            driver.Quit();
        }
        [Given(@"I am trying to log in")]
        public void GivenIAmTryingToLogIn()
        {
            driver = new ChromeDriver(Global.path);
            pageObject = new Login(driver);
        }
        
        [Given(@"I entered username (.*)")]
        public void GivenIEnteredUsername(string user)
        {
            username = user;
            pageObject.EnterUsername(user);
        }
        
        [Given(@"entered password (.*)")]
        public void GivenEnteredPassword(string pass)
        {
            password = pass;
            pageObject.EnterPassword(pass);
        }
        
        [When(@"i pressed Login")]
        public void WhenIPressedLogin()
        {
            pageObject.PressLogin();
        }
        
        [When(@"credentials are valid")]
        public void WhenCredentialsAreValid()
        {
            Assert.True(username == "Admin" && password == "admin123", "Failed logging in.");
        }
        
        [When(@"credentials are invalid")]
        public void WhenCredentialsAreInvalid()
        {
            Assert.True(username != "Admin" || password != "admin123", "Successfully logged in.");
        }
        
        [Then(@"i should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            Assert.True(driver.Url == "https://opensource-demo.orangehrmlive.com/index.php/dashboard", "Failed logging in.");
        }
        
        [Then(@"i should see Invalid credentials")]
        public void ThenIShouldSeeInvalidCredentials()
        {
            Assert.True(pageObject.ErrorMessage() == "Invalid credentials", "Successfully logged in.");
        }
    }
}
