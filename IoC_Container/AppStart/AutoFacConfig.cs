using Autofac;
using IoC_Container.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC_Container.AppStart
{
    public class AutoFacConfig
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Brand>().Named<IBrand>("Brand");
            builder.RegisterType<CarBrand>().Named<IBrand>("CarBrand");
            builder.RegisterType<CarBrand>().As<ICarBrand, IBrand>();
            builder.RegisterType<BrandDataAccess>().As<IBrandDataAccess>();
            return builder.Build();
        }
    }
}
