using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    class ZanryJSON : JSONFileInterface
    {
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
