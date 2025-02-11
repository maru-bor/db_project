using Microsoft.Data.SqlClient;
using System.Configuration;

namespace db_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
             SqlConnection conn = DatabaseSingleton.GetConnInstance();
           

            /*   SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
               consStringBuilder.UserID = ConfigurationManager.AppSettings["UserID"];
               consStringBuilder.Password = ConfigurationManager.AppSettings["Password"];
               consStringBuilder.InitialCatalog = ConfigurationManager.AppSettings["InitialCatalog"];
               consStringBuilder.DataSource = ConfigurationManager.AppSettings["DataSource"];
               consStringBuilder.TrustServerCertificate = true;
               consStringBuilder.ConnectTimeout = 30;
               try
               {
                   using (SqlConnection conn = new SqlConnection(consStringBuilder.ConnectionString))
                   {
                       conn.Open();
                       Console.WriteLine("Connected YAY");
                   }
               }
               catch (Exception ex) 
               { 
                   Console.WriteLine(ex.Message);
               }


           }*/
        }
    }
}
