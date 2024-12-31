using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework1.pageObjects
{
    public class DashboardPage
    {
        IWebDriver _driver;

        public DashboardPage(IWebDriver _driver)
        {
            this._driver = _driver;
            PageFactory.InitElements(_driver, this);
        }

        //pageobjects

        [FindsBy(How = How.XPath, Using = "//h6")]
        private IWebElement dashboardHeader;

        [FindsBy(How = How.XPath, Using = "//ul/li[6]/a/span")]
        private IWebElement myInfoTab;

        public string GetHeaderText()
        {
            return dashboardHeader.Text;
        }

        public void NavigateToMyInfo()
        {
            myInfoTab.Click();
        }

    }
}