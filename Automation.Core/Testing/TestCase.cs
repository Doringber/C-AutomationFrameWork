using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Core.Testing
{
    public abstract class TestCase
    {
        protected TestCase()
        {
            testParams = new Dictionary<string, object>();
            attempts = 1;
            logger = new TraceLogger();
        }
        //fields
        private IDictionary<string, object> testParams;
        private int attempts;
        private ILogger logger;
        //components
        public abstract bool AutomationTest(IDictionary<string, object> testParams);

        public TestCase Execute()
        {
            Driver = Get();

            for (int i = 0; i < attempts; i++)
            {
                try
                {
                    Actual = AutomationTest(testParams);
                    if (Actual)
                    {
                        break;
                    }
                    logger.Debug($"{GetType()?.FullName}] failed on attempt [{i + 1}]");

                }
                catch (NotImplementedException ex)
                {
                    logger.Debug(ex, ex.Message);
                    break;
                }
                catch (AssertInconclusiveException ex)
                {
                    logger.Debug(ex, ex.Message);
                    break;
                }
                catch (Exception ex)
                {
                    logger.Debug(ex, ex.Message);
                }
                finally
                {
                    Driver?.Close();
                    Driver?.Dispose();
                }
            }

            return this;
        }

        // properties
        public bool Actual { get; private set; }

        //configuration
        public TestCase withTestParams(IDictionary<string, object> testParams)
        {
            this.testParams = testParams;
            return this;
        }

        public IWebDriver Driver { get; private set; }

        //stupr

        private IWebDriver Get()
        {
            var driverParams = new DriverParams { Binaries = ".", Driver = "CHROME" };
            if (testParams?.ContainsKey("driver")== true )
            {
                driverParams.Driver = $"{testParams["driver"]}";

            }

            return new WebDriverFactory(driverParams).Get();
        }

        public TestCase withNumberOfAttempts(int numberOfAttempts)
        {
            attempts = numberOfAttempts;
            return this;
        }

        public TestCase withLogger(ILogger logger)
        {
            this.logger = logger;
            return this;
        }
    }
}
