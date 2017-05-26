using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ConsoleApp4
{

    public class PostGreSQL
    {
        List<string> dataItems = new List<string>();

        public void PostgreSQL()
        {
        }

        public List<string> PostgreSQLConnection()
        {
            try
            {

                string connectionString = "Server=127.0.0.1; Port=5432;" +
                    " User Id=postgres; Password=******; Database=niceDatabase";
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM public.\"myTable\"", connection);
                NpgsqlDataReader dataReader = command.ExecuteReader();
                for (int i=0; dataReader.Read(); i++)
                {
                    dataItems.Add(dataReader[0].ToString());
                }
                foreach(string i in dataItems)
                {
                    Console.WriteLine(i);
                }
                connection.Close();
                Console.ReadLine();
                return dataItems;
            }catch(Exception msg)
            {
                Console.WriteLine("problem");
                Console.ReadLine();
                return null;
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            PostGreSQL postg = new PostGreSQL();
            postg.PostgreSQLConnection();
        }
    }
}
