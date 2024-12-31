using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework1.pageObjects
{
    public class LoginPage
    {
        IWebDriver _driver;
        public LoginPage(IWebDriver _driver) 
        { 
            this._driver = _driver;
            PageFactory.InitElements(_driver, this);
        
        }

        //Pageobject factory

        [FindsBy(How = How.XPath, Using = "//*[@name = \"username\"]")]
        private IWebElement username;

       

        [FindsBy(How = How.XPath, Using = "//*[@name = \"password\"]")]
        private IWebElement password;

        

        [FindsBy(How = How.XPath, Using = "//button[@type = \"submit\"]")]
        private IWebElement submit;


        public void LogIn(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            submit.Click();
        }

        public IWebElement getUserName()
        {
            return username;
        }

        public IWebElement getPassword()
        {
            return password;
        }
        public IWebElement getSubmit()
        {
            return submit;
        }


    }

}
