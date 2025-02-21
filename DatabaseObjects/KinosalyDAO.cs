using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace db_project
{
    /// <summary>
    /// Class implementing the DAO interface for the model class Kinosaly
    /// </summary>
    internal class KinosalyDAO : DAOInterface<Kinosaly>
    {
        /// <summary>
        /// Deletes the row based on the element parameter from the data table
        /// </summary>
        /// <param name="element"></param>
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

        /// <summary>
        /// Assigns all the values in the data table to Kinosaly objects 
        /// </summary>
        /// <returns> An enumerator over the Kinosaly objects</returns>

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
                        Kinosaly k = new Kinosaly(Convert.ToInt32(reader["id_kis"]), reader["nazev"].ToString(), Convert.ToInt32(reader["cis_sal"]));
                        yield return k;

                    }
                }
                
            }
        }

        /// <summary>
        /// Selects all the data from a row that matches the given name parameter and assigns it to a new Kinosaly object
        /// </summary>
        /// <param name="names"></param>
        /// <returns> A Kinosaly object with the given name parameter</returns>
        /// <exception cref="Exception"></exception>

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

        /// <summary>
        /// Inserts a new row into the data table
        /// </summary>
        /// <param name="element"></param>

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

        /// <summary>
        /// Updates the specified row of the data table with new values
        /// </summary>
        /// <param name="previousElement"></param>
        /// <param name="updatedElement"></param>
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
