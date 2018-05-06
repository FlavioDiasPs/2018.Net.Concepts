using System;
using System.Collections.Generic;

namespace UsingGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person()
            {
                Name = "Flavio",
                Age = 26
            };
            var personList = new List<Person>()
            {
                new Person(){
                    Name = "Lucas",
                    Age = 25
                },
                new Person(){
                    Name = "Rodolfo",
                    Age = 20
                }
            };
            var guidList = new List<Guid>()
            {
                GetGuid(),
                GetGuid()
            };


            var item1 = new GenericItem<string, Person>();
            var item2 = new List<GenericItem<object, object>>();
            var item3 = new GenericItem<Guid, Person>(guidList.ToArray(), personList.ToArray());

            item1.Add("item 1 item", new Person() { Name = "item 1 name", Age = 0 });

            item2.Add(new GenericItem<object, object>(12, new Person() { Name = "item 2 name", Age = 12 }));
            item2.Add(new GenericItem<object, object>(12, "abc"));
            item2.Add(new GenericItem<object, object>("jaca", "senta krl"));

            item3.AddRange
                (
                    new List<Guid>()
                    {
                        GetGuid(),
                        GetGuid()
                    }.ToArray(),
                    new List<Person>()
                    {
                        new Person() { Name = "item 3 name", Age = 33 },
                        new Person() { Name = "item 32 name", Age = 333 }
                    }.ToArray()
                );


            Console.WriteLine("Hello World!");
        }


        private static Guid GetGuid()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            return g;
        }
    }
}
