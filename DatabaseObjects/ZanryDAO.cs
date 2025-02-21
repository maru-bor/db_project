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
    /// Class implementing the DAO interface for the model class Zanry
    /// </summary>
    class ZanryDAO : DAOInterface<Zanry>
    {

        /// <summary>
        /// Deletes the row based on the element parameter from the data table
        /// </summary>
        /// <param name="element"></param>
        public void Delete(Zanry element)
        {
            try
            {
                string query = "delete from žánry where nazev = @nazev";


                SqlConnection conn = DatabaseSingleton.GetConnInstance();


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nazev", element.Nazev);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při mazání záznamu v žánrech");
            }
           
                    
                
            
        }

        /// <summary>
        /// Assigns all the values in the data table to a collection of Zanry objects 
        /// </summary>
        /// <returns> A collection of Zanry objects</returns>

        public IEnumerable<Zanry> GetAll()
        {
            string query = "select * from žánry;";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            
                

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                         while (reader.Read())
                         {
                            Zanry zanr = new Zanry(Convert.ToInt32(reader["id_za"]), reader["nazev"].ToString(), Convert.ToInt32(reader["kod"]));
                            yield return zanr;

                         }
                        
                    }
                    
                    
            }
               
               
            
        }

        /// <summary>
        /// Selects all the data from a table row that contains the given name parameter and assigns it to a new Zanry object
        /// </summary>
        /// <param name="names"></param>
        /// <returns> A Zanry object with the given name parameter</returns>
        /// <exception cref="Exception"></exception>

        public Zanry GetByValueName(params string[] names)
        {
            if (names == null || names.Length == 0)
            {
                throw new Exception("You must provide at least one name!");
            }

            Zanry? z = null;
            string query = "select * from žánry where nazev = @nazev";
            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            
                

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@nazev", names[0]);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            z = new Zanry(Convert.ToInt32(reader["id_za"]), reader["nazev"].ToString(), Convert.ToInt32(reader["kod"]));


                        }
                       
                    }
                }
                return z;


            


        }

        /// <summary>
        /// Inserts a new row with data into the data table
        /// </summary>
        /// <param name="element"></param>
        public void Save(Zanry element)
        {
            try
            {
                string query = "insert into žánry(nazev, kod) values (@nazev , @kod);";
                SqlConnection conn = DatabaseSingleton.GetConnInstance();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nazev", element.Nazev);
                    cmd.Parameters.AddWithValue("@kod", element.Kod);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Chyba při vkládání záznamu v žánrech");
            }
            
            

        }

        /// <summary>
        /// Updates the specified row of the data table with new values
        /// </summary>
        /// <param name="previousElement"></param>
        /// <param name="updatedElement"></param>

        public void Update(Zanry previousElement, Zanry updatedElement)
        {
            try 
            {
                string query = "update žánry set nazev = @nazev, kod = @kod where nazev = @prevNazev and kod = @prevKod;";
                SqlConnection conn = DatabaseSingleton.GetConnInstance();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nazev", updatedElement.Nazev);
                    cmd.Parameters.AddWithValue("@kod", updatedElement.Kod);
                    cmd.Parameters.AddWithValue("@prevNazev", previousElement.Nazev);
                    cmd.Parameters.AddWithValue("@prevKod", previousElement.Kod);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Chyba při upravování záznamu v žánrech");
            }
           
            
        }


    }
}
