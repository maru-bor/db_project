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
            string query = $"delete from filmy where nazev = '{element.Nazev}' and dat_vznik='{element.DatVzniku}' and id_rez={GetDirectorID(element.Reziser)};";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Filmy> GetAll()
        {
            string query = "select f.nazev, f.dat_vzniku, f.je_stale_promitan, z.nazev, r.jmeno, r.prijmeni from filmy f " +
                "join žánry z on f.id_za = z.id_za " +
                "join režiséři r on f.id_rez = r.id_rez;";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Reziseri reziser = new Reziseri(reader[4].ToString(), reader[5].ToString());
                    Zanry zanr = new Zanry(reader[3].ToString());
                    Filmy film = new Filmy(reader[0].ToString(),
                        Convert.ToDateTime(reader[1]), Convert.ToBoolean(reader[2]), reziser, zanr);
                    yield return film;

                }
                reader.Close();
            }
        }

        public Filmy GetByValueName(params string[] names)
        {
            Filmy f = null;
            Reziseri r = null;
            Zanry z = null;
            string query = $"select f.nazev, f.dat_vzniku, f.je_stale_promitan, z.nazev, r.jmeno, r.prijmeni from filmy f " +
                $"join žánry z on f.id_za = z.id_za " +
                $"join režiséři r on f.id_rez = r.id_rez " +
                $"where f.nazev = '{names[0]}';";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    r = new Reziseri(reader[4].ToString(), reader[5].ToString());
                    z = new Zanry(reader[3].ToString());    
                    f = new Filmy(reader[0].ToString(), 
                        Convert.ToDateTime(reader[1]), Convert.ToBoolean(reader[2]), r, z);
                    

                }
                reader.Close();
                return f;
            }
        }

        public void Save(Filmy element)
        {
            string query = $"insert into filmy(nazev, dat_vzniku, je_stale_promitan, id_za, id_rez) " +
                $"values ('{element.Nazev}', '{element.DatVzniku}', {element.JeStalePromitanVKinech}, {GetGenreID(element.Zanr)}, {GetDirectorID(element.Reziser)});";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Filmy previousElement, Filmy updatedElement)
        {
            string query = $"update filmy set nazev='{updatedElement.Nazev}', dat_vzniku='{updatedElement.DatVzniku}', " +
                $"je_stale_promitan={updatedElement.JeStalePromitanVKinech}, id_za={GetGenreID(updatedElement.Zanr)}, id_rez={GetDirectorID(updatedElement.Reziser)} " +
                $"where nazev='{previousElement.Nazev}' and dat_vznik='{previousElement.DatVzniku}' and id_rez={GetDirectorID(previousElement.Reziser)}";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }


        private int GetGenreID(Zanry zanr)
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

        private int GetDirectorID(Reziseri reziser)
        {

            int idValue = 0;
            string query = $"select id_rez from režiséři where jmeno = '{reziser.Jmeno}' and prijmeni = '{reziser.Prijmeni}' and dat_nar='{reziser.DatNarozeni}'";
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
