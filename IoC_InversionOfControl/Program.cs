using System;

namespace IoC_InversionOfControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Construct Injection...");
            ConstInjection_Service constInjection_Service = new ConstInjection_Service();
            for (int i = 0; i < 10; i++) Console.WriteLine(constInjection_Service.GetAnyJobName());


            Console.WriteLine();
            Console.WriteLine("Property Injection...");
            PropInjection_Service propInjection_Service = new PropInjection_Service();
            for (int i = 0; i < 10; i++) Console.WriteLine(propInjection_Service.GetAnyJobName());

            Console.WriteLine();
            Console.WriteLine("Method Injection...");
            MethodInjection_Service methodInjection_Service = new MethodInjection_Service();
            for (int i = 0; i < 10; i++) Console.WriteLine(methodInjection_Service.GetAnyJobName());

            Console.ReadKey();
        }
    }
}
