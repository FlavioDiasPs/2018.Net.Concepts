using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;


namespace UsingAutoMapper.App_Start
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<UsingAutoMapper.App_Start.EmployeeMappingProfile>();
            });
        }
    }
}
