using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    /// <summary>
    /// Class that represents the console user interface
    /// </summary>
    internal class KinosalKonzole
    {
        private FilmyDAO filmyDAO = new FilmyDAO();
        private ZanryDAO zanryDAO = new ZanryDAO();
        private ReziseriDAO reziseriDAO = new ReziseriDAO();


        /// <summary>
        /// Calls the method for the main menu and checks for connection to the database
        /// </summary>
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

        /// <summary>
        /// Prints out main user interface to the console
        /// </summary>

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
                Console.WriteLine("špatně zadaná hodnota!");
                MainMenu();
            }
            
           
        }

        /// <summary>
        /// Joins all the films into a string and returns the string
        /// </summary>
        /// <returns> A string containing all the films in the database </returns>
        public string GetAllFilms()
        {
            return string.Join("\n", filmyDAO.GetAll());
        }

        /// <summary>
        /// Returns a Film object that matches the respective name parameter
        /// </summary>
        /// <param name="name"></param>
        /// <returns> A Film object that has the respective name parameter </returns>

        public Filmy GetFilmByName(string name)
        {
            Filmy film = new Filmy(name);
            return filmyDAO.GetByValueName(film.Nazev);
        }

        /// <summary>
        /// Joins all films matched by the given genre name into a string 
        /// </summary>
        /// <param name="name"></param>
        /// <returns> A string containing all the films that match the given genre in the database </returns>

        public string WriteOutAllFilmsByGenre(string name)
        {
            Zanry zanr = new Zanry(name);
            return string.Join("\n", filmyDAO.GetAllFilmsByGenre(zanr));
        }

        /// <summary>
        /// Joins all films matched by the given director name and surname into a string 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <returns> A string containing all the films that match the given director in the database </returns>

        public string WriteOutAllFilmsByDirector(string name, string surname)
        {
            Reziseri reziser = new Reziseri(name, surname);
            return string.Join("\n", filmyDAO.GetAllFilmsByDirector(reziser));
        }

        /// <summary>
        /// Joins all the genres into a string and returns the string
        /// </summary>
        /// <returns>  A string containing all the genres in the database </returns>

        public string GetAllGenres()
        {
            return string.Join("\n", zanryDAO.GetAll());
        }

        /// <summary>
        ///  Returns a Zanry object that matches the name parameter
        /// </summary>
        /// <param name="name"></param>
        /// <returns> A Zanry object that matches name parameter </returns>
        public Zanry GetGenreByName(string name)
        {
            Zanry zanr = new Zanry(name);
            return zanryDAO.GetByValueName(zanr.Nazev);
        }

        /// <summary>
        /// Joins all the directors into a string and returns the string
        /// </summary>
        /// <returns> A string containing all the directors in the database </returns>
        public string GetAllDirectors()
        {
            return string.Join("\n", reziseriDAO.GetAll());
        }

        /// <summary>
        /// Returns a Reziseri object that matches the name and surname parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <returns> A Reziseri object that matches name and surname parameter </returns>
        public Reziseri GetDirectorByName(string name, string surname)
        {
            Reziseri zanr = new Reziseri(name, surname);
            return reziseriDAO.GetByValueName(name, surname);
        }

        /// <summary>
        /// Prints out the film menu user interface to the console
        /// </summary>

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

        /// <summary>
        /// Prints out the genre menu user interface to the console
        /// </summary>
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

        /// <summary>
        /// Prints out the director menu user interface to the console
        /// </summary>
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
