using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{

    /// <summary>
    /// Class that implements the Singleton design pattern for connecting to the database
    /// </summary>
    internal class DatabaseSingleton
    {
          private static SqlConnection? _connInstance = null;
          private static readonly object _lock = new object();  


          private DatabaseSingleton() {} 

          /// <summary>
          /// Reads from a configuration file and creates a single instance of a SqlConnection object
          /// </summary>
          /// <returns> A SqlConnection object with open connection </returns>
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
                   

                }

                return _connInstance;

            }

             
          }

          /// <summary>
          /// Reads key value pairs from the configuration file and returns the values as a string value
          /// </summary>
          /// <param name="key"></param>
          /// <returns> A value from the key value pair in a configuration file</returns>

          public static string ConfSetting(string key)
          {
              var appSettings = ConfigurationManager.AppSettings;
              string res = appSettings[key] ?? "Value not found";
              return res;
          }

      

    }
}
