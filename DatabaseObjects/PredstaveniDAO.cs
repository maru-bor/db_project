using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace db_project
{
    internal class PredstaveniDAO : DAOInterface<Predstaveni>
    {
        public void Delete(Predstaveni element)
        {
            string query = "delete p from představení p " +
                           "join kinosály k on p.id_kis = k.id_kis" +
                           "join filmy f on p.id_fi = f.id_fi" +
                           "where p.dat_kon_pred = @dat_kon_pred and k.nazev = @nazev_ki and f.nazev = @nazev_fi;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@dat_kon_pred", element.DatKonanehoPredstaveni);
                cmd.Parameters.AddWithValue("@nazev_ki", element.Kinosal.Nazev);
                cmd.Parameters.AddWithValue("@nazev_fi", element.Film.Nazev);

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Predstaveni> GetAll()
        {
            string query = "select p.dat_plan_pred, p.dat_kon_pred, p.delka, k.nazev as nazev_ki, f.nazev as nazev_fi from představení p " +
                           "join kinosály k on p.id_kis = k.id_kis " +
                           "join filmy f on p.id_fi = f.id_fi;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Kinosaly kinosal = new Kinosaly(reader["nazev_ki"].ToString());
                        Filmy film = new Filmy(reader["nazev_fi"].ToString());
                        Predstaveni predstaveni = new Predstaveni(Convert.ToDateTime(reader["dat_plan_pred"]), Convert.ToDateTime(reader["dat_kon_pred"]), 
                                                  Convert.ToDouble(reader["delka"]), kinosal, film);
                        yield return predstaveni;

                    }
                }
                    
               
            
            }
        }

        public Predstaveni GetByValueName(params string[] names)
        {
            if (names == null || names.Length < 2)
            {
                throw new Exception("alespon dve jmena musi byt poskytnuto");
            }
            Predstaveni predstaveni = null;
            Filmy film = null;
            Kinosaly kinosal = null;
            string query = "select p.dat_plan_pred, p.dat_kon_pred, p.delka, k.nazev as nazev_ki, f.nazev as nazev_fi from představení p " +
                           "join kinosály k on p.id_kis = k.id_kis " +
                           "join filmy f on p.id_fi = f.id_fi " +
                           "where k.nazev = @nazev_ki and f.nazev = @nazev_fi;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nazev_ki", names[0]);
                cmd.Parameters.AddWithValue("@nazev_fi", names[1]);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        kinosal = new Kinosaly(reader["nazev_ki"].ToString());
                        film = new Filmy(reader["nazev_fi"].ToString());
                        predstaveni = new Predstaveni(Convert.ToDateTime(reader["dat_plan_pred"]), Convert.ToDateTime(reader["dat_kon_pred"]),
                                                      Convert.ToDouble(reader["delka"]), kinosal, film);


                    }
                }
               
            }
            return predstaveni;
        }

        public void Save(Predstaveni element)
        {
            string query = "insert into představení(dat_plan_pred, dat_kon_pred, delka, id_kis, id_fi) " +
                           "values (@dat_plan_pred, @dat_kon_pred, " +
                           "@delka, @id_kis, @id_fi);";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {


                
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Predstaveni previousElement, Predstaveni updatedElement)
        {
            string query = $"update představení set dat_plan_pred='{updatedElement.DatPlanovanehoPredstaveni}', dat_kon_pred='{updatedElement.DatKonanehoPredstaveni}', " +
                $"delka={updatedElement.DelkaPredstaveni}, id_kis={GetCinemaTheaterID(updatedElement.Kinosal)}, id_fi={GetFilmID(updatedElement.Film)}" +
                $"where dat_plan_pred='{previousElement.DatPlanovanehoPredstaveni}' and dat_kon_pred='{previousElement.DatKonanehoPredstaveni}';";
                 
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }


        private int GetCinemaTheaterID(Kinosaly kinosal)
        {
            int idValue = 0;
            string query = $"select id_za from kinosály where nazev = '{kinosal.Nazev}' and cis_sal = '{kinosal.CisloSalu}';";
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


        private int GetFilmID(Filmy film)
        {
            int idValue = 0;
            string query = $"select id_za from filmy where nazev = '{film.Nazev}' and dat_vznik='{film.DatVzniku}';";
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
