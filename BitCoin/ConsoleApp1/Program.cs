using CurrenciesRate;
using System;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = GetRate.GetAll().GetAwaiter().GetResult();
            Console.WriteLine("Hello World!");
        }
    }
}
