﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal class ReziseriDAO : DAOInterface<Reziseri>
    {
        public void Delete(Reziseri element)
        {
            string query = $"delete from režiséři where jmeno = '{element.Jmeno}' and prijmeni='{element.Prijmeni}'";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Reziseri> GetAll()
        {
            string query = $"select * from režiséři;";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reziseri reziser = new Reziseri(reader[1].ToString(), reader[2].ToString(), Convert.ToDateTime(reader[3]));
                    reziser.Id_rez = Convert.ToInt32(reader[0]);
                    yield return reziser;

                }
                reader.Close();
            }
        }

        public Reziseri GetByValueName(params string[] names)
        {
            Reziseri? rez = null;
            string query = $"select * from režiséři where jmeno = '{names[0]}' and prijmeni = '{names[1]}';";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rez = new Reziseri(reader[1].ToString(), reader[2].ToString(), Convert.ToDateTime(reader[3]));
                    rez.Id_rez = Convert.ToInt32(reader[0]);
                   
                }
                reader.Close();
                return rez;
            }
        }

        public void Save(Reziseri element)
        {
            string query = $"insert into režiséři(jmeno, prijmeni, dat_nar) values ('{element.Jmeno}', '{element.Prijmeni}', '{element.DatNarozeni.ToString("yyyy-MM-dd")}');";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Reziseri previousElement, Reziseri updatedElement)
        {
            string query = $"update režiséři set jmeno='{updatedElement.Jmeno}', prijmeni='{updatedElement.Prijmeni}', dat_nar='{updatedElement.DatNarozeni}' " +
                $"where jmeno='{previousElement.Jmeno}' and prijmeni='{previousElement.Prijmeni}';";
            using (SqlConnection conn = DatabaseSingleton.GetConnInstance())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
