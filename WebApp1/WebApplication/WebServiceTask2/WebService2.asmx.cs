using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication
{
    /// <summary>
    /// Summary description for WebService2
    /// </summary>
 
    [WebService(Namespace = "http://webServiceTaskTwo.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {
        DalWebService2 dal = new DalWebService2();
        [WebMethod]
        public List<List<string>> GetAllMemberCourses()
        {
            return dal.ShowMemberCourses();
        }
        [WebMethod]
        public List<List<string>> GetAllMembers()
        {
            return dal.ShowMembers();
        }
        [WebMethod]
        public List<List<string>> GetAllCourses()
        {
            return dal.ShowCourses();
        }
        [WebMethod]
        public List<List<string>> GetCourseColumnNames()
        {
            return dal.GetCourseColumnNames();
        }

        [WebMethod]
        public List<List<string>> GetMemberColumnNames()
        {
            return dal.GetMemberColumnNames();
        }

        [WebMethod]
        public List<List<string>> GetMemberCourseColumnNames()
        {
            return dal.GetMemberCourseColumnNames();
        }

        [WebMethod]
        public List<string> GetAllColumns(string table)
        {
            return dal.GetColumnNames(table);
        }
    }
}
