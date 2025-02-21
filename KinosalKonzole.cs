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
                Console.WriteLine("Chyba při připojení k databázi");
            }
            Console.WriteLine("konec programu");
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
                    Console.WriteLine("--Hlavní menu--" + "\n" + "Vyber jednu z možností: ");
                    Console.WriteLine("1. filmy"
                             + "\n" + "2. žánry"
                             + "\n" + "3. režiséři"
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
                Console.WriteLine("(!!!) Špatná hodnota: zkontrolujte, zda-li tato hodnota v databázi existuje nebo je ve správném formátu");
                MainMenu();
            }
            
           
        }

        /// <summary>
        /// Joins all the films into a string
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
        /// Joins all the genres into a string
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
        /// Joins all the directors into a string
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
            while (userInput != 7)
            {
                Console.WriteLine("--Filmy--");
                Console.WriteLine("1. vypsat informace o všech filmech"
                         + "\n" + "2. vypsat informace o filmu"
                         + "\n" + "3. vypsat všechny filmy jednoho žánru"
                         + "\n" + "4. vypsat všechny filmy jednoho režiséra"
                         + "\n" + "5. přidat nový film"
                         + "\n" + "6. smazat film"
                         + "\n" + "7. zpět na výběr");
                userInput = Convert.ToInt32(Console.ReadLine().Trim());
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine(GetAllFilms());
                        break;
                    case 2:
                        Console.Write("zadej název filmu: ");
                        string name = "";
                        name = Console.ReadLine().Trim();
                        Console.Write(GetFilmByName(name));
                        break;
                    case 3:
                        Console.Write("zadej název žánru: ");
                        string genreName = "";
                        genreName = Console.ReadLine().Trim();
                        Console.WriteLine(WriteOutAllFilmsByGenre(genreName));
                        break;
                    case 4:
                        Console.Write("zadej jméno režiséra: ");
                        string directorName = "";
                        directorName = Console.ReadLine().Trim();
                        Console.Write("zadej příjmení režiséra: ");
                        string directorSurname = "";
                        directorSurname = Console.ReadLine().Trim();
                        Console.Write(WriteOutAllFilmsByDirector(directorName, directorSurname));
                        break;
                    case 5:
                        Console.Write("zadej název nového filmu: ");
                        string newMovieName = "";
                        newMovieName = Console.ReadLine().Trim();

                        Console.Write("zadej datum vzniku nového filmu (formát dd.MM.YYYY): ");
                        DateTime newMovieYear = new DateTime() ;
                        newMovieYear = Convert.ToDateTime(Console.ReadLine().Trim());

                        Console.Write("je tento film stále promítán v kinech? (true/false pouze malá písmena): ");
                        bool newMovieTheaterShowing;
                        newMovieTheaterShowing = Convert.ToBoolean(Console.ReadLine().Trim());

                        Console.Write("zadej název žánru nového filmu: ");
                        string newMovieGenreName = "";
                        newMovieGenreName = Console.ReadLine().Trim();

                        Console.Write("zadej jméno režiséra filmu: ");
                        string newMovieDirectorName = "";
                        newMovieDirectorName = Console.ReadLine().Trim();

                        Console.Write("zadej příjmení režiséra filmu: ");
                        string newMovieDirectorSurname = "";
                        newMovieDirectorSurname = Console.ReadLine().Trim();

                        Zanry genre = new Zanry(newMovieGenreName);
                        Reziseri director = new Reziseri(newMovieDirectorName, newMovieDirectorSurname);
                        Filmy film = new Filmy(newMovieName, newMovieYear, newMovieTheaterShowing, director, genre);

                        filmyDAO.Save(film);

                        Console.WriteLine("Film byl úspěšně přidán");

                        break;
                    case 6:
                        Console.Write("zadej název filmu: ");
                        string deleteMovieName = "";
                        deleteMovieName = Console.ReadLine().Trim();

                        Console.Write("zadej datum vzniku filmu (formát dd.MM.YYYY): ");
                        DateTime deleteMovieYear = new DateTime();
                        deleteMovieYear = Convert.ToDateTime(Console.ReadLine().Trim());

                        Filmy deleteFilm = new Filmy(deleteMovieName, deleteMovieYear);
                        filmyDAO.Delete(deleteFilm);
                        Console.WriteLine("Film byl úspěšně smazán");

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
            while (userInput != 5)
            {
                Console.WriteLine("--Žánry--");
                Console.WriteLine("1. vypsat informace o všech žánrech"
                         + "\n" + "2. vypsat informace o žánru"
                         + "\n" + "3. přidat žánr"
                         + "\n" + "4. upravit žánr"
                         + "\n" + "5. zpět na výběr");
                userInput = Convert.ToInt32(Console.ReadLine().Trim());
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine(GetAllGenres());
                        break;
                    case 2:
                        Console.Write("zadej název žánru: ");
                        string name = "";
                        name = Console.ReadLine().Trim();

                        Console.WriteLine(GetGenreByName(name));
                        break;
                    case 3:
                        Console.Write("zadej název nového žánru: ");
                        string newGenreName = "";
                        newGenreName = Console.ReadLine().Trim();

                        Console.Write("zadej trojciferný kód nového žánru: ");
                        int newGenreCode = 0;
                        newGenreCode = Convert.ToInt32(Console.ReadLine().Trim());

                        Zanry newGenre = new Zanry(newGenreName, newGenreCode);

                        zanryDAO.Save(newGenre);

                        break;
                    case 4:
                        Console.Write("zadej název žánru, který chceš upravit: ");
                        string prevGenreName = "";
                        prevGenreName = Console.ReadLine().Trim();

                        Console.Write("zadej trojciferný kód žánru, který chceš upravit: ");
                        int prevGenreCode = 0;
                        prevGenreCode = Convert.ToInt32(Console.ReadLine().Trim());

                        Console.Write("zadej nový název žánru: ");
                        string updateGenreName = "";
                        updateGenreName = Console.ReadLine().Trim();

                        Console.Write("zadej nový trojciferný kód žánru: ");
                        int updateGenreCode = 0;
                        updateGenreCode = Convert.ToInt32(Console.ReadLine().Trim());

                        Zanry prevGenre = new Zanry(prevGenreName, prevGenreCode);
                        Zanry updatedGenre = new Zanry(updateGenreName, updateGenreCode);

                        zanryDAO.Update(prevGenre, updatedGenre);

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
            while (userInput != 4)
            {
                Console.WriteLine("--Režiséři--");
                Console.WriteLine("1. vypsat informace o všech režisérech"
                         + "\n" + "2. vypsat informace o režisérovi"
                         + "\n" + "3. přidat režiséra"
                         + "\n" + "4. zpět na výběr");
                userInput = Convert.ToInt32(Console.ReadLine().Trim());
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine(GetAllDirectors());
                        break;
                    case 2:
                        Console.Write("zadej jméno režiséra: ");
                        string directorName = "";
                        directorName = Console.ReadLine().Trim();
                        Console.Write("zadej příjmení režiséra: ");
                        string directorSurname = "";
                        directorSurname = Console.ReadLine().Trim();
                        Console.WriteLine(GetDirectorByName(directorName, directorSurname));
                        break;
                    case 3:
                        Console.Write("zadej jméno nového režiséra: ");
                        string newDirectorName = "";
                        directorName = Console.ReadLine().Trim();

                        Console.Write("zadej příjmení nového režiséra: ");
                        string newDirectorSurname = "";
                        directorSurname = Console.ReadLine().Trim();

                        Console.Write("zadej datum narození nového režiséra (formát dd.MM.YYYY): "); 
                        DateTime newDirectorBirthYear = new DateTime();
                        newDirectorBirthYear = Convert.ToDateTime(Console.ReadLine().Trim());


                        Reziseri newDirector = new Reziseri(newDirectorName, newDirectorSurname, newDirectorBirthYear);

                        reziseriDAO.Save(newDirector);
                       


                        break;
                }

            }
        }





    }
}
