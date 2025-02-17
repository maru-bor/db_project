using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal class SaveElementsUI
    {

        private ZanryDAO zanryDAO = new ZanryDAO();
        private ReziseriDAO reziseriDAO = new ReziseriDAO();
        private KinosalyDAO kinosalyDAO = new KinosalyDAO();
        private FilmyDAO filmyDAO = new FilmyDAO(); 
        private PredstaveniDAO predstaveniDAO = new PredstaveniDAO();



        public void SaveMainMenu()
        {
            int userInput = 0;
            while(userInput != 6)
            {
                Console.WriteLine("Vybrali jste si operaci: VLOŽIT NOVÝ ZÁZNAM");
                Console.WriteLine("Vyber si tabulku, s kterou chcete pracovat: "
                                + "\n" + "1. zanry"
                                + "\n" + "2. reziseri"
                                + "\n" + "3. kinosaly"
                                + "\n" + "4. filmy"
                                + "\n" + "5. predstaveni"
                                + "\n" + "6. vratit se na seznam operaci");
                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        SaveGenreElement();
                        break;
                    case 2:
                        SaveDirectorElement();  
                        break; 
                    case 3:
                        SaveCinemaTheaterElement();
                        break;
                    case 4:
                        SaveFilmElement();
                        break;
                    case 5:
                        SaveFilmShowingElement();
                        break;


                }

            }
        }
        

        public void SaveGenreElement()
        {
            string nazevZanru = "";
            int kodZanru = 0;

            Zanry zanr = new Zanry();

            Console.Write("Napis nazev noveho zanru, ktery chces vlozit: ");
            nazevZanru = Console.ReadLine();

            Console.Write("Napis kod noveho zanru, ktery chces vlozit: ");
            kodZanru = Convert.ToInt32(Console.ReadLine());

            zanr = new Zanry(nazevZanru, kodZanru);

            zanryDAO.Save(zanr);
        }

        public void SaveDirectorElement()
        {
            string jmenoRez;
            string prijmeniRez;
            DateTime datNarozeni = new DateTime();


            Reziseri reziser = new Reziseri();

            Console.Write("Napis jmeno noveho rezisera, ktereho chces vlozit: ");
            jmenoRez = Console.ReadLine();

            Console.Write("Napis prijmeni noveho rezisera, ktereho chces vlozit: ");
            prijmeniRez = Console.ReadLine();

            Console.Write("Napis datum narozeni noveho rezisera, ktereho chces vlozit (format dd.MM.YYYY): ");
            datNarozeni = Convert.ToDateTime(Console.ReadLine());

            reziser = new Reziseri(jmenoRez, prijmeniRez, datNarozeni);

            reziseriDAO.Save(reziser);
        }

        public void SaveCinemaTheaterElement()
        {
            string nazevKinosalu = "";
            int cisloSalu = 0;

            Kinosaly kinosal = new Kinosaly();

            Console.Write("Napis nazev noveho kinosalu, ktery chces vlozit: ");
            nazevKinosalu = Console.ReadLine();

            Console.Write("Napis cislo noveho kinosalu, ktery chces vlozit: ");
            cisloSalu = Convert.ToInt32(Console.ReadLine());

            kinosal = new Kinosaly(nazevKinosalu, cisloSalu);

            kinosalyDAO.Save(kinosal);
        }


        public void SaveFilmElement()
        {
            string nazevFilmu = "";
            DateTime datVzniku = new DateTime();
            bool jeStalPromit = false;

            string jmenoRez = "";
            string prijmeniRez = "";
            DateTime datNarozeni = new DateTime();

            string nazevZanru = "";
            int kodZanru = 0;

            Reziseri reziser = new Reziseri();
            Zanry zanr = new Zanry();
            Filmy film = new Filmy();

            Console.Write("Napis nazev noveho filmu: ");
            nazevFilmu = Console.ReadLine();

            Console.Write("Napis datum vzniku noveho filmu (format dd.MM.YYYY): ");
            datVzniku = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Napis, zda-li je film soucasne promitan v kinech (true/false): ");
            jeStalPromit = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("---informace o reziserovi filmu---");

            Console.Write("Napis jmeno rezisera: ");
            jmenoRez = Console.ReadLine();

            Console.Write("Napis prijmeni rezisera: ");
            prijmeniRez = Console.ReadLine();

            Console.Write("Napis datum narozeni rezisera (format dd.MM.YYYY): ");
            datNarozeni = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("---informace o zanru filmu---");

            Console.Write("Napis nazev zanru: ");
            nazevZanru = Console.ReadLine();

            Console.Write("Napis kod zanru: ");
            kodZanru = Convert.ToInt32(Console.ReadLine());

            reziser = new Reziseri(jmenoRez, prijmeniRez, datNarozeni);
            zanr = new Zanry(nazevZanru, kodZanru);
            film = new Filmy(nazevFilmu, datVzniku, jeStalPromit, reziser, zanr);
            

            filmyDAO.Save(film);    
        }

        public void SaveFilmShowingElement()
        {
            DateTime datPlanPred = new DateTime();
            DateTime datKonPred = new DateTime();
            double delkaPred = 0;

            string nazevKinosalu = "";
            int cisloSalu = 0;

            string nazevFilmu = "";
            DateTime datVzniku = new DateTime();

            Kinosaly kinosal = new Kinosaly();
            Filmy film = new Filmy();
            Predstaveni predstaveni = new Predstaveni();

            Console.Write("Napis planovane datum predstaveni (format dd.MM.YYYY): ");
            datPlanPred = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Napis skutecne datum predstaveni (format dd.MM.YYYY): ");
            datKonPred = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Napis delku predstaveni (deset. cislo): ");
            delkaPred = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("---informace o kinosale ve kterem probehlo predstaveni---");

            Console.Write("Napis nazev kinosalu: ");
            nazevKinosalu = Console.ReadLine();

            Console.Write("Napis cislo kinosalu: ");
            cisloSalu = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("---informace o filmu ktery byl promitan---");

            Console.Write("Napis nazev filmu: ");
            nazevFilmu = Console.ReadLine();

            Console.Write("Napis datum vzniku filmu (format dd.MM.YYYY): ");
            datVzniku = Convert.ToDateTime(Console.ReadLine());

            kinosal = new Kinosaly(nazevKinosalu, cisloSalu);
            film = new Filmy(nazevFilmu, datVzniku);
            predstaveni = new Predstaveni(datPlanPred, datKonPred, delkaPred, kinosal, film);

            predstaveniDAO.Save(predstaveni);

        }


    }
}
