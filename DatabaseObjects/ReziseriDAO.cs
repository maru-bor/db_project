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
    /// Class implementing the DAO interface for the model class Reyiseri
    /// </summary>
    internal class ReziseriDAO : DAOInterface<Reziseri>
    {
        /// <summary>
        /// Deletes the row based on the element parameter from the data table
        /// </summary>
        /// <param name="element"></param>
        public void Delete(Reziseri element)
        {
            string query = "delete from režiséři where jmeno = @jmeno and prijmeni = @prijmeni and dat_nar = @dat_nar";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@jmeno", element.Jmeno);
                cmd.Parameters.AddWithValue("@prijmeni", element.Prijmeni);
                cmd.Parameters.AddWithValue("@dat_nar", element.DatNarozeni);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Assigns all the values in the data table to Reziseri objects 
        /// </summary>
        /// <returns> An enumerator over the Reziseri objects</returns>

        public IEnumerable<Reziseri> GetAll()
        {
            string query = "select * from režiséři;";

            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Reziseri r = new Reziseri(Convert.ToInt32(reader["id_rez"]), reader["jmeno"].ToString(), reader["prijmeni"].ToString(), Convert.ToDateTime(reader["dat_nar"]));

                        yield return r;

                    }
                }
                
            }
        }

        /// <summary>
        /// Selects all the data from a row that matches the given name parameter and assigns it to a new Reziseri object
        /// </summary>
        /// <param name="names"></param>
        /// <returns> A Reziseri object with the given name parameter</returns>
        /// <exception cref="Exception"></exception>

        public Reziseri GetByValueName(params string[] names)
        {
            if (names == null || names.Length < 2)
            {
                throw new Exception("alespon dve jmena musi byt poskytnuta");
            }
            Reziseri? rez = null;
            string query = "select * from režiséři where jmeno = @jmeno and prijmeni = @prijmeni;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@jmeno", names[0]);
                cmd.Parameters.AddWithValue("@prijmeni", names[1]);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rez = new Reziseri(Convert.ToInt32(reader["id_rez"]), reader["jmeno"].ToString(), reader["prijmeni"].ToString(), Convert.ToDateTime(reader["dat_nar"]));
                       

                    }
                    
                }
                    
               
            }
            return rez;
        }

        /// <summary>
        /// Inserts a new row into the data table
        /// </summary>
        /// <param name="element"></param>

        public void Save(Reziseri element)
        {
            try
            {
                string query = "insert into režiséři(jmeno, prijmeni, dat_nar) values (@jmeno, @prijmeni, @dat_nar);";
                SqlConnection conn = DatabaseSingleton.GetConnInstance();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@jmeno", element.Jmeno);
                    cmd.Parameters.AddWithValue("@prijmeni", element.Prijmeni);
                    cmd.Parameters.AddWithValue("@dat_nar", element.DatNarozeni.ToString("yyyy-MM-dd"));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("chyba pri vlozeni noveho zaznamu");
            }
           
        }

        /// <summary>
        /// Updates the specified row of the data table with new values
        /// </summary>
        /// <param name="previousElement"></param>
        /// <param name="updatedElement"></param>
        public void Update(Reziseri previousElement, Reziseri updatedElement)
        {
            string query = "update režiséři set jmeno = @jmeno, prijmeni = @prijmeni, dat_nar = @dat_nar " +
                           "where jmeno = @prev_jmeno and prijmeni = @prev_prijmeni and dat_nar = @prev_dat_nar;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@jmeno", updatedElement.Jmeno);
                cmd.Parameters.AddWithValue("@prijmeni", updatedElement.Prijmeni);
                cmd.Parameters.AddWithValue("@dat_nar", updatedElement.DatNarozeni.ToString("yyyy-MM-dd HH:mm:ss.fff"));

                cmd.Parameters.AddWithValue("@prev_jmeno", previousElement.Jmeno);
                cmd.Parameters.AddWithValue("@prev_prijmeni", previousElement.Prijmeni);
                cmd.Parameters.AddWithValue("@prev_dat_nar", previousElement.DatNarozeni.ToString("yyyy-MM-dd HH:mm:ss.fff"));

                cmd.ExecuteNonQuery();
            }
        }
    }
}
