using System;
using System.Collections.Generic;
using System.Text;

namespace IoC_InversionOfControl
{
    public class ConstInjection_Service
    {
        RandomClass _rnd;

        public ConstInjection_Service()
        {
            _rnd = new RandomClass(new JobDataAccess());
        }

        public string GetAnyJobName()
        {            
            return _rnd.GetRandomJobName();
        }

    }
}
