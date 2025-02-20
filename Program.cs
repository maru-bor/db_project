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
            KinosalKonzole kinosalKonzole = new KinosalKonzole();
            kinosalKonzole.StartMenu();
        }
    }
}
