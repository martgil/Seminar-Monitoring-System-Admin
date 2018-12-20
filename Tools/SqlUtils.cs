#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Capstone.QR.Tools
{
    public static class SqlUtils
    {
        
        static SqlUtils()
        {
            MasterConnection = "Data Source=" + Windows.Host+ @";Initial Catalog=master;Integrated Security=SSPI;User ID=" + Windows.Host + @"\"+ Windows.User +";Password=";
            LocalConnection = "Data Source=" + Windows.Host + @";Initial Catalog=EVENTDB;Integrated Security=SSPI;User ID=" + Windows.Host + @"\" + Windows.User + ";Password=";
        }

        public static string LocalConnection;
        public static string MasterConnection;
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataReader reader;
        private static string query;

        public static bool IsTableExist(string tablename)
        {
            bool exist = false;
            query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME='" + tablename + "'";
            reader = ExecuteQueryReader(query);
            while (reader.HasRows)
            {
                exist = true;
            }
            return exist;
        }

        public static bool IsDatabaseExist()
        {
            bool e = false;
            conn = new SqlConnection(MasterConnection);
            conn.Open();
            query = "SELECT NAME FROM SYS.DATABASES";
            cmd = new SqlCommand(query,conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0) == "EVENTDB")
                {
                    e = true;
                }
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
            return e;
        }

        public static void CreateDatabase()
        {
            query = "CREATE DATABASE EVENTDB";
            ExecuteQuery(query);
        }

        public static void CreateAdminAccount()
        {
            query = "INSERT INTO AUTH(uname,passwd) VALUES(@uname,@passwd)";
            ExecuteInsert(query,new string[] {"@uname","@passwd"},new string[] {"admin","123"});
        }

        public static void ExecuteInsert(string strquery,string[] paramNames, string[] values)
        {
            SqlParameter[] sqlparams = new SqlParameter[paramNames.Length]; 
            for (int param = 0; param < strquery.Length ; param++)
            {
                sqlparams[param] = new SqlParameter();
            }
            try
            {
                cmd = new SqlCommand(strquery, conn);
                for (int c = 0; c <= sqlparams.Length; c++)
                    {
                        sqlparams[c].ParameterName = paramNames[c];
                        sqlparams[c].Value = values[c];
                        cmd.Parameters.Add(sqlparams[c]);
                    }
                

                MessageBox.Show(sqlparams[0].ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (SqlException ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            
        }

        public static void ExecuteQuery(string strquery)
        {
            try
            {
                conn = new SqlConnection(MasterConnection);
                conn.Open();
                cmd = new SqlCommand(strquery, conn);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (SqlException ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            
        }

        public static SqlDataReader ExecuteQueryReader(string strquery)
        {
            SqlDataReader executeReader;
            cmd = new SqlCommand(strquery,conn);
            conn.Open();
            executeReader = cmd.ExecuteReader();
            return executeReader;
        }
    }
}
