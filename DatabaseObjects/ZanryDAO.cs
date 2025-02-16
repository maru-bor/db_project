using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace db_project
{
    class ZanryDAO : DAOInterface<Zanry>
    {
        public void Delete(Zanry element)
        {
            string query = $"delete from žánry where nazev = @nazev";


            SqlConnection conn = DatabaseSingleton.GetConnInstance();
            
               
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nazev", element.Nazev);
                cmd.ExecuteNonQuery();
            }
                    
                
            
        }

        public IEnumerable<Zanry> GetAll()
        {
            string query = $"select * from žánry;";
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


        public Zanry GetByValueName(params string[] names)
        {
            if (names == null || names.Length == 0)
            {
                throw new Exception("alespon jedno jmeno musi byt poskytnuto");
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

        public void Save(Zanry element)
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

        public void Update(Zanry previousElement, Zanry updatedElement)
        {
           
            string query = $"update žánry set nazev = @nazev, kod = @kod where nazev = @prevNazev and kod = @prevKod;";
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


    }
}
