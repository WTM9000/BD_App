using DB_Optics_core.Data;
using DB_Optics_core.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD_Optics_Ifrastructure.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        protected string connString { get; set; }

        public WarehouseRepository()
        {
            connString = "server=127.0.0.1;uid=root;pwd=M4SOPMODIIJr;database=optics";
        }

        public Warehouse add(Warehouse entity)
        {
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("", conn);

                command.CommandText = $"INSERT INTO `Warehouse` (`Adress`, `Space`) VALUES ('{entity.Address}', " +
                                      $"{entity.Space}); ";

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

            Warehouse newWarehouse = getByID(entity.ID);

            return newWarehouse;
        }

        public void delete(int ID)
        {
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("", conn);

                command.CommandText = $"Delete from warehouse where `Warehouse ID` = {ID}";

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Warehouse[] getAll()
        {
            var warehouses = new List<Warehouse>();
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("SELECT * FROM Warehouse;",
                                                     conn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    warehouses.Add(new Warehouse(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return warehouses.ToArray();
        }

        public Warehouse getByID(int ID)
        {
            Warehouse warehouse = null;
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand($"SELECT * FROM warehouse where `Warehouse ID` = {ID} ",
                                                     conn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    warehouse = new Warehouse(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return warehouse;
        }

        public Warehouse update(Warehouse entity)
        {
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("", conn);

                command.CommandText = $"Update warehouse set `Adress` = '{entity.Address}', " +
                                      $"`Space` = {entity.Space}" +
                                      $"Where `Category ID` = {entity.ID}";

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Warehouse newWarehouse = getByID(entity.ID);

            return newWarehouse;
        }
    }
}
