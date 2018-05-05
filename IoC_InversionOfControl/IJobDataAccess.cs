using System;
using System.Collections.Generic;
using System.Text;

namespace IoC_InversionOfControl
{
    public interface IJobDataAccess
    {
        string GetJobNameById(int i);
    }
}
