using System;
using System.Collections.Generic;
using System.Text;

namespace IoC_InversionOfControl
{
    interface IRandomClass
    {
        void SetDependency(IJobDataAccess jobDataAccess);
    }

    public class RandomClass: IRandomClass
    {
        private IJobDataAccess _jobDataAccess;
        public IJobDataAccess PropInjection_jobDataAccess { get; set; }

        public RandomClass(IJobDataAccess jobDataAccess)
        {
            _jobDataAccess = jobDataAccess;
        }

        public RandomClass()
        {

        }

        public void SetDependency(IJobDataAccess jobDataAccess)
        {
            _jobDataAccess = jobDataAccess;
        }

        public string GetRandomJobName()
        {                     
            return _jobDataAccess.GetJobNameById(new Random().Next(3)); 
        }

        public string GetRandomJobNameFromProperty()
        {
            return PropInjection_jobDataAccess.GetJobNameById(new Random().Next(3));
        }

    }
}
