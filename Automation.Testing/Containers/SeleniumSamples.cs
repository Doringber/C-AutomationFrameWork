using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Newtonsoft.Json;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Testing.Containers
{
    [TestClass]
    public class SeleniumSamples
    {
        private IWebDriver _webDriver;

        [TestMethod]
        public void webDriverSamples()
        {
            //TODO:add test loogi here 

            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();


            _webDriver.Navigate().GoToUrl("https://www.google.com");
            Assert.IsTrue(_webDriver.Title.Contains("Google"));

            _webDriver.Dispose();
        }

        [TestMethod]
        public void webDriverSamplesFire()
        {
            //TODO:add test loogi here 

            new DriverManager().SetUpDriver(new FirefoxConfig());
            _webDriver = new FirefoxDriver();

            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            _webDriver.GetElement(By.XPath("(//a[@class='nav-link text-dark'])[2]")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Home Page - Contoso University"));


            _webDriver.Dispose();
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("{'driver':'CHROME','element':\"(//a[@class='nav-link text-dark'])[2]\",'appliction':'https://gravitymvctestapplication.azurewebsites.net/'}")]
        public void WebDriverFactorySimpleChrome(string testParams)
        {
            var paraneters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            var _webDriver = new WebDriverFactory(new DriverParams { Driver = paraneters["driver"].ToString(), Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Chrome\88.0.4324.96\X64\" }).Get();


            _webDriver.GoToUrl(paraneters["appliction"].ToString());
            _webDriver.GetElement(By.XPath(paraneters["element"].ToString())).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Student Body Statistics - Contoso University"));

            _webDriver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySimpleFireFox()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "FIREFOX", Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Firefox\0.29.0\X64" }).Get();


            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            _webDriver.GetElement(By.XPath("(//a[@class='nav-link text-dark'])[2]")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Student Body Statistics - Contoso University"));

            _webDriver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySimpleSelect()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "FIREFOX", Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Firefox\0.29.0\X64" }).Get();


            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            _webDriver.GetElement(By.XPath("(//a[@class='nav-link text-dark'])[4]")).Click();
            _webDriver.GetElement(By.XPath("(//select[@id='SelectedDepartment'])")).AsSelect().SelectByValue("4");

            Assert.IsTrue(_webDriver.Title.Contains("Courses - Contoso University"));

            _webDriver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySimpleFireFoxFindEelements()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "FIREFOX", Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Firefox\0.29.0\X64" }).Get();


            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            ReadOnlyCollection<IWebElement> listItems = _webDriver.GetElements(By.XPath("//ul/li"));
            foreach (var item in listItems)
            {
                Console.WriteLine(item.Text);

            }
            _webDriver.Dispose();
        }


        [TestMethod]
        public void WebDriverFactorySimpleFireFoxVisibleElement()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "FIREFOX", Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Firefox\0.29.0\X64" }).Get();


            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            _webDriver.GetVisibleElement(By.XPath("(//a[@class='nav-link text-dark'])[2]")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Student Body Statistics - Contoso University"));

            _webDriver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySimpleFireFoxFindVisibleEelements()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "FIREFOX", Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Firefox\0.29.0\X64" }).Get();


            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            ReadOnlyCollection<IWebElement> listItems = _webDriver.GetVisibleElements(By.XPath("//ul/li"));
            foreach (var item in listItems)
            {
                Console.WriteLine(item.Text);

            }
            _webDriver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySimpleFireFoxEnabled()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "FIREFOX", Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Firefox\0.29.0\X64" }).Get();


            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            _webDriver.GetEnabledElement(By.XPath("//input[@id='SearchString']")).SendKeys("Dor");

            _webDriver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySimpleFireFoxScrollWindow()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "FIREFOX", Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Firefox\0.29.0\X64" }).Get();


            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            _webDriver.Manage().Window.Size = new Size(100, 350);
            _webDriver.VerticalWindowScroll(1000);
            _webDriver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySimpleFireFoxActions()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "FIREFOX", Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Firefox\0.29.0\X64" }).Get();

            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            _webDriver.GetVisibleElement(By.XPath("(//a[@class='nav-link text-dark'])[2]")).Actions().Click().Build().Perform();

            _webDriver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySimpleFireFoxForceClick()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "FIREFOX", Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Firefox\0.29.0\X64" }).Get();

            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            _webDriver.GetElement(By.XPath("(//a[@class='nav-link text-dark'])[2]")).ForceClick();

            _webDriver.Dispose();
        }


        [TestMethod]
        public void WebDriverFactorySimpleFireFoxSendKeys()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "FIREFOX", Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Firefox\0.29.0\X64" }).Get();

            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            _webDriver.GetElement(By.XPath("//input[@id='SearchString']")).SendKeys("Doe", 1000);

            _webDriver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySimpleFireFoxForceClear()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "FIREFOX", Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Firefox\0.29.0\X64" }).Get();

            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            _webDriver.GetElement(By.XPath("//input[@id='SearchString']")).SendKeys("Doe", 1000).ForceClear();

            _webDriver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySimpleFireFoxSumbitForm()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "FIREFOX", Binaries = @"C:\Users\dori\Documents\VsDorProject\AutomationRoot\Automation.Testing\bin\Debug\net4.8\Firefox\0.29.0\X64" }).Get();

            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            _webDriver.GetElement(By.XPath("//input[@id='SearchString']")).SendKeys("Alexander");
            _webDriver.SumbitFrom(0);

            _webDriver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySimpleChromeSumbitFormRemote()
        {
            var _webDriver = new WebDriverFactory(new DriverParams { Driver = "CHROME", Binaries = @"http://localhost:4444/wd/hub", Source = "REMOTE" }).Get();

            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            _webDriver.GetElement(By.XPath("//input[@id='SearchString']")).SendKeys("Alexander");
            _webDriver.SumbitFrom(0);

            _webDriver.Dispose();
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("{'driver':'FIREFOX','element':\"//input[@id='SearchString']\",'appliction':@'http://localhost:4444/wd/hub'},'source':'REMOTE'")]
        public void WebDriverFactorySimpleChromeSumbitFormRemoteFireFox(string testParams)
        {
            var paraneters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            var _webDriver = new WebDriverFactory(new DriverParams { Driver = paraneters["driver"].ToString(), Binaries = paraneters["appliction"].ToString(), Source = paraneters["source"].ToString() }).Get();

            _webDriver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            _webDriver.GetElement(By.XPath(paraneters["element"].ToString())).SendKeys("Alexander");
            _webDriver.SumbitFrom(0);

            _webDriver.Dispose();
        }









    }
}
