using Autofac;
using System;

namespace IoC_Container
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            Container = AppStart.AutoFacConfig.Register();

            GetContent(2);
            Console.ReadKey();
        }

        static void GetContent(int id)
        {

            using (var scope = Container.BeginLifetimeScope())
            {
                var brand = scope.ResolveNamed<IBrand>("Brand");
                var CarBrand = scope.Resolve<IBrand>();
                //var NewCarBrand = scope.Resolve<ICarBrand, >

                Console.WriteLine(CarBrand.GetBrandNameById(id));
                Console.WriteLine(brand.GetBrandNameById(id));
                //Console.WriteLine(NewCarBrand.IsCarBrand(id));
            }
        }
    }
}
