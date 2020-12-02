using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DALconnector dal = new DALconnector();
            List<List<string>> a = dal.ShowTablesOFInterest();
            foreach (List<string> b in a)
            {
                foreach (string c in b)
                {
                    Console.Write(c + " " +
                    dal.ShowNamesOfColumns(c) + " " +
                    dal.ShowNumberOfRows(c));
                    /*
                    
                    */
                }
                Console.WriteLine();
            }
        }
    }
}
