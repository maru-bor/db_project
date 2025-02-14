using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal class Reziseri
    {
        private int id_rez;
        private string jmeno;
        private string prijmeni;
        private DateTime datNarozeni;

        public int Id_rez { get => id_rez; set => id_rez = value; }
        public string? Jmeno 
        { 
            get => jmeno;
            set 
            { 
                if(value == null || value.Length < 3 || value.Length > 40)
                {
                    throw new Exception("nevalidni jmeno");
                }
                else
                {
                    jmeno = value;
                }
            } 
        }
        public string? Prijmeni 
        { 
            get => prijmeni;
            set
            {
                if (value == null || value.Length < 3 || value.Length > 50)
                {
                    throw new Exception("nevalidni prijmeni");
                }
                else
                {
                    prijmeni = value;
                }
            }
        }
        public DateTime DatNarozeni 
        { 
            get => datNarozeni; 
            set 
            {
                if(value <= new DateTime(1900, 1, 1))
                {
                    throw new Exception("nevalidni datum narozeni");
                }
                else
                {
                    datNarozeni = value;
                }
            
            } 
        }

        public Reziseri(string jmeno, string prijmeni, DateTime datNarozeni)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;    
            DatNarozeni = datNarozeni;
            
        }

        public Reziseri(string? jmeno, string? prijmeni)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
        }

        public Reziseri(int id_rez, string? jmeno, string? prijmeni, DateTime datNarozeni)
        {
            Id_rez = id_rez;
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            DatNarozeni = datNarozeni;
        }

        public Reziseri()
        {
        }

        public override string? ToString()
        {
            return $"{jmeno} {prijmeni}, {datNarozeni}";
        }
    }
}
