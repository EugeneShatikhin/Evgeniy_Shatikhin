using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Lab6WebUITests
{
    class Login : BasePageObject
    {
        public WebElement username;
        public WebElement password;
        public WebElement loginBtn;
        public Login(WebDriver wd) : base (wd)
        {
            GoToURL("https://opensource-demo.orangehrmlive.com/index.php/auth/login");
            username = GetElement(By.Id("txtUsername"));
            password = GetElement(By.Id("txtPassword"));
            loginBtn = GetElement(By.Id("btnLogin"));
        }
        public void EnterUsername(string name)
        {
            Input(username, name);
        }
        public void EnterPassword(string pass)
        {
            Input(password, pass);
        }
        public void PressLogin()
        {
            Click(loginBtn);
        }
        public string ErrorMessage()
        {
            return GetAttribute(By.Id("spanMessage"), "innerText");
        }
    }
}
