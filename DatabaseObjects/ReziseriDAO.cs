using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace db_project
{
    internal class ReziseriDAO : DAOInterface<Reziseri>
    {
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
                        Reziseri reziser = new Reziseri(Convert.ToInt32(reader["id_rez"]), reader["jmeno"].ToString(), reader["prijmeni"].ToString(), Convert.ToDateTime(reader["dat_nar"]));

                        yield return reziser;

                    }
                }
                
            }
        }

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
