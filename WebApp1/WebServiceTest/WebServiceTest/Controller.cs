using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTest
{
    public class Controller
    {
        public static string HasTxt(string file)
        {
            if (file.EndsWith(".txt") == false)
            {
                return "C:\\Users\\Administrator\\Documents\\VSFileStorage\\" + file + ".txt";
            }
            else
            {
                return "C:\\Users\\Administrator\\Documents\\VSFileStorage\\" + file;
            }
        }
        public static List<string> GetContents(string file)
        {
            string path = Controller.HasTxt(file);
            List<string> contents = Dal.DataAccess(path);
            return contents;
        }
    }
}