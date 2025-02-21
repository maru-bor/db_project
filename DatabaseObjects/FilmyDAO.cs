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
    /// Class implementing the DAO interface for the model class Filmy
    /// </summary>
    internal class FilmyDAO : DAOInterface<Filmy>
    {
        
        /// <summary>
        /// Deletes the row based on the element parameter from the data table
        /// </summary>
        /// <param name="element"></param>
        public void Delete(Filmy element)
        {
            try
            {
                string query = "delete from filmy where nazev = @nazev and dat_vznik = @dat_vznik;";
                SqlConnection conn = DatabaseSingleton.GetConnInstance();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nazev", element.Nazev);
                    cmd.Parameters.AddWithValue("@dat_vznik", element.DatVzniku);


                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při mazání záznamu ve filmech");
            }
            
        }

        /// <summary>
        /// Assigns all the values in the data table to Filmy objects 
        /// </summary>
        /// <returns> An enumerator over the Filmy objects</returns>

        public IEnumerable<Filmy> GetAll()
        {
            string query = "select f.nazev, f.dat_vzniku, f.je_stale_promitan, z.nazev as nazev_za, r.jmeno, r.prijmeni from filmy f " +
                           "join žánry z on f.id_za = z.id_za " +
                           "join režiséři r on f.id_rez = r.id_rez;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Reziseri r = new Reziseri(reader["jmeno"].ToString(), reader["prijmeni"].ToString());
                        Zanry z = new Zanry(reader["nazev_za"].ToString());
                        Filmy f = new Filmy(reader["nazev"].ToString(), Convert.ToDateTime(reader["dat_vzniku"]), Convert.ToBoolean(reader["je_stale_promitan"]), r, z);

                        yield return f;

                    }
                }
                    
            }
        }

        /// <summary>
        /// Selects all the data from a row that matches the given name parameter and assigns it to a new Filmy object
        /// </summary>
        /// <param name="names"></param>
        /// <returns> A Filmy object with the given name parameter</returns>
        /// <exception cref="Exception"></exception>

        public Filmy GetByValueName(params string[] names)
        {
            if (names == null || names.Length == 0)
            {
                throw new Exception("alespon jedno jmeno musi byt poskytnuto");
            }

            Filmy f = null;
            Reziseri r = null;
            Zanry z = null;
            string query = "select f.nazev, f.dat_vzniku, f.je_stale_promitan, z.nazev as nazev_za, r.jmeno, r.prijmeni from filmy f " +
                           "join žánry z on f.id_za = z.id_za " +
                           "join režiséři r on f.id_rez = r.id_rez " +
                           "where f.nazev = @nazev;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nazev", names[0]);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        r = new Reziseri(reader["jmeno"].ToString(), reader["prijmeni"].ToString());
                        z = new Zanry(reader["nazev_za"].ToString());
                        f = new Filmy(reader["nazev"].ToString(), Convert.ToDateTime(reader["dat_vzniku"]), Convert.ToBoolean(reader["je_stale_promitan"]), r, z);

                    }
                }
                   
               
               
                
            }
            return f;
        }

        /// <summary>
        /// Inserts a new row into the data table
        /// </summary>
        /// <param name="element"></param>

        public void Save(Filmy element)
        {
            try
            {
                string query = "insert into filmy(nazev, dat_vzniku, je_stale_promitan, id_za, id_rez) " +
                           "values (@nazev, @dat_vznik, @je_stale_promitan, " +
                           "@id_za, @id_rez);";
                SqlConnection conn = DatabaseSingleton.GetConnInstance();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nazev", element.Nazev);
                    cmd.Parameters.AddWithValue("@dat_vznik", element.DatVzniku);
                    cmd.Parameters.AddWithValue("@je_stale_promitan", element.JeStalePromitanVKinech);
                    cmd.Parameters.AddWithValue("@id_za", GetGenreID(element.Zanr));
                    cmd.Parameters.AddWithValue("@id_rez", GetDirectorID(element.Reziser));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při vkládání záznamu ve filmech");
            }
            
        }

        /// <summary>
        /// Updates the specified row of the data table with new values
        /// </summary>
        /// <param name="previousElement"></param>
        /// <param name="updatedElement"></param>

        public void Update(Filmy previousElement, Filmy updatedElement)
        {
            try
            {
                string query = "update filmy set nazev = @nazev, dat_vzniku = @dat_vznik, " +
                          "je_stale_promitan = @je_stale_promitan, id_za = @id_za, id_rez = @id_rez " +
                          "where nazev = @prev_nazev and dat_vznik = @prev_dat_vznik and id_rez = @prev_id_rez";
                SqlConnection conn = DatabaseSingleton.GetConnInstance();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@nazev", updatedElement.Nazev);
                    cmd.Parameters.AddWithValue("@dat_vznik", updatedElement.DatVzniku);
                    cmd.Parameters.AddWithValue("@je_stale_promitan", updatedElement.JeStalePromitanVKinech);
                    cmd.Parameters.AddWithValue("@id_za", GetGenreID(updatedElement.Zanr));
                    cmd.Parameters.AddWithValue("@id_rez", GetDirectorID(updatedElement.Reziser));

                    cmd.Parameters.AddWithValue("@prev_nazev", previousElement.Nazev);
                    cmd.Parameters.AddWithValue("@prev_dat_vznik", previousElement.DatVzniku);
                    cmd.Parameters.AddWithValue("@prev_id_rez", GetDirectorID(previousElement.Reziser));


                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při upravování záznamu ve filmech");
            }
           
        }

        public IEnumerable<Filmy> GetAllFilmsByGenre(Zanry zanr) 
        {
            string query = "select z.nazev as nazev_zanru, r.jmeno, r.prijmeni, " +
                           "f.nazev as nazev_filmu, f.dat_vzniku, f.je_stale_promitan from filmy f " +
                           "join žánry z on f.id_za = z.id_za " +
                           "join režiséři r on f.id_rez = r.id_rez " +
                           "where z.nazev = @nazev;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nazev", zanr.Nazev);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Reziseri reziser = new Reziseri(reader["jmeno"].ToString(), reader["prijmeni"].ToString());
                        Zanry zanr2 = new Zanry(reader["nazev_zanru"].ToString());
                        Filmy film = new Filmy(reader["nazev_filmu"].ToString(), Convert.ToDateTime(reader["dat_vzniku"]), 
                                     Convert.ToBoolean(reader["je_stale_promitan"]), reziser, zanr2);

                        yield return film;

                    }
                }

            }
        }

        public IEnumerable<Filmy> GetAllFilmsByDirector(Reziseri reziser)
        {
            string query = "select z.nazev as nazev_zanru, r.jmeno, r.prijmeni, " +
                           "f.nazev as nazev_filmu, f.dat_vzniku, f.je_stale_promitan from filmy f " +
                           "join žánry z on f.id_za = z.id_za " +
                           "join režiséři r on f.id_rez = r.id_rez " +
                           "where r.jmeno = @jmeno and r.prijmeni = @prijmeni;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@jmeno", reziser.Jmeno);
                cmd.Parameters.AddWithValue("@prijmeni", reziser.Jmeno);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Reziseri reziser2 = new Reziseri(reader["jmeno"].ToString(), reader["prijmeni"].ToString());
                        Zanry zanr2 = new Zanry(reader["nazev_zanru"].ToString());
                        Filmy film = new Filmy(reader["nazev_filmu"].ToString(), Convert.ToDateTime(reader["dat_vzniku"]),
                                     Convert.ToBoolean(reader["je_stale_promitan"]), reziser2, zanr2);

                        yield return film;

                    }
                }

            }
        }

        /// <summary>
        /// Returns the ID of the specified Zanry object in the database
        /// </summary>
        /// <param name="film"></param>
        /// <returns> ID of the specified Zanry object in the database</returns>
        private int GetGenreID(Zanry zanr)
        {
            try
            {
                int idValue = 0;
                string query = "select id_za from žánry where nazev = @nazev and kod = @kod";
                SqlConnection conn = DatabaseSingleton.GetConnInstance();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@nazev", zanr.Nazev);
                    cmd.Parameters.AddWithValue("@kod", zanr.Kod);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            idValue = Convert.ToInt32(reader[0]);

                        }

                    }
                }

                return idValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při získávání ID z databáze");
                return 0;
            }

           
        }

        /// <summary>
        /// Returns the ID of the specified Reziseri object in the database
        /// </summary>
        /// <param name="film"></param>
        /// <returns> ID of the specified Reziseri object in the database</returns>
        private int GetDirectorID(Reziseri reziser)
        {
            try
            {
                int idValue = 0;
                string query = "select id_rez from režiséři where jmeno = @jmeno and prijmeni = @prijmeni and dat_nar = @dat_nar;";
                SqlConnection conn = DatabaseSingleton.GetConnInstance();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@jmeno", reziser.Jmeno);
                    cmd.Parameters.AddWithValue("@prijmeni", reziser.Prijmeni);
                    cmd.Parameters.AddWithValue("@dat_nar", reziser.DatNarozeni);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            idValue = Convert.ToInt32(reader[0]);

                        }
                    }

                }
                return idValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při získávání ID z databáze");
                return 0;
            }

            
        }

       
    }
}
