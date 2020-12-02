using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace WebApplication
{
    public class DalWebService2
        
    {
        SqlConnection cnn;

        public DalWebService2()
        {
            try
            {
                string connetionString;
                // Replace FitatronDB, app and abc123XYZ789 with your own db-name, username and password
                connetionString = @"Data Source=SYST4DEV01;Initial Catalog=FitatronDB;Integrated Security=True";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                // todo: throw exception

                Console.WriteLine("connected");

            }
            catch
            {
                throw;
            }
        }



        public void Disconnect()
        {
        try
        {
            cnn.Close();
            Console.WriteLine("disconnected");
            }
            catch
            {
                throw;
            }
        }


        private void SqlExecuter(string sql)
        {
            try
            {
                SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            }
            catch
            {
                throw;
            }
        }

        

        private List<List<string>> SqlReader(string sql)
        {
                try
                {
                    List<List<string>> cols = new List<List<string>>();

            String Output = "";
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
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

                for (int i = 0; i < colnbr; i++) {
                    Object o = dataReader.GetValue(i);
                    rows.Add(o.ToString());
            }
                cols.Add(rows);
            }

            dataReader.Close();
            Console.WriteLine(Output);
            return cols;
            }
            catch
            {
                throw;
            }
        }

        private List<string> SqlReaderLight(string sql)
        {
            try
            {
                List<string> cols = new List<string>();
                String Output = "";
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                int i = 0;
                int colnbr = dataReader.FieldCount;
                while (dataReader.Read())
                {

                    Object o = dataReader.GetValue(0);

                    cols.Add(o.ToString());
                    i++;
                }

                dataReader.Close();
                Console.WriteLine(Output);
                return cols;
            }
            catch
            {
                throw;
            }
        }

        private string SqlReader2Col(string sql)
        {
                    try
                    {
                        string Output = "";
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
            }
            dataReader.Close();
            Console.WriteLine(Output);
            return Output;
            }
            catch
            {
                throw;
            }
        }

        public void AddMember(string memberID, string name, string password)
        {
                            SqlExecuter(String.Format("insert into Member (memberID, name, password) values ('{0}','{1}', '{2}');", memberID, name, password));
            
        }

        public void AddCourse(int courseID, string courseName, int maxMembers)
        {
                                SqlExecuter(String.Format("insert into Course (courseID, courseName, maxMembers) values ({0},'{1}',{2});", courseID, courseName, maxMembers));
        }

        public void AddMemberToCourse(string memberID, int courseID)
        {
            SqlExecuter(String.Format("insert into MemberCourse (memberID, courseID) values ('{0}', {1})", memberID, courseID));
        }

        public void DeleteMember(string memberID)
        {
            SqlExecuter(String.Format("delete from Member where memberID = '{0}'; ", memberID));
        }

        public void DeleteMemberFromMemberCourse(string memberID)
        {
            SqlExecuter(String.Format("delete from MemberCourse where memberID='{0}'", memberID));
        }

        public void DeleteCourse(int courseID)
        {
            SqlExecuter(String.Format("delete from Course where courseID = '{0}'; ", courseID));
        }

        public void DeleteCourseFromMemberCourse(int courseID)
        {
            SqlExecuter(String.Format("delete from MemberCourse where courseID = '{0}';", courseID));
        }

        public void UpdateMember(string column, string memberID)
        {
            SqlExecuter(String.Format("update Member set = '{0}' where memberID = '{1}';", column, memberID));

        }

        public void UpdateCourse(string column, string courseID)
        {
            SqlExecuter(String.Format("update Course set = '{0}' where courseID = {1};", column, courseID));
        }
        
        public List<List<string>> ShowMembers()
        {
            Console.Write("Members:\n");
            return SqlReader("select * from Member");
        }

        public List<List<string>> ShowCourses()
        {
            Console.Write("Courses:\n");
            return SqlReader("select * from Course");
        }

        public List<List<string>> ShowMemberCourses()
        {
            Console.Write("MemberCourse:\n");
            return SqlReader("select * from MemberCourse");
        }

        public List<List<string>> ShowAdministrator()
        {
            Console.Write("Administrator:\n");
            return SqlReader("select * from Administrator");
        }

        public List<List<string>> GetMemberColumnNames()
        {
            return SqlReader("SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Member'");
        }

        public List<List<string>> GetCourseColumnNames()
        {
            return SqlReader("SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Course'");
        }

        public List<List<string>> GetMemberCourseColumnNames()
        {
            return SqlReader("SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MemberCourse'");
        }

        public List<List<string>> ShowCoursesTaken(string memberID)
        {
            Console.Write(memberID + " takes:\n");

            return SqlReader(String.Format("select courseID from MemberCourse where memberID='{0}';", memberID));
            
        }

        public List<List<string>> ShowMembersOnCourse(int courseID)
        {
            Console.Write(courseID + " members are:\n");

            return SqlReader("select memberID from MemberCourse where courseID='" + courseID + "';");
            
        }
        public List<List<string>> ShowPassword(string memberID)
        {
            Console.Write(memberID + " password is:\n");

            return SqlReader("select password from Member where memberID='" + memberID + "';");
        }
        public List<string> GetColumnNames(String table)
        {
            return SqlReaderLight(String.Format("select COLUMN_NAME " +
                "from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '{0}';", table));
        }

    }

}
