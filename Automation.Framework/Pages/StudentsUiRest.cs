using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Components;
using Automation.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automation.Framework.Ui.Pages
{
    public class StudentsUiRest : FluentRestApi
    {
        public StudentsUiRest(HttpClient httpClient) : base(httpClient)
        {
        }

        public StudentsUiRest(HttpClient httpClient, ILogger logger) : base(httpClient, logger)
        {
        }

        public bool FindByName(string keyword)
        {
            throw new NotImplementedException();
        }

        public string Get(string url)
        {
            var contentResData= LoadData(url);
            return contentResData;
        }

        private string LoadData(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.GetAsync(url).Result;

                var content = response.Content.ReadAsStringAsync().Result;
                return content;
     
            }
        }
    }
}
