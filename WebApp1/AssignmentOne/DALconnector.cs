using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient; 

namespace AssignmentOne
{
    public class DALconnector
        
    {
        SqlConnection cnn;

        public DALconnector()
        {
            string connetionString;
            // Replace FitatronDB, app and abc123XYZ789 with your own db-name, username and password
            connetionString = @"Data Source = .; Initial Catalog = go_db; Integrated Security = SSPI";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            // todo: throw exception

            Console.WriteLine("connected");

           

        }



        public void Disconnect()
        {
            cnn.Close();
            Console.WriteLine("disconnected");
        }


        private void SqlExecuter(String sql)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
        }

        

        private string SqlReader(String sql)
        {
            String Output = "";
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
                Output = Output + dataReader.GetValue(0) + "\n";
            }
            dataReader.Close();
            Console.WriteLine(Output);
            return Output;

        }

        private string SqlReader2Col(String sql)
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

       
         public void AddMember(String name, String password)
        {
            SqlExecuter(String.Format("insert into Member (name, password) values ('{0}','{1}');", name, password));
            
        }

        public void AddCourse(int courseID, String courseName, int maxMembers)
        {
            SqlExecuter(String.Format("insert into Course (courseID, courseName, maxMembers) values ({0},'{1}',{2});", courseID, courseName, maxMembers));
        }

        public void AddMemberToCourse(int memberID, int courseID)
        {
            SqlExecuter(String.Format("insert into MemberCourse (memberID, courseID) values ({0}, {1})", memberID, courseID));
        }

        public void DeleteMember(int memberID)
        {
            //SqlExecuter(String.Format("delete from MemberCourse where memberID='{0}'; delete from Member where memberID = '{0}'; ", memberID));
            SqlExecuter(String.Format("delete from Member where memberID = '{0}'; ", memberID));
        }

        public void DeleteCourse(int courseID)
        {

            //SqlExecuter(String.Format("delete from MemberCourse where courseID='{0}'; delete from Course where courseID = '{0}'; ", courseID));
            SqlExecuter(String.Format("delete from Course where courseID = '{0}'; ", courseID));

        }
        public void DeleteMemberFromCourse(int memberID, int courseID)
        {
            //SqlExecuter(String.Format("delete from MemberCourse where memberID='{0}'; delete from Member where memberID = '{0}'; ", memberID));
            SqlExecuter(String.Format("delete from MemberCourse where memberID = '{0}' and courseID = '{1}'; ", memberID, courseID));
        }

        public string ShowMembers()
        {
            Console.Write("Members:\n");
            return SqlReader2Col("select * from Member");
           
        }

        public string ShowCourses()
        {
            Console.Write("Courses:\n");
            return SqlReader2Col("select * from Course");
            

           
        }

        public string ShowCoursesTaken(int memberID)
        {
            Console.Write(memberID + " takes:\n");

            return SqlReader(String.Format("select courseID from MemberCourse where memberID='{0}';", memberID));
            
        }

        public string ShowMembersOnCourse(int courseID)
        {
            Console.Write(courseID + " members are:\n");

            return SqlReader("select memberID from MemberCourse where courseID='" + courseID + "';");
            
        }
        public string ShowPassword(string memberID)
        {
            Console.Write(memberID + " password is:\n");

            return SqlReader("select password from Member where memberID='" + memberID + "';");
        }


    }
}
