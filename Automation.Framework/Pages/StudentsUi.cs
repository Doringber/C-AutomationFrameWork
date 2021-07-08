using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Automation.Extensions.Components;

namespace Automation.Framework.Ui.Pages
{
    public class StudentsUi : FluentUi
    {
        public StudentsUi(IWebDriver driver) : base(driver)
        {
        }

        public StudentsUi(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
        }



        public ICreateStudent Create()
        {
            throw new NotImplementedException();
        }

        public IStudents FindByName(string name)
        {
            Driver.GetEnabledElement(By.XPath("//input[@id='SearchString']")).SendKeys(name);
            Driver.SumbitFrom(0);
            return (IStudents)this;
        }

        public T Menu<T>(string menuName)
        {
            throw new NotImplementedException();
        }

        public IStudents Next()
        {
            throw new NotImplementedException();
        }

        public int Page()
        {
            throw new NotImplementedException();
        }

        public int Pages()
        {
            throw new NotImplementedException();
        }

        public IStudents Previous()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStudents> Students()
        {
            throw new NotImplementedException();
        }
    }
}
