using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace WpfApp1.DAL
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

        private List<string> SqlReaderLight(string sql) //SQL-Reader for lists
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
                int colnbr = dataReader.FieldCount;
                while (dataReader.Read())
                {
                        Object o = dataReader.GetValue(0);
                        cols.Add(o.ToString());
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

        private int SqlReaderIntegerLight(string sql) //SQL-Reader for number of rows(int)
        {
            try
            {
                int Output = 0;
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
                    Output = (int)dataReader.GetValue(0);
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

        public List<string> ShowTablesOfInterest() //Run SQL-Reader
        {
            return SqlReaderLight(String.Format("select * from TablesOfInterest;"));

        }
        public List<string> ShowNamesOfColumns(String table) // Run SQL-Reader
        {

            return SqlReaderLight(String.Format("select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '{0}';", table));

        }
        public int ShowNumberOfRows(string table) //Run SQL-Reader for rows(int)
        {

            return SqlReaderIntegerLight(string.Format("select count(*) from {0};", table));

        }

    }

}