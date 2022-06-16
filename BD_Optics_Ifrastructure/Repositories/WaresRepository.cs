using System;
using System.Collections.Generic;
using DB_Optics_core.Data;
using DB_Optics_core.Interface;
using MySql.Data.MySqlClient;

namespace BD_Optics_Ifrastructure.Repositories
{
    public class WaresRepository : IWaresRepository
    {
        protected string connString { get; set; }

        public WaresRepository()
        {
            connString = "server=127.0.0.1;uid=root;pwd=M4SOPMODIIJr;database=optics";
        }

        public Wares add(Wares entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Wares entity)
        {
            throw new NotImplementedException();
        }

        public Wares[] getAll()
        {
            var wares = new List<Wares>();
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("SELECT * FROM Wares " +
                                                     "JOIN Category on wares.`Categoty ID` = category.`Category ID`" +
                                                     "join `special offer` on wares.`Special offer ID` = `special offer`.`Special offer ID`;", conn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    wares.Add(new Wares(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(6), reader.GetInt32(10)));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return wares.ToArray();
        }

        public Wares getByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Wares update(Wares entity)
        {
            throw new NotImplementedException();
        }
    }
}
