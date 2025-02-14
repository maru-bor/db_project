using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal class FilmyDAO : DAOInterface<Filmy>
    {
        public void Delete(Filmy element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Filmy> GetAll()
        {
            throw new NotImplementedException();
        }

        public Filmy GetByValueName(params string[] names)
        {
            throw new NotImplementedException();
        }

        public void Save(Filmy element)
        {
            string query = $"insert into žánry(nazev, dat_vzniku, je_stale_promitan, id_za, id_rez) " +
                $"values ('{element.Nazev}', '{element.DatVzniku}', {element.JeStalePromitanVKinech}, {GetGenreID(element.Zanr)}, {GetDirectorID(element.Reziser)});";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Filmy previousElement, Filmy updatedElement)
        {
            throw new NotImplementedException();
        }


        public int GetGenreID(Zanry zanr)
        {

            int idValue = 0;
            string query = $"select id_za from žánry where nazev = '{zanr.Nazev}' and kod = {zanr.Kod}";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   
                    idValue = Convert.ToInt32(reader[0]);

                }
                reader.Close();
                return idValue;
            }
        }

        public int GetDirectorID(Reziseri reziser)
        {

            int idValue = 0;
            string query = $"select id_rez from režiséři where jmeno = '{reziser.Jmeno}' and prijmeni = '{reziser.Prijmeni}'";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    idValue = Convert.ToInt32(reader[0]);

                }
                reader.Close();
                return idValue;
            }
        }
    }
}
