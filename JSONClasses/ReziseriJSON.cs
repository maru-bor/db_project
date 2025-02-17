using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal class ReziseriJSON : JSONFileInterface
    {
        public void ImportFromJSONFileToDataTable(string fileName)
        {
            try
            {
                ReziseriDAO reziseriDAO = new ReziseriDAO();
                string jsonString = File.ReadAllText(fileName);
                List<Reziseri> reziseri = JsonConvert.DeserializeObject<List<Reziseri>>(jsonString);
                foreach (Reziseri reziser in reziseri)
                {
                    reziseriDAO.Save(reziser);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("chyba pri nacitani dat z JSON souboru" + ex.Message);
            }

        }
    }
}
