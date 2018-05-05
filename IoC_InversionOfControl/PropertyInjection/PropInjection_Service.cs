using System;
using System.Collections.Generic;
using System.Text;

namespace IoC_InversionOfControl
{
    public class PropInjection_Service
    {
        RandomClass _rnd;

        public PropInjection_Service()
        {
            _rnd = new RandomClass{ PropInjection_jobDataAccess = new JobDataAccess()};
        }

        public string GetAnyJobName()
        {            
            return _rnd.GetRandomJobNameFromProperty();
        }

    }
}
