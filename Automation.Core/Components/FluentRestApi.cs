
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Automation.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OpenQA.Selenium;

namespace Automation.Core.Components
{
    public class FluentRestApi : IFluent
    {
        public FluentRestApi(HttpClient httpClient) : this(httpClient, new TraceLogger())
        { }

        public FluentRestApi(HttpClient httpClient, ILogger logger)
        {
            HttpClient = httpClient;
            Logger = logger;
        }

        public HttpClient HttpClient { get; }
        public ILogger Logger { get; }

        public T ChangeContext<T>()
        {
            throw new NotImplementedException();
        }

        public T ChangeContext<T>(ILogger logger)
        {
            throw new NotImplementedException();
        }

        public T ChangeContext<T>(string appliction)
        {
            throw new NotImplementedException();
        }

        public T ChangeContext<T>(string appliction, ILogger logger)
        {
            throw new NotImplementedException();
        }
    }
}
