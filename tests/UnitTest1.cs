using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestFramework1.pageObjects;
using TestFramework1.utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFramework1.tests
{
    public class Tests : Base
    {


        [Test]
        public void Test1()
        {
            LoginPage loginPage = new LoginPage(getDriver());
            DashboardPage dashboardPage = new DashboardPage(getDriver());
            loginPage.LogIn("admin", "admin123");
            string expectedHeaderText = "Dashboard";
            string actualHeaderText = dashboardPage.GetHeaderText();
            Assert.That(expectedHeaderText.Equals(actualHeaderText), Is.True, "Header text did not match.");
            Thread.Sleep(1000);
        }

        [Test]
        public void Test2()
        {
            LoginPage loginPage = new LoginPage(getDriver());
            DashboardPage dashboardPage = new DashboardPage(getDriver());
            MyInfoPage myInfoPage = new MyInfoPage(getDriver());
            loginPage.LogIn("admin", "admin123");
            dashboardPage.NavigateToMyInfo();
            string expectedHeaderText = "PIM";
            string actualHeaderText = myInfoPage.GetHeaderText();
            Assert.That(expectedHeaderText.Equals(actualHeaderText), Is.True, "Header text did not match.");
            Thread.Sleep(1000);

            myInfoPage.ClickAddBtn();
            string filePath = myInfoPage.SplitString(System.IO.Directory.GetCurrentDirectory().ToString());
            myInfoPage.SendDoc(filePath + "Files\\test.doc");
            //myInfoPage.SendDoc("C:\\Users\\zsyed\\OneDrive\\Desktop\\test.doc");
            myInfoPage.ClickSaveBtn();
            myInfoPage.ToastrDisplays();
            Thread.Sleep(3000);
        }

    }
}