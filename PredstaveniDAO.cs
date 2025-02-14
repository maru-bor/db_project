using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void Save(Predstaveni element)
        {
            throw new NotImplementedException();
        }

        public void Update(Predstaveni previousElement, Predstaveni updatedElement)
        {
            throw new NotImplementedException();
        }
    }
}
