using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V129.CSS;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework1.pageObjects
{
    public class MyInfoPage
    {
        IWebDriver _driver;

        public MyInfoPage(IWebDriver _driver)
        {
            this._driver = _driver;
            PageFactory.InitElements(_driver, this);
        }

        //Pageobject factory
        [FindsBy(How = How.XPath, Using = "//span/h6")]
        private IWebElement myInfoHeader;

        [FindsBy(How = How.CssSelector, Using = "h6 + button")]
        private IWebElement addButton;

        [FindsBy(How = How.XPath, Using = "//input[@type=\"file\"]")]
        private IWebElement SelectFileInput;

        [FindsBy(How = How.XPath, Using = "//div[3]/button[2]")]
        private IWebElement saveBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"oxd-toaster_1\"]/div")]
        private IWebElement successToastr;


        public string GetHeaderText()
        {
            return myInfoHeader.Text;
        }

        public void ClickAddBtn()
        {
            addButton.Click();
        }

        public void ClickSaveBtn()
        {
            saveBtn.Click();
        }

        public string SplitString(string input)
        {
            string[] substrings = input.Split("bin", StringSplitOptions.RemoveEmptyEntries);
            return substrings[0];
        }

        public void SendDoc(string path)
        {
            SelectFileInput.SendKeys(path);
        }

        public bool ToastrDisplays()
        {
            return successToastr.Displayed;   
        }





    }
}
