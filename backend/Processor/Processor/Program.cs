using Microsoft.Extensions.DependencyInjection;
using Processor.Interfaces;
using Processor.Services;
using System;

namespace Processor
{
    internal class Program
    {
        public static IServiceProvider ServiceProvider { get; } = new ServiceContainer();

        static void Main(string[] args)
        {
            var processor = ServiceProvider.GetRequiredService<IBookService>();
            processor.Start();  

            Console.ReadLine(); 
        }
    }
}
