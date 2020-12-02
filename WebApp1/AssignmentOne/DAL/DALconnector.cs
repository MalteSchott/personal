using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace AssignmentOne
{
    public class DALconnector
        
    {
        SqlConnection cnn;

        public DALconnector()
        {
            try
            {
                string connetionString;
                connetionString = @"Data Source=SYST4DEV01;Initial Catalog=FitatronDB;User ID=app;Password=abc123XYZ789";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
            }
            catch
            {
                throw;
            }
        }

        private Boolean SqlExecuter(string sql)
        {
            try
            {
                SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            int affected = adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
                return (affected > 0);
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


        public void AddMember(string memberID, string name, string password)
        {
                            SqlExecuter(String.Format("insert into Member (memberID, name, password) values ('{0}','{1}', '{2}');", memberID, name, password));
            
        }

        public void AddCourse(string courseID, string courseName, int maxMembers)
        {
                                SqlExecuter(String.Format("insert into Course (courseID, courseName, maxMembers) values ({0},'{1}',{2});", courseID, courseName, maxMembers));
        }

        public void AddMemberToCourse(string memberID, string courseID)
        {
            SqlExecuter(String.Format("insert into MemberCourse (memberID, courseID) values ('{0}', {1})", memberID, courseID));
        }

        public void RemoveMemberFromCourse(string memberID, string courseID)
        {
            SqlExecuter(String.Format("delete from MemberCourse where memberID = '{0}' and courseID = {1}", memberID, courseID));
        }

        public bool DeleteMember(string memberID)
        {
            return SqlExecuter(String.Format("delete from Member where memberID = '{0}'; ", memberID));
        }

        public void DeleteMemberFromMemberCourse(string memberID)
        {
            SqlExecuter(String.Format("delete from MemberCourse where memberID='{0}'", memberID));
        }

        public void DeleteCourse(string courseID)
        {
            SqlExecuter(String.Format("delete from Course where courseID = '{0}'; ", courseID));
        }

        public void DeleteCourseFromMemberCourse(string courseID)
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

        public List<List<string>> ShowCoursesTaken(string memberID)
        {

            return SqlReader(String.Format(" select * from Course inner join MemberCourse on Course.courseID = MemberCourse.courseID where memberID ='{0}';", memberID));

        }


        public List<List<string>> ShowMembersOnCourse(string courseID)
        {
            Console.Write(courseID + " members are:\n");

            return SqlReader("select memberID from MemberCourse where courseID='" + courseID + "';");
            
        }
        public List<List<string>> ShowMemberPassword(string memberID)
        {
            Console.Write(memberID + " password is:\n");
            return SqlReader("select password from Member where memberID='" + memberID + "';");
        }
        public List<List<string>> ShowAdminPassword(string adminID)
        {
            return SqlReader(String.Format("select password from Administrator where adminID='{0}'", adminID));
        }
        public int getFreeSpotNo(string courseID)
        {
            int available = int.Parse(SqlReader(String.Format("select maxMembers from Course where courseID='{0}'", courseID))[0][0]);
            int taken = int.Parse(SqlReader(String.Format("select count(memberID) from MemberCourse where courseID='{0}'", courseID))[0][0]);
            return available - taken;
        }
    }

}
