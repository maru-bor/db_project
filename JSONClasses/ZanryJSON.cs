using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    /// <summary>
    /// Class that imports JSON data from a file into the data table 'žánry'
    /// </summary>
    class ZanryJSON : JSONFileInterface
    {
        /// <summary>
        /// Imports JSON data from a file, deserializes it into a list of objects and imports it into a data table
        /// </summary>
        /// <param name="fileName"></param>
        public void ImportFromJSONFileToDataTable(string fileName)
        {
            try
            {
                ZanryDAO zanryDAO = new ZanryDAO();
                string jsonString = File.ReadAllText(fileName);
                List<Zanry> z = JsonConvert.DeserializeObject<List<Zanry>>(jsonString);
                foreach (Zanry z2 in z)
                {
                    zanryDAO.Save(z2);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("chyba pri nacitani dat z JSON souboru");
            }

           
        }
    }
}
