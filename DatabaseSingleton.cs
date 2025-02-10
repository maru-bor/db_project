using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal class DatabaseSingleton
    {
        private static SqlConnection? conn = null;


        public static SqlConnection GetConnInstance()
        {
            if(conn == null)
            {
                SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
                consStringBuilder.UserID = ConfigurationManager.AppSettings["UserID"]; 
                consStringBuilder.Password = ConfigurationManager.AppSettings["Password"];
                consStringBuilder.InitialCatalog = ConfigurationManager.AppSettings["InitialCatalog"];
                conn = new SqlConnection(consStringBuilder.ConnectionString);
                conn.Open();
                Console.WriteLine("Connected");
                

            }
            return conn;
        }

    }
}
