using System;
using System.Collections.Generic;
using System.Text;

namespace IoC_InversionOfControl
{
    public class Factory
    {
        public static IJobDataAccess GetJobObject()
        {
            return new JobDataAccess();
        }

    }
}
