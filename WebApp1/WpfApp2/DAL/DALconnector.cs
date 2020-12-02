using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace WpfApp2.DAL
{
    public class DALconnector

    {
        SqlConnection cnn;

        public DALconnector()
        {
            try
            {
                string connetionString;
                // Replace FitatronDB, app and abc123XYZ789 with your own db-name, username and password
                connetionString = @"Data Source=uwdb18.srv.lu.se\icssql001;Initial Catalog=SYSA14_PK_ProgAssignment2;User ID=sysa14reader;Password=INFreader1";
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

        internal List<List<string>> ShowTables()
        {
            throw new NotImplementedException();
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

                    for (int i = 0; i < colnbr; i++)
                    {
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


        public List<List<string>> ShowTablesOFInterest()
        {

            return SqlReader(String.Format("select * from TablesOfInterest;"));

        }
        public List<List<string>> ShowNamesOfColumns(string table)
        {

            return SqlReader(String.Format("select COLUMN_NAME " +
                "from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = {0};", table));

        }
        public List<List<string>> ShowNumberOfRows(string table)
        {

            return SqlReader(String.Format("select count(*) from {0};", table));

        }

    }

}