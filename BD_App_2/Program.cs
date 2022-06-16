using System;

namespace BD_App_2
{
    class Program
    {
        static void Main(string[] args)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string connectionString;

            try
            {
                connectionString = "server=127.0.0.1;uid=root;pwd=M4SOPMODIIJr;database=optics";
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                Console.WriteLine("Успешно");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
