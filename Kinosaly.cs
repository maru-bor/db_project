using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal class Kinosaly
    {
        private int id_kis;
        private string nazev;
        private int cisloSalu;

        public int Id_kis { get => id_kis; set => id_kis = value; }
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
        public int CisloSalu 
        { 
            get => cisloSalu; 
            set
            {
                if(value == null || value <= 0)
                {
                    throw new Exception("nevalidni cislo kinosalu");
                }
                else
                {
                    cisloSalu = value;
                }
            } 
        }

        public Kinosaly(string nazev, int cisloSalu)
        {
            Nazev = nazev;
            CisloSalu = cisloSalu;
        }
    }
}
