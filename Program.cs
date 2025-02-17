using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using System.Configuration;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace db_project
{
    internal class Program
    {
        static void Main(string[] args)
        {


          /*  int userIpt = 0;
            while(userIpt != 6)
            {
                Console.WriteLine("Vyberte tabulku, s kterou chcete pracovat: " 
                                 + "\n" + "1. zanry" 
                                 + "\n" + "2. reziseri" 
                                 + "\n" + "3. kinosaly" 
                                 + "\n" + "4. filmy" 
                                 + "\n" + "5. predstaveni" 
                                 + "\n" + "6. exit");
                userIpt = Convert.ToInt32(Console.ReadLine());

                switch (userIpt) 
                {
                    case 1:
                        Console.WriteLine("zanry!!!");
                        ZanryDAO zanryDAO = new ZanryDAO();

                        int zanryUsrInpt = 0;
                        while (zanryUsrInpt != 7)
                        {
                            Console.WriteLine("Vyberte jednu z moznosti : "
                                + "\n" + "1. vypsat vsechny zanry" + "\n" + "2. vypsat zanr podle nazvu"
                                + "\n" + "3. vlozit novy zanr" + "\n" + "4. upravit zanr"
                                + "\n" + "5. smazat zanr" + "\n" + "6. import zanry z JSON souboru" 
                                + "\n" + "7. zpet k vyberu tabulek");
                            Console.WriteLine();
                            zanryUsrInpt = Convert.ToInt32(Console.ReadLine());
                            switch (zanryUsrInpt) 
                            {
                                case 1:
                                    Console.WriteLine(string.Join("\n", zanryDAO.GetAll()));
                                    break;
                                case 2:
                                    string usrGenreInput = "";
                                    Zanry zanr = null;   
                                    Console.Write("Napis jmeno zanru, ktery chces vypsat: ");
                                    usrGenreInput = Console.ReadLine();
                                    zanr = new Zanry(usrGenreInput);
                                    Console.WriteLine(zanryDAO.GetByValueName(zanr.Nazev));
                                    break;
                                case 3:
                                    string nazevZanru = "";
                                    int kodZanru = 0;
                                    Zanry zanr2 = null;
                                    Console.Write("Napis jmeno noveho zanru, ktery chces vlozit: ");
                                    nazevZanru = Console.ReadLine();
                                    Console.Write("Napis kod noveho zanru, ktery chces vlozit: ");
                                    kodZanru = Convert.ToInt32(Console.ReadLine());
                                    zanr2 = new Zanry(nazevZanru, kodZanru);
                                    zanryDAO.Save(zanr2);
                                    break;
                                case 4:
                                    string nazevOrgZanru = "";
                                    int kodOrgZanru = 0;

                                    string nazevNovehoZanru = "";
                                    int kodNovehoZanru = 0;

                                    Zanry orgZanr = null;
                                    Zanry novyZanr = null;

                                    Console.Write("Napis jmeno zanru, ktery chces upravit: ");
                                    nazevOrgZanru = Console.ReadLine();
                                    Console.Write("Napis kod zanru, ktery chces upravit: ");
                                    kodOrgZanru = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Zadej nove jmeno zanru: ");
                                    nazevNovehoZanru = Console.ReadLine();
                                    Console.Write("Zadej novy kod zanru: ");
                                    kodNovehoZanru = Convert.ToInt32(Console.ReadLine());

                                    zanryDAO.Update(orgZanr, novyZanr);
                                    break;




                            }
                        }

                        break;
                }
          }*/


            SaveElementsUI saveElementsUI = new SaveElementsUI();
            saveElementsUI.SaveMainMenu();

            

            

        }
    }
}
