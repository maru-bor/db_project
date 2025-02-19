using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    /// <summary>
    /// Class that imports JSON data from a file into the data table 'režiséři'
    /// </summary>
    internal class ReziseriJSON : JSONFileInterface
    {
        /// <summary>
        /// Imports JSON data from a file, deserializes it into a list of objects and imports it into a data table
        /// </summary>
        /// <param name="fileName"></param>
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
                Console.Error.WriteLine("chyba pri nacitani dat z JSON souboru");
            }

        }
    }
}
