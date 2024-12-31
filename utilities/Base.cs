using AngleSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFramework1.utilities
{
    public class Base
    {
        public IWebDriver _driver;

        [SetUp]
        public void StartBrowser()
        {

            //Configuration
            string browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        }

        public IWebDriver getDriver()
        {
            return _driver;
        }

        public void InitBrowser(string browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    _driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    _driver = new EdgeDriver();
                    break;
                default:
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver();
                    break;
            }
        }

        [TearDown]
        public void StopBrowser()
        {
            _driver.Quit();
        }
    }
}
