using Microsoft.Data.SqlClient;
using System.Configuration;

namespace db_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            ZanryDAO zanry = new ZanryDAO();
            // zanry.Update(new Zanry("komedie", 555), new Zanry("horor", 666));
            zanry.Save(new Zanry("drama", 841));

        }
    }
}
