using Automation.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Core.Components
{
    public interface IFluent
    {
        T ChangeContext<T>();
        T ChangeContext<T>(ILogger logger);

        T ChangeContext<T>(string appliction);

        T ChangeContext<T>(string appliction, ILogger logger);
    }
}
