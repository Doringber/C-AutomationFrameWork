using System;
using System.Collections.Generic;
using System.Text;
using Automation.Api.Components;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;

namespace Automation.Framework.Ui.Components
{
    public class StudentUi: FluentUi, IStudents
    {
        public StudentUi(IWebDriver driver) : this(driver, new TraceLogger())
        {
        }

        public StudentUi(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
        }

        public string FirstName()
        {
            throw new NotImplementedException();
        }

        public string LastName()
        {
            throw new NotImplementedException();
        }

        public DateTime EnrollementDate()
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public object Details()
        {
            throw new NotImplementedException();
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }
    }
}
