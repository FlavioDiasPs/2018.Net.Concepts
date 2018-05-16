using System;
using UsingExtensionMethods.Extensions;

namespace UsingExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = "Hi guys!";

            //extension method
            Console.WriteLine(value.LetterCount());

            var redColor = System.Drawing.Color.Red;
            var greenColor = System.Drawing.Color.Green;
            if (redColor.IsBlood()) Console.WriteLine("It is blood!");
            if (!greenColor.IsBlood()) Console.WriteLine("It is NOT blood!");

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
