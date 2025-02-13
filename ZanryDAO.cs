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
            
           

            string query = $"delete from žánry where nazev = '{element.Nazev}'";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Zanry> GetAll()
        {
            

            string query = $"select * from žánry;";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    Zanry zanr = new Zanry(reader[1].ToString(), Convert.ToInt32(reader[2]));
                    zanr.Id_za = Convert.ToInt32(reader[0]);
                    yield return zanr;
                    
                }
                reader.Close();
            }
        }

    
        public Zanry GetByValueName(params string[] names)
        {
            

            Zanry z = null;
            string query = $"select * from žánry where nazev = '{names[0]}'";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                      z = new Zanry();
                      z.Id_za = Convert.ToInt32(reader[0]);
                      z.Nazev = reader[1].ToString();
                      z.Kod = Convert.ToInt32(reader[2]);
                    

                }
                reader.Close();
                return z;
            }


        }

        public void Save(Zanry element)
        {
            
            string query = $"insert into žánry(nazev, kod) values ('{element.Nazev}', {element.Kod});";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Zanry previousElement, Zanry updatedElement)
        {
           
            string query = $"update žánry set nazev='{updatedElement.Nazev}', kod={updatedElement.Kod} where nazev={previousElement.Nazev}";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
