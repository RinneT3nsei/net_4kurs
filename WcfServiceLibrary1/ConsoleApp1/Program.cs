using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WcfServiceLibrary1.Service1)))
            {
                host.Open();
                Console.WriteLine("Хост запустився");
                Console.ReadLine();
            }
        }
    }
}
