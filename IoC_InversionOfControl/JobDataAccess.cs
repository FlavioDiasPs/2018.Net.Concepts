using System;
using System.Collections.Generic;
using System.Text;

namespace IoC_InversionOfControl
{
    public class JobDataAccess : IJobDataAccess
    {
        public JobDataAccess() { }
      
        public List<string> Name { get; set; } = new List<string>{ "Analista de merda", "Analista lixo", "Fundo do cu" };

        public string GetJobNameById(int i)
        {
            return this.Name[i];
        }
    }
}
