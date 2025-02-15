using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace db_project
{
    internal class Program
    {
        static void Main(string[] args)
        {

         /*   try
            {
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("chyba pri nacitani dat z JSON souboru: zkontrolujte, zda-li jsou data v JSON souboru spravne napsana");
            }


            ZanryDAO zanryDAO = new ZanryDAO();
            string fileName = "zanry.json";
            string jsonString = File.ReadAllText(fileName);
            List<Zanry> z = JsonConvert.DeserializeObject<List<Zanry>>(jsonString);
            foreach (Zanry z2 in z)
            {
                zanryDAO.Save(z2);
            }*/


            /*ZanryDAO zanryDAO = new ZanryDAO();
            zanryDAO.Delete(new Zanry("pohádka"));*/

            KinosalyDAO kinosalyDAO = new KinosalyDAO();
            Console.WriteLine(string.Join("\n", kinosalyDAO.GetAll()));
            
            

        }
    }
}
