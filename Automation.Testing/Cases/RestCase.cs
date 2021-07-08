using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Framework.Ui.Pages;

namespace Automation.Testing.Cases
{
    public class RestCase : TestCase
    {

        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            //create driver 

            var title = $"{testParams["title"]}";
            var url = $"{testParams["url"]}";

            //do the test case
            return new FluentRestApi(HttpClient).ChangeContext<StudentsUiRest>($"{testParams["appliction"]}")
                .Get(url).Contains(title);
        }
    }
}
