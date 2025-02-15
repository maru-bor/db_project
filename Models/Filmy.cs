using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal class Filmy
    {
        private int id;
        private string nazev;
        private DateTime datVzniku;
        private bool jeStalePromitanVKinech;
        private Reziseri reziser;
        private Zanry zanr;

        public int Id { get => id; set => id = value; }
        public string Nazev 
        { 
            get => nazev;
            set
            {
                if (value == null || value == "" || value.Length < 3 || value.Length > 100)
                {
                    throw new Exception("nevalidni delka nazvu");
                }
                else
                {
                    nazev = value;
                }

            }
        }
        public DateTime DatVzniku 
        { 
            get => datVzniku;
            set
            {
                if (value <= new DateTime(1900,1,1))
                {
                    throw new Exception("nevalidni zanr");
                }
                else
                {
                    datVzniku = value;
                }

            }
        }
        public bool JeStalePromitanVKinech  { get => jeStalePromitanVKinech; set => jeStalePromitanVKinech = value; }
        internal Reziseri Reziser 
        { 
            get => reziser;
            set
            {
                if (value == null)
                {
                    throw new Exception("nevalidni zanr");
                }
                else
                {
                    reziser = value;
                }

            }
        }
        internal Zanry Zanr 
        { 
            get => zanr; 
            set 
            {
                if(value == null)
                {
                    throw new Exception("nevalidni zanr");
                }
                else
                {
                    zanr = value;
                }
                
            }
        }

        public Filmy(int id, string nazev, DateTime datVzniku, bool jeStalePromitanVKinech)
        {
            Id = id;
            Nazev = nazev;
            DatVzniku = datVzniku;
            JeStalePromitanVKinech = jeStalePromitanVKinech;
        }

        public Filmy(string nazev, DateTime dat_vzniku, bool jeStalePromitanVKinech, Reziseri reziser, Zanry zanr)
        {
            Nazev = nazev;
            DatVzniku = dat_vzniku;
            JeStalePromitanVKinech = jeStalePromitanVKinech;
            Reziser = reziser;
            Zanr = zanr;
        }

        public Filmy(string nazev)
        {
            Nazev = nazev;
        }

        public override string? ToString()
        {
            return $"název filmu: {nazev} , dat. vzniku: {datVzniku}, stále promítán v kinech: {jeStalePromitanVKinech}, žánr: {Zanr.Nazev}, režisér: {Reziser.Jmeno} {Reziser.Prijmeni}";
        }
    }
}
