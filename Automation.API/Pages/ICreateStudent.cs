using Automation.Api.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Api.Pages
{
    public interface ICreateStudent: IStudentDetails, ICreate<IStudents>, IBack<IStudents>
    {
        ICreateStudent FirstName(string firstname);

        ICreateStudent LastName(string lastname);

        ICreateStudent EnrollementDate(DateTime enrollementDate);

    }
}
