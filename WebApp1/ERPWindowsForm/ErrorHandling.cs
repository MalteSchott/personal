using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWindowsForm
{
   public static class ErrorHandling
    {

        public static string HandleException(Exception e)
        {
            if(e is NullReferenceException)
            {
                return "Missing variable";
            }

            if(e is InvalidOperationException)
            {
                return "Webservice not working correctly";
            }

            if(e is FormatException)
            {
                return "Invalid format";
            }

            if(e is SqlException)
            {
                return "Could not execute database query";
            }
            
            if(e is IndexOutOfRangeException)
            {
                return "Object does not exist";
            }

            else
            {
                return "Unexpected error";
            }
        }
    }
}
