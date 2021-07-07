﻿using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Framework.Ui.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Testing.Cases
{
    public class CreateStudent:TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            //create driver 

            var firstName = $"{testParams["firstName"]}";
            var lastName = $"{testParams["lastName"]}";

            //do the test case
            return new FluentUi(Driver).ChangeContext<StudentsUi>($"{testParams["appliction"]}")
                .Create()
                .FirstName(firstName)
                .LastName(lastName)
                .EnrollementDate(DateTime.Now)
                .Create()
                .Students()
                .Any();


        }
    }
}
