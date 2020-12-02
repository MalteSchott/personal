using ConsoleClientWSU2.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientWSU2
{
    class Program
    {
        public delegate ArrayOfString[] Choose();
        static void Main(string[] args)
        {
            ServiceReference1.WebService2SoapClient serviceReference1 = new ServiceReference1.WebService2SoapClient();
            bool exit = false;
            while (exit != true)
            {
                Console.WriteLine("#----------------------------------------#" +
                    "\nIf you wish see Members type m, " +
                    "\nif you  wish view Course type c," +
                    "\nif you wish to view Registartions of Members to Courses type r" +
                    "\nif you wish to view Administration type a," +
                    "\nif you wish to exit the application type e" +
                "\n#----------------------------------------#");
                string answer = Console.ReadLine();
                Choose choose = new Choose(serviceReference1.GetAllMembers);
                if ("m" == answer)
                {
                    Console.WriteLine("You chose Members information");
                }
                else if ("c" == answer)
                {
                    Console.WriteLine("You chose Course information");
                    choose += serviceReference1.GetAllCourses;
                }
                else if ("r" == answer)
                {
                    Console.WriteLine("You chose Registartions information");
                    choose += serviceReference1.GetAllMemberCourses;
                }
                else if ("a" == answer)
                {
                    Console.WriteLine("You chose Administrator information");
                    choose += serviceReference1.GetAllCourses;
                }
                else if ("e" == answer)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Write any of the keys a, o, r or e " +
                            "to use the functionality of this application.");
                }
                ShowContents(choose);
            }
        }
        public static void ShowContents(Choose choose)
        {
            ArrayOfString[] twoDemimention = null;
            try {
               twoDemimention = choose.Invoke();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Database can't be reached");
            }
            catch (Exception e)
            {
                Console.WriteLine("The program encountered errors");
            }
            for (int i = 0; i < twoDemimention.Length; i++)
            {
                ArrayOfString oneDemimention = twoDemimention[i];
                for (int j = 0; j < oneDemimention.Count; j++)
                {
                    string content = oneDemimention[j];
                    Console.Write("{0} ", content);
                }
                Console.WriteLine();
            }
        }
    }
}
