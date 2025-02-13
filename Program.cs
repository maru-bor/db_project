using Microsoft.Data.SqlClient;
using System.Configuration;

namespace db_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*  SqlConnection conn = DatabaseSingleton.GetConnInstance();
             Zanry z = new Zanry("komedie", 555);

             // string query = $"insert into žánry (nazev, kod) values ('{z.Nazev}', {z.Kod})";


             string query = $"select id_za from žánry where nazev = '{z.Nazev}'";
             SqlCommand command = new SqlCommand(query, conn);
             SqlDataReader reader = command.ExecuteReader();
             int idValue = 0;
             while (reader.Read())
             {
                 idValue = Convert.ToInt32(reader[0]);
                 Console.WriteLine(reader[0].ToString() + " ");
             }
             Console.WriteLine(idValue + 3);


              DateTime n = new DateTime(2000, 7, 20);
               Console.WriteLine(n.ToString("yyyy-MM-dd").CompareTo("1900-01-01") == 1);



               Filmy f = new Filmy("film", new DateTime(2000,5,10), true, new Reziseri("Karel", "Havlik", new DateTime(2000, 8, 25)), z);*/

            ZanryDAO zanry = new ZanryDAO();
            Console.WriteLine(zanry.GetByValueName("komedie"));













        }
    }
}
