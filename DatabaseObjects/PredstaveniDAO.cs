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
                $"where p.dat_kon_pred='{element.DatKonanehoPredstaveni}' and k.nazev='{element.Kinosal.Nazev}' and f.nazev='{element.Film.Nazev}';";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Predstaveni> GetAll()
        {
            string query = "select p.dat_plan_pred, p.dat_kon_pred, p.delka, k.nazev, f.nazev from představení p " +
                "join kinosály k on p.id_kis = k.id_kis " +
                "join filmy f on p.id_fi = f.id_fi;";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Kinosaly kinosal = new Kinosaly(reader[3].ToString());
                    Filmy film = new Filmy(reader[4].ToString());
                    Predstaveni predstaveni = new Predstaveni(Convert.ToDateTime(reader[0]), Convert.ToDateTime(reader[1]), Convert.ToDouble(reader[2]), kinosal, film);
                    yield return predstaveni;

                }
                reader.Close();
            }
        }

        public Predstaveni GetByValueName(params string[] names)
        {
            Predstaveni predstaveni = null;
            Filmy filmy = null;
            Kinosaly kinosal = null;
            string query = "select p.dat_plan_pred, p.dat_kon_pred, p.delka, k.nazev, f.nazev from představení p " +
               "join kinosály k on p.id_kis = k.id_kis " +
               "join filmy f on p.id_fi = f.id_fi " +
               $"where k.nazev = '{names[0]}' and f.nazev = '{names[1]}';";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    kinosal = new Kinosaly(reader[3].ToString());
                    filmy = new Filmy(reader[4].ToString());
                    predstaveni = new Predstaveni(Convert.ToDateTime(reader[0]), Convert.ToDateTime(reader[1]), Convert.ToDouble(reader[2]), kinosal, filmy);


                }
                reader.Close();
                return predstaveni;
            }
        }

        public void Save(Predstaveni element)
        {
            string query = "insert into představení(dat_plan_pred, dat_kon_pred, delka, id_kis, id_fi) " +
                $"values ('{element.DatPlanovanehoPredstaveni}', '{element.DatKonanehoPredstaveni}', " +
                $"{element.DelkaPredstaveni}, {GetCinemaTheaterID(element.Kinosal)}, {GetFilmID(element.Film)});";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
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
