using System;
using System.Collections.Generic;
using UsingAutoMapper.Model;

namespace UsingAutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Register mappings
            UsingAutoMapper.App_Start.AutoMapperConfig.Register();

            var employeeViewModel = new List<EmployeeViewModel>();
            var employeeDomainModel = new List<EmployeeDomainModel>
            {
                new EmployeeDomainModel { EmployeeId = 1, Name = "Ashish" },
                new EmployeeDomainModel { EmployeeId = 2, Name = "Ajay" }
            };

            var employee = AutoMapper.Mapper.Map(employeeDomainModel, employeeViewModel);

            var employee2 = AutoMapper.Mapper.Map<List<EmployeeDomainModel>, List<EmployeeViewModel>>(employeeDomainModel);

            foreach (AutoMapper.IObjectMapper obj in AutoMapper.Mapper.Instance.ConfigurationProvider.GetMappers())
                Console.WriteLine(obj.ToString());

            Console.WriteLine();
            Console.WriteLine("-------------------");
            employee.ForEach(e => Console.WriteLine("ID: " + e.EmployeeId + " - Name: " + e.Name));
            Console.WriteLine("Should have been written");
            Console.WriteLine("-------------------");
            employee2.ForEach(e => Console.WriteLine("ID: " + e.EmployeeId + " - Name: " + e.Name));
            Console.WriteLine("Should have been written2");

            Console.ReadKey();
        }
    }
}
