using Automation.Api.Components;
using Automation.Core.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Api.Pages
{
    public interface IStudents: IFluent, IPageNavigator<IStudents>,  IMenu, ICreate<ICreateStudent>, IStudentDetails
    {
        IStudents FindByName(string name);
        IEnumerable<IStudents> Students();
    }
}
