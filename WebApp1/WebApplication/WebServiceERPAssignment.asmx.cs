using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication
{
    /// <summary>
    /// Summary description for WebServiceERPAssignment
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceERPAssignment : System.Web.Services.WebService
    {

        SqlConnection cnn;

        //Executes a query without a result in the databse
        private bool SqlExecuter(string sql)
        {
            try
            {

                string connetionString;
                // Replace app with your own username and password
                connetionString = @"Data Source=SYST4DEV01;Initial Catalog=Demo Database NAV (5-0);User ID=app;Password=abc123XYZ789";
                cnn = new SqlConnection(connetionString);
                cnn.Open();

                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                bool b = adapter.InsertCommand.ExecuteNonQuery() > 0;
                command.Dispose();
                cnn.Close();

                return b;
            }
            catch(Exception ex)
            {
                Console.WriteLine("oh no");
                return false;
                
            }
        }

        //Returns the results from a query in a two dimensional list
        private List<List<string>> SqlReader(string sql)
        {

            string connetionString;
            // Replace app with your own username and password
            connetionString = @"Data Source=SYST4DEV01;Initial Catalog=Demo Database NAV (5-0);User ID=app;Password=abc123XYZ789";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            List<List<string>> cols = new List<List<string>>();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter(sql, cnn);
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();

            int colnbr = dataReader.FieldCount;
            while (dataReader.Read())
            {

                List<string> rows = new List<string>();

                for (int i = 0; i < colnbr; i++)
                {

                    object o = dataReader.GetValue(i);
                    rows.Add(o.ToString());

                }
                cols.Add(rows);
            }
        
            dataReader.Close();
            cnn.Close();
            return cols;
            

        }

        //Returns the results from a query in a one dimensional list (can only recieve results with 1 column)
        private List<string> SqlReader1D(string sql)
        {

            string connetionString;
            // Replace app with your own username and password
            connetionString = @"Data Source=SYST4DEV01;Initial Catalog=Demo Database NAV (5-0);User ID=app;Password=abc123XYZ789";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            List<string> cols = new List<string>();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter(sql, cnn);
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();

            
            while (dataReader.Read())
            {
                Object o = dataReader.GetValue(0);
                cols.Add(o.ToString());
            }

            dataReader.Close();
            cnn.Close();
            return cols;
        }



        //Creates a User in the Cronus Sverige AB database
        [WebMethod]
        public bool CreateUser(string userID, string languageID)
        {
            return SqlExecuter(String.Format("INSERT INTO [CRONUS Sverige AB$EP User] ([User ID], [Language ID]) VALUES ('{0}', '{1}')", userID, languageID));
        }

        //Deletes a User from the Cronus Sverige AB database
        [WebMethod]
        public bool DeleteUser(string userID)
        {
            return SqlExecuter(String.Format("DELETE FROM [CRONUS Sverige AB$EP User] WHERE [User ID] = '{0}'", userID));
        }

        //Updates a Users Language ID in the Cronus Sverige AB database
        [WebMethod]
        public bool EditUser(string userID, string languageID)
        {
            return SqlExecuter(String.Format("UPDATE [CRONUS Sverige AB$EP User] SET [Language ID] = '{1}' WHERE [User ID] = '{0}'", userID, languageID));
        }

        //Returns a User from the Cronus Sverige AB database
        [WebMethod]
        public List<List<string>> SearchUser(string userID)
        {
            return SqlReader(String.Format("SELECT * FROM [CRONUS Sverige AB$EP User] WHERE [User ID] = '{0}'", userID));
        }

        //Returns all user in database
        [WebMethod]
        public List<List<string>> GetUserTable()
        {
            return SqlReader("SELECT * FROM [CRONUS Sverige AB$EP User]");
        }

        //Returns column names for specified table
        [WebMethod]
        public List<string> FetchColumns(string tableName)
        {
            return SqlReader1D(String.Format("SELECT c.name FROM sys.tables t JOIN sys.columns c ON c.object_id = t.object_id WHERE t.name = '{0}'", tableName));
        }

        //Returns a User from the Cronus Sverige AB database
        [WebMethod]
        public List<List<string>> SearchEmployee(string empID)
        {
            return SqlReader(String.Format("SELECT * FROM [CRONUS Sverige AB$Employee] WHERE [No_] = '{0}'", empID));
        }

        //Fetches contents and metadata for the Employee tables and related tables
        [WebMethod]
        public List<List<string>> EmployeeData()
        {
            return SqlReader(String.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME LIKE '%Employee%'"));
        }

        //Fetches all employees from database
        [WebMethod]
        public List<List<string>> EmployeeTables()
        {
            return SqlReader("SELECT * FROM [dbo].[CRONUS Sverige AB$Employee]");
        }
        [WebMethod]
        //Fetches all current tables in the Cronus Sverige AB database, Solution 1
        public List<List<string>> Tables1()
        {
            return SqlReader(String.Format("SELECT * FROM INFORMATION_SCHEMA.TABLES"));
        }

        [WebMethod]
        //Fetches all current tables in the Cronus Sverige AB database, Solution 2
        public List<List<string>> Tables2()
        {
            return SqlReader(String.Format("SELECT * FROM sysobjects WHERE xtype='U'"));
        }

        //Fetches all indexes in the Cronus Sverige AB database
        [WebMethod]
        public List<List<string>> GetAllIndex()
        {
            return SqlReader(String.Format("SELECT * FROM sys.indexes"));
        }

        //Fetches Relatives for a given employee
        [WebMethod]
        public List<List<string>> GetRelatives(String empID)
        {
            return SqlReader(String.Format("SELECT * FROM [CRONUS Sverige AB$Employee Relative] WHERE [Employee No_] = '{0}'", empID));
        }

        //Fetches all Table_Constraints from database
        [WebMethod]
        public List<List<string>> GetAllConstraints()
        {
            return SqlReader(String.Format("SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS"));
        }

        //Fetches column information for emplyee table solution1
        [WebMethod]
        public List<string> GetEmployeeColumns1()
        {
            return this.FetchColumns("CRONUS Sverige AB$Employee");
        }

        //Fetches column information for emplyee table solution2
        [WebMethod]
        public List<List<string>> GetEmployeeColumns2()
        {
            return SqlReader(String.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = 'CRONUS Sverige AB$Employee'"));
        }

        //Fetches all key constraints from database
        [WebMethod]
        public List<List<string>> GetAllKeys()
        {
            return SqlReader(String.Format("SELECT * FROM sys.key_constraints"));
        }

        //Fetches information of employyes that was sick during 2004
        [WebMethod]
        public List<List<string>> GetSickEmployees()
        {
            return SqlReader(String.Format("SELECT a.[Cause of Absence Code], e.* FROM [CRONUS Sverige AB$Employee Absence] a JOIN [CRONUS Sverige AB$Employee] e ON a.[Employee No_] = e.No_ WHERE a.[Cause of Absence Code] = 'SJUK' AND a.[From Date] BETWEEN '2004-01-01' AND '2004-12-31'"));
        }

        //Fetches the employee that has the most absense
        [WebMethod]
        public List<List<string>> AbsenseEmployee()
        {
            return SqlReader(String.Format("SELECT TOP 1 e.[First Name], e.[Last Name], a.[Employee No_], SUM(a.[Quantity (Base)]) AS 'Days Absent' FROM [CRONUS Sverige AB$Employee Absence] a JOIN [CRONUS Sverige AB$Employee] e ON a.[Employee No_] = e.No_ GROUP BY [Employee No_], e.[First Name], e.[Last Name] ORDER BY [Days Absent] DESC"));
        }
    }
}
