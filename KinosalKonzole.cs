using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal class KinosalKonzole
    {
        private FilmyDAO filmyDAO = new FilmyDAO();
        private ZanryDAO zanryDAO = new ZanryDAO();
        private ReziseriDAO reziseriDAO = new ReziseriDAO();

        public void StartMenu()
        {
            try
            {
                MainMenu();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("chyba při připojení k databázi");
            }
            Console.WriteLine("Konec programu");
        }


        public void MainMenu()
        {
            try
            {
                int userInput = 0;
                while (userInput != 4)
                {
                    Console.WriteLine("zjistit informace o: ");
                    Console.WriteLine("1. filmech"
                             + "\n" + "2. žánrech"
                             + "\n" + "3. režisérech"
                             + "\n" + "4. exit");
                    userInput = Convert.ToInt32(Console.ReadLine().Trim());
                    switch (userInput)
                    {
                        case 1:
                            FilmMenu();
                            break;
                        case 2:
                            GenreMenu();
                            break;
                        case 3:
                            DirectorMenu();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("špatně zadaná hodnota!!");
                MainMenu();
            }
            
           
        }

        public string GetAllFilms()
        {
            return string.Join("\n", filmyDAO.GetAll());
        }

        public Filmy GetFilmByName(string name)
        {
            Filmy film = new Filmy(name);
            return filmyDAO.GetByValueName(film.Nazev);
        }

        public string WriteOutAllFilmsByGenre(string name)
        {
            Zanry zanr = new Zanry(name);
            return string.Join("\n", filmyDAO.GetAllFilmsByGenre(zanr));
        }

        public string WriteOutAllFilmsByDirector(string name, string surname)
        {
            Reziseri reziser = new Reziseri(name, surname);
            return string.Join("\n", filmyDAO.GetAllFilmsByDirector(reziser));
        }

        public string GetAllGenres()
        {
            return string.Join("\n", zanryDAO.GetAll());
        }

        public Zanry GetGenreByName(string name)
        {
            Zanry zanr = new Zanry(name);
            return zanryDAO.GetByValueName(zanr.Nazev);
        }

        public string GetAllDirectors()
        {
            return string.Join("\n", reziseriDAO.GetAll());
        }

        public Reziseri GetDirectorByName(string name, string surname)
        {
            Reziseri zanr = new Reziseri(name, surname);
            return reziseriDAO.GetByValueName(name, surname);
        }

        public void FilmMenu()
        {
            int userInput = 0;
            while (userInput != 5)
            {
                Console.WriteLine("--filmy--");
                Console.WriteLine("1. vypsat informace o všech filmech"
                         + "\n" + "2. vypsat informace o jednom filmu"
                         + "\n" + "3. vypsat všechny filmy jednoho žánru"
                         + "\n" + "4. vypsat všechny filmy jednoho režiséra"
                         + "\n" + "5. zpět na výběr");
                userInput = Convert.ToInt32(Console.ReadLine().Trim());
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine(GetAllFilms());
                        break;
                    case 2:
                        Console.WriteLine("zadej název filmu: ");
                        string name = "";
                        name = Console.ReadLine().Trim();
                        Console.WriteLine(GetFilmByName(name));
                        break;
                    case 3:
                        Console.WriteLine("zadej název žánru: ");
                        string genreName = "";
                        genreName = Console.ReadLine().Trim();
                        Console.WriteLine(WriteOutAllFilmsByGenre(genreName));
                        break;
                    case 4:
                        Console.WriteLine("zadej jméno režiséra: ");
                        string directorName = "";
                        directorName = Console.ReadLine().Trim();
                        Console.WriteLine("zadej příjmení režiséra: ");
                        string directorSurname = "";
                        directorSurname = Console.ReadLine().Trim();
                        Console.WriteLine(WriteOutAllFilmsByDirector(directorName, directorSurname));
                        break;
                }

            }
        }

        public void GenreMenu()
        {
            int userInput = 0;
            while (userInput != 3)
            {
                Console.WriteLine("--žánry--");
                Console.WriteLine("1. vypsat informace o všech žánrech"
                         + "\n" + "2. vypsat informace o jednom žánru"
                         + "\n" + "3. zpět na výběr");
                userInput = Convert.ToInt32(Console.ReadLine().Trim());
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine(GetAllGenres());
                        break;
                    case 2:
                        Console.WriteLine("zadej název žánru: ");
                        string name = "";
                        name = Console.ReadLine().Trim();
                        Console.WriteLine(GetGenreByName(name));
                        break;
                }

            }
        }

        public void DirectorMenu()
        {
            int userInput = 0;
            while (userInput != 3)
            {
                Console.WriteLine("--režiséři--");
                Console.WriteLine("1. vypsat informace o všech režisérech"
                         + "\n" + "2. vypsat informace o jednom režisérovi"
                         + "\n" + "3. zpět na výběr");
                userInput = Convert.ToInt32(Console.ReadLine().Trim());
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine(GetAllDirectors());
                        break;
                    case 2:
                        Console.WriteLine("zadej jméno režiséra: ");
                        string directorName = "";
                        directorName = Console.ReadLine().Trim();
                        Console.WriteLine("zadej příjmení režiséra: ");
                        string directorSurname = "";
                        directorSurname = Console.ReadLine().Trim();
                        Console.WriteLine(GetDirectorByName(directorName, directorSurname));
                        break;
                }

            }
        }





    }
}
