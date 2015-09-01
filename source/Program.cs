using Castle.Windsor;
using Castle.Windsor.Installer;
using System;

namespace Method.Intercetption
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer().Install(FromAssembly.This());

            var service = container.Resolve<IService>();

            Console.WriteLine("This will take about 3 seconds...");

            service.Do();

            Console.WriteLine("Finished!");
            Console.Read();
        }
    }
}
