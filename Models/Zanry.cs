using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal class Zanry
    {
        private int id_za;
        private string nazev;
        private int kod;

        public int Id_za { get => id_za; set => id_za = value; }
        public string Nazev 
        { 
            get => nazev;
            set 
            {
                if (value == null || value.Length < 3 || value.Length > 100)
                {
                    throw new Exception("nevalidni delka nazvu");
                }
                else 
                {
                    nazev = value;
                }
                
            } 
        }
        public int Kod 
        { 
            get => kod;
            set 
            {
                if (value == null || value <= 0)
                {
                    throw new Exception("nevalidni hodnota kodu");
                }
                else 
                { 
                    kod = value;
                }
               
            }
        }
        public Zanry(int id_za, string nazev, int kod)
        {
            Id_za = id_za;
            Nazev = nazev;
            Kod = kod;
        }
        public Zanry(string nazev, int kod)
        {
            Nazev = nazev;
            Kod = kod;
        }

        public Zanry(string nazev)
        {
            Nazev = nazev;
        }

        public Zanry(){}

        public override string? ToString()
        {
            return $"{nazev}, kód: {kod}";
        }
    }
}
