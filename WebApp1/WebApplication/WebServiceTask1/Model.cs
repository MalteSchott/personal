using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class Model
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
            string path = HasTxt(file);
            List<string> contents = DalWebService1.DataAccess(path);
            return contents;
        }
    }
}