using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class DalWebService1
    {
        public static List<string> DataAccess(string file)
        {
            string s;            
            List<string> ls = new List<string>();
            try
            {
                using (StreamReader sr = File.OpenText(file))
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        ls.Add(s);
                    }
                }
            } catch
            {
                throw;
            }
            return ls;
        }
    }
}