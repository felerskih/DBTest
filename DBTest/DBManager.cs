using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DBTest
{
    public class DBManager
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-4K7ADS4D\SQLEXPRESS;Initial Catalog=test DB;Integrated Security=True");

        public string QueryAll()
        {
            string output = "";

            conn.Open();
            SqlCommand all = new SqlCommand("Select * from TestTable", conn);
            SqlDataReader dr = all.ExecuteReader();
            
            while(dr.Read())
            {
                output += dr.GetValue(0) + "-" + dr.GetValue(1) + "\n";
            }

            dr.Close();
            all.Dispose();
            conn.Close();
            return output;
        }

        public void Insert(string username, string password)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand insert = new SqlCommand("Insert into TestTable(username," +
                " password) values('" + username + "', '" + password + "')", conn);

            da.InsertCommand = insert;
            da.InsertCommand.ExecuteNonQuery();

            insert.Dispose();
            conn.Close();
        }

        public void Delete(string username)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand del = new SqlCommand("Delete from TestTable where username = '"
                + username + "'", conn);

            da.DeleteCommand = del;
            da.DeleteCommand.ExecuteNonQuery();

            del.Dispose();
            conn.Close();
        }
    }
}
