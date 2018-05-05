using System;
using System.Collections.Generic;
using System.Text;

using UsingAutoMapper.Model;

namespace UsingAutoMapper.App_Start
{
    public class EmployeeMappingProfile : AutoMapper.Profile
    {
        public override string ProfileName => "Some name";

        public EmployeeMappingProfile()
        {
            CreateMap<UsingAutoMapper.Model.EmployeeDomainModel, UsingAutoMapper.Model.EmployeeViewModel>();
            CreateMap<UsingAutoMapper.Model.EmployeeViewModel, UsingAutoMapper.Model.EmployeeDomainModel>();
        }
    }
}
