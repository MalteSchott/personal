using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ls;
            Console.WriteLine("Type file name:");
            string fileName = Console.ReadLine();
            try
            {
                ServiceReference1.WebService1SoapClient serviceReference1 = new ServiceReference1.WebService1SoapClient();
                ls = serviceReference1.GetFileContents(fileName);
                foreach (string s in ls)
                {
                    Console.WriteLine(s);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {

            }
           
            
            
        }
    }
}
