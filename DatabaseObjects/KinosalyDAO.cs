using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal class KinosalyDAO : DAOInterface<Kinosaly>
    {
        public void Delete(Kinosaly element)
        {
            string query = $"delete from kinosály where nazev = '{element.Nazev}' and cis_sal = '{element.CisloSalu}'";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Kinosaly> GetAll()
        {
            string query = $"select * from kinosály;";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kinosaly kinosal = new Kinosaly(reader[1].ToString(), Convert.ToInt32(reader[2]));
                    kinosal.Id_kis = Convert.ToInt32(reader[0]);
                    yield return kinosal;

                }
                reader.Close();
            }
        }

        public Kinosaly GetByValueName(params string[] names)
        {
            Kinosaly? k = null;
            string query = $"select * from kinosály where nazev = '{names[0]}'";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    k = new Kinosaly(reader[1].ToString(), Convert.ToInt32(reader[2]));
                    k.Id_kis = Convert.ToInt32(reader[0]);


                }
                reader.Close();
                return k;
            }
        }

        public void Save(Kinosaly element)
        {
            string query = $"insert into kinosály(nazev, cis_sal) values ('{element.Nazev}', {element.CisloSalu});";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Kinosaly previousElement, Kinosaly updatedElement)
        {
            string query = $"update kinosály set nazev='{updatedElement.Nazev}', cis_sal={updatedElement.CisloSalu} " +
                $"where nazev='{previousElement.Nazev} and cis_sal={previousElement.CisloSalu}';";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
