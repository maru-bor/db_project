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
          private static SqlConnection? _connInstance = null;
          private static readonly object _lock = new object();  


          private DatabaseSingleton() {} 

          public static SqlConnection GetConnInstance()
          {
            lock (_lock) 
            {
                if (_connInstance == null || _connInstance.State == System.Data.ConnectionState.Closed)
                {
                    SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
                    consStringBuilder.UserID = ConfSetting("UserID");
                    consStringBuilder.Password = ConfSetting("Password");
                    consStringBuilder.InitialCatalog = ConfSetting("InitialCatalog");
                    consStringBuilder.DataSource = ConfSetting("DataSource");
                    consStringBuilder.TrustServerCertificate = true;
                    consStringBuilder.ConnectTimeout = 30;
                    _connInstance = new SqlConnection(consStringBuilder.ConnectionString);
                    _connInstance.Open();
                    Console.WriteLine("Connected >:3");


                }

                return _connInstance;

            }

             
          }

          public static void CloseConn()
          {
              if(_connInstance != null)
              {
                  _connInstance.Close();
                  _connInstance.Dispose();
              }
          }


          public static string ConfSetting(string key)
          {
              var appSettings = ConfigurationManager.AppSettings;
              string res = appSettings[key] ?? "Value not found";
              return res;
          }

      

    }
}
