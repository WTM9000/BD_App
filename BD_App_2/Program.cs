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

                var command = conn.CreateCommand();

                command.CommandText = "select count(*) from `discount card` where `Expiry date` > curdate() and `Register date` < curdate();";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}");
                }

                reader.Close();

                command.Dispose();

                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
