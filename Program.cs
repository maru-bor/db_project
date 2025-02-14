using Microsoft.Data.SqlClient;
using System.Configuration;

namespace db_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PredstaveniDAO dao = new PredstaveniDAO(); 
            Console.WriteLine(string.Join("\n", dao.GetAll()));
        }
    }
}
