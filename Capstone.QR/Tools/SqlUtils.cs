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
            MasterConnection = "Data Source=" + Windows.Host+ @";Initial Catalog=master;Integrated Security=false;User ID=sa;Password=root";
            LocalConnection = "Data Source=" + Windows.Host + @";Initial Catalog=EVENTDB;Integrated Security=false;User ID=sa;Password=root";
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
            reader = ExecuteQueryReader(query,false);
            if (reader.HasRows)
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
            ExecuteQuery(query,true);
        }

        public static void CreateAdminAccount()
        {
            query = "INSERT INTO AUTH(uname,passwd) VALUES(@uname,@passwd)";
            ExecuteInsert(query,new [] {"@uname","@passwd"}, new [] {"admin",Cipher.Encrypt("123",Cipher.secret)});
        }

        public static bool VerifyAccount(string user,string pass)
        {
            bool verified = false;
            user = user.Trim();
            pass = pass.Trim();
            pass = Cipher.Encrypt(pass, Cipher.secret);

            reader = ExecuteQueryReader("SELECT uname,passwd FROM auth WHERE uname='" + user + "' and passwd='" + pass + "'",false);
            if (reader.HasRows)
            {
                verified = true;
            }
            return verified;
        }

        public static void ExecuteInsert(string strquery,string[] paramNames, string[] values)
        {
            SqlConnection _conn = new SqlConnection(LocalConnection);
            _conn.Open();
            SqlParameter[] sqlparams = new SqlParameter[paramNames.Length]; 
            for (int param = 0; param <  paramNames.Length ; param++)
            {
                sqlparams[param] = new SqlParameter();
            }
            cmd = new SqlCommand(strquery, _conn);
            for (int c = 0; c < paramNames.Length; c++)
            {
                sqlparams[c].ParameterName = paramNames[c];
                sqlparams[c].Value = values[c];
                cmd.Parameters.Add(sqlparams[c]);
            }
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            _conn.Close();  
        }

        public static void ExecuteQuery(string strquery,bool master)
        {
            string connstr = master ? MasterConnection : LocalConnection;
            try
            {
                conn = new SqlConnection(connstr);
                conn.Open();
                cmd = new SqlCommand(strquery, conn);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public static SqlDataReader ExecuteQueryReader(string strquery,bool master)
        {
            string connstr = master ? MasterConnection : LocalConnection;
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand(strquery,conn);
            conn.Open();
            var executeReader = cmd.ExecuteReader();
            return executeReader;
        }
    }
}
