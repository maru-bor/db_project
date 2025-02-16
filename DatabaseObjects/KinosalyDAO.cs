using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace db_project
{
    internal class KinosalyDAO : DAOInterface<Kinosaly>
    {
        public void Delete(Kinosaly element)
        {
            string query = "delete from kinosály where nazev = @nazev and cis_sal = @cis_sal;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nazev", element.Nazev);
                cmd.Parameters.AddWithValue("@cis_sal", element.CisloSalu);

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Kinosaly> GetAll()
        {
            string query = "select * from kinosály;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Kinosaly kinosal = new Kinosaly(Convert.ToInt32(reader["id_kis"]), reader["nazev"].ToString(), Convert.ToInt32(reader["cis_sal"]));
                        yield return kinosal;

                    }
                }
                
            }
        }

        public Kinosaly GetByValueName(params string[] names)
        {
            if (names == null || names.Length == 0)
            {
                throw new Exception("alespon jedno jmeno musi byt poskytnuto");
            }

            Kinosaly? k = null;
            string query = "select * from kinosály where nazev = @nazev)";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nazev", names[0]);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        k = new Kinosaly(Convert.ToInt32(reader["id_kis"]), reader["nazev"].ToString(), Convert.ToInt32(reader["cis_sal"]));
                        
                    }

                   
                }
                    
               
            }
            return k;
        }

        public void Save(Kinosaly element)
        {
            string query = "insert into kinosály(nazev, cis_sal) values (@nazev, @cis_sal);";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nazev", element.Nazev);
                cmd.Parameters.AddWithValue("@cis_sal", element.CisloSalu);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Kinosaly previousElement, Kinosaly updatedElement)
        {
            string query = "update kinosály set nazev = @nazev, cis_sal = @cis_sal " +
                           "where nazev = @prev_nazev and cis_sal = @prev_cis_sal;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nazev", updatedElement.Nazev);
                cmd.Parameters.AddWithValue("@cis_sal", updatedElement.CisloSalu);

                cmd.Parameters.AddWithValue("@prev_nazev", previousElement.Nazev);
                cmd.Parameters.AddWithValue("@prev_cis_sal", previousElement.CisloSalu);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
