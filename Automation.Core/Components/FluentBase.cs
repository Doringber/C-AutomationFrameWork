using System;
using System.Collections.Generic;
using System.Text;
using Automation.Core.Logging;

namespace Automation.Core.Components
{
    public abstract class FluentBase
    {
        protected FluentBase(ILogger logger)
        {
            Logger = logger;

        }
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
            return Create<T>(logger);

        }

        internal abstract T Create<T>(ILogger logger);
    }
}
