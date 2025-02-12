using Microsoft.Data.SqlClient;
using System.Configuration;

namespace db_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            Zanry z = new Zanry("komedie", 555);

            string query = $"insert into žánry (nazev, kod) values ('{z.Nazev}', {z.Kod})";
            SqlCommand command = new SqlCommand(query, conn);
            /*  command.ExecuteNonQuery();*/


           







        }
    }
}
