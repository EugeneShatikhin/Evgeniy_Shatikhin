using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
namespace Lab6WebUITests
{
    class PayGrade : BasePageObject
    {
        public WebElement btnAdd;
        public WebElement name;
        public WebElement save;
        public WebElement currency;
        public WebElement minimumSalary;
        public WebElement maximumSalary;
        public WebElement saveCurrency;
        public PayGrade()
        {
            GoToURL("https://opensource-demo.orangehrmlive.com/index.php/admin/viewPayGrades");
            btnAdd = GetElement(By.Id("btnAdd"));
        }
        public void AddPayGrade()
        {
            Click(btnAdd);
            name = GetElement(By.Id("payGrade_name"));
            save = GetElement(By.Id("btnSave"));
        }
        public void EnterPayGradeName(string text)
        {
            Input(name, text);
        }
        public string PayGradeErrorMessage()
        {
            if (GetAttribute(name, "class") != "valid") return GetAttribute(GetElement(By.XPath("//span[@for='payGrade_name']")), "innerText");
            else return "No error.";
        }
        public void SavePayGrade()
        {
            Click(save);
        }
        public void AddCurrency()
        {
            Click(GetElement(By.Id("btnAddCurrency")));
            currency = GetElement(By.Id("payGradeCurrency_currencyName"));
            minimumSalary = GetElement(By.Id("payGradeCurrency_minSalary"));
            maximumSalary = GetElement(By.Id("payGradeCurrency_maxSalary"));
            saveCurrency = GetElement(By.Id("btnSaveCurrency"));
        }
        public void EnterCurrency(string curr)
        {
            Input(currency, curr);
        }
        public void EnterMinimumSalary(string min)
        {
            Input(minimumSalary, min);
        }
        public void EnterMaximumSalary(string max)
        {
            Input(maximumSalary, max);
        }
        public void SaveCurrency()
        {
            Click(saveCurrency);
        }
        public bool CurrencyValidate() // true if currency is valid 
        {
            return !GetAttribute(currency, "class").Contains("validation-error");
        }
        public bool MinimumSalaryValidate() // true if min salary is valid 
        {
            return !GetAttribute(minimumSalary, "class").Contains("validation-error");
        }
        public bool MaximumSalaryValidate() // true if max salary is valid 
        {
            return !GetAttribute(maximumSalary, "class").Contains("validation-error");
        }
        public string CurrencyErrorMessage()
        {
            if (!CurrencyValidate()) return GetAttribute(GetElement(By.XPath("//span[@for='payGradeCurrency_currencyName']")), "innerText");
            return "No error.";
        }
        public string MinimumSalaryErrorMessage()
        {
            if (!MinimumSalaryValidate()) return GetAttribute(GetElement(By.XPath("//span[@for='payGradeCurrency_minSalary']")), "innerText");
            return "No error.";
        }
        public string MaximumSalaryErrorMessage()
        {
            if (!MaximumSalaryValidate()) return GetAttribute(GetElement(By.XPath("//span[@for='payGradeCurrency_maxSalary']")), "innerText");
            return "No error.";
        }
        public bool IsTableEmpty()
        {
            return GetAttribute(GetElement(By.Id("tblCurrencies")), "innerText").Contains("No Records Found");
        }
        public int CountTableIntros()
        {
            return Regex.Matches(GetAttribute(GetElement(By.Id("tblCurrencies")), "innerText"), "\n").Count;
        }
    }
}
