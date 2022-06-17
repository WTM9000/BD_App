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
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("", conn);

                command.CommandText = $"INSERT INTO `Wares` (`Name`, `Cost`, `Categoty ID`, `Special offer ID`) " +
                                      $"VALUES ('{entity.Name}', {entity.Cost}, {entity.CategoryID}, {entity.DiscountID});" +
                                      "SELECT LAST_INSERT_ID();";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    entity.ID = reader.GetInt32(0);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Wares newWare = getByID(entity.ID);

            return newWare;
        }

        public void delete(int ID)
        {
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("", conn);

                command.CommandText = $"Delete from wares where `Ware ID` = {ID}";

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
                                                     "join `special offer` on wares.`Special offer ID` = `special offer`.`Special offer ID`" +
                                                     "order by `Ware ID`;", 
                                                     conn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    wares.Add(new Wares(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(6), reader.GetFloat(10)));
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
            Wares ware = null;
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("SELECT * FROM Wares " +
                                                     "JOIN Category on wares.`Categoty ID` = category.`Category ID`" +
                                                     "join `special offer` on wares.`Special offer ID` = `special offer`.`Special offer ID`" +
                                                     $"WHERE `Ware ID` = {ID};",
                                                     conn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ware = new Wares(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(6), reader.GetFloat(10));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ware;
        }

        public Wares update(Wares entity)
        {
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("", conn);

                command.CommandText = $"Update Wares set `Name` = '{entity.Name}', " +
                                      $"Cost = {entity.Cost}, " +
                                      $"`Categoty ID` = {entity.CategoryID}, " +
                                      $"`Special Offer ID` = {entity.DiscountID} " +
                                      $"Where `Ware ID` = {entity.ID}";

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Wares newWare = getByID(entity.ID);

            return newWare;
        }
    }
}
