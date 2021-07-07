using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Framework.Ui.Pages;
using System.Collections.Generic;
using System.Linq;

namespace Automation.Testing.Cases
{
    public class SearchStudents : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            //create driver 

            var keyword = $"{testParams["keyword"]}";
            //do the test case
            return new FluentUi(Driver).ChangeContext<StudentsUi>($"{testParams["appliction"]}")
                .FindByName(keyword)
                .Students()
                .All(i => i.FirstName().Equals(keyword) || i.LastName().Equals(keyword));
          

        }
    }
}
