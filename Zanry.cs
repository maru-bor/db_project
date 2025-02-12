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
                if (value.Length < 3 || value.Length > 100)
                {
                    throw new Exception("nevalidni delka nazvu: musi mit vice jak 3 znaky a mene nebo rovno 100 znaku");
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
                if (value <= 0)
                {
                    throw new Exception("nevalidni hodnota kodu: musi byt vetsi nez 0");
                }
                else 
                { 
                    kod = value;
                }
               
            }
        }

        public Zanry(string nazev, int kod)
        {
            this.nazev = nazev;
            this.kod = kod;
        }
    }
}
