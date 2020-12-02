using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebServiceTest
{
    public class Dal
    {
        public static List<string> DataAccess(string file)
        {
            string s;
            List<string> ls = new List<string>();
            using (StreamReader sr = File.OpenText(file))
            {
                while ((s = sr.ReadLine()) != null)
                {
                    ls.Add(s);
                }
            }
            return ls;
        }
    }
}