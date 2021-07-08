using Automation.Testing.Cases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Automation.Testing.Containers
{
    [TestClass]
    public class StudentsTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("{'driver':'CHROME','keyword':'Alexander','appliction':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void SearchStudentUiTest(string testParams)
        {

            //gernaratio test params 
            var paraneters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            //execute with params
            var actual = new SearchStudents().withTestParams(paraneters).Execute().Actual;

            //assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("{'driver':'CHROME','firstName':'csharp','lastName':'student','appliction':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void CreateStudentUiTest(string testParams)
        {

            //gernaratio test params 
            var paraneters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            //execute with params
            var actual = new CreateStudent().withTestParams(paraneters).Execute().Actual;

            //assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("{'driver':'API','title':'delectus aut autem','appliction':'https://gravitymvctestapplication.azurewebsites.net/Student','url':'https://jsonplaceholder.typicode.com/todos/1'}")]
        public void CreateRest(string testParams)
        {

            //gernaratio test params 
            var paraneters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            //execute with params
            var actual = new RestCase().withTestParams(paraneters).Execute().Actual;

            //assert
            Assert.IsTrue(actual);
        }
    }
}
