using Automation.Core.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Core.Components
{
    public class FluentUi : IFluent
    {
        private IWebDriver driver;


        public FluentUi(IWebDriver driver) :this(driver, new TraceLogger())
        { }

        public FluentUi(IWebDriver driver, ILogger logger)
        {
            Driver = driver;
            Logger = logger;
        }

        public IWebDriver Driver { get; }
        public ILogger Logger { get; }
        public T ChangeContext<T>(ILogger logger)
        {
            return Create<T>(logger);
        }

        public T ChangeContext<T>()
        {
            var instance = Create<T>(null);
            Logger.Debug($"instance of [{GetType()?.FullName}] created");
            return instance;
        }
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

        private T Create<T>(ILogger logger)
        {
            return logger == null? (T)Activator.CreateInstance(typeof(T), new object[] { Driver }) : (T)Activator.CreateInstance(typeof(T), new object[] { Driver, logger });
        }
    }
}
