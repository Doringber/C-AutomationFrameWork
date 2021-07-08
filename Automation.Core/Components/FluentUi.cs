using Automation.Core.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Core.Components
{
    public class FluentUi : FluentBase, IFluent
    {
        private IWebDriver driver;


        public FluentUi(IWebDriver driver) :this(driver, new TraceLogger())
        { }

        public FluentUi(IWebDriver driver, ILogger logger): base(logger)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public T ChangeContext<T>(string appliction, ILogger logger)
        {
            Driver.Navigate().GoToUrl(appliction);
            Driver.Manage().Window.Maximize();
            return Create<T>(logger);

        }

        public T ChangeContext<T>(string appliction)
        {
            Driver.Navigate().GoToUrl(appliction);
            Driver.Manage().Window.Maximize();
            return Create<T>(null);

        }

        internal  override T Create<T>(ILogger logger)
        {
            return logger == null? (T)Activator.CreateInstance(typeof(T), new object[] { Driver }) : (T)Activator.CreateInstance(typeof(T), new object[] { Driver, logger });
        }
    }
}
