using System;
using System.Collections.Generic;
using System.Text;

namespace IoC_InversionOfControl
{
    public class MethodInjection_Service
    {
        RandomClass _rnd;

        public MethodInjection_Service()
        {
            _rnd = new RandomClass();
            _rnd.SetDependency(new JobDataAccess());
        }

        public string GetAnyJobName()
        {            
            return _rnd.GetRandomJobName();
        }

    }
}
