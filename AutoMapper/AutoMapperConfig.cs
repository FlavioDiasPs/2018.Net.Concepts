using AutoMapper.Model;
using System;
using System.Collections.Generic;
using System.Text;
using 

namespace UsingAutoMapper
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig()
        {

            createmap<employeedomainmodel, employeeviewmodel>();

            createmap<employeeviewmodel, employeedomainmodel>();

        }
    }
}
