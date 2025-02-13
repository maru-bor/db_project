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
            
            SqlConnection conn = DatabaseSingleton.GetConnInstance();

            string query = $"delete from žánry where nazev = '{element.Nazev}'";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Zanry> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetConnInstance();

            string query = $"select * from žánry;";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
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
            SqlConnection conn = DatabaseSingleton.GetConnInstance();

            Zanry z = null;
            string query = $"select * from žánry where nazev = '{names[0]}'";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
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
            throw new NotImplementedException();
        }

        public void Update(Zanry element)
        {
            throw new NotImplementedException();
        }
    }
}
