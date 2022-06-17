using DB_Optics_core.Data;
using DB_Optics_core.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace BD_Optics_Ifrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        protected string connString { get; set; }

        public CategoryRepository()
        {
            connString = "server=127.0.0.1;uid=root;pwd=M4SOPMODIIJr;database=optics";
        }
        public Category add(Category entity)
        {
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("", conn);

                command.CommandText = $"INSERT INTO `Category` (`Name`) VALUES ('{entity.Name}'); ";

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

            Category newCategory = getByID(entity.ID);

            return newCategory;
        }

        public void delete(int ID)
        {
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("", conn);

                command.CommandText = $"Delete from category where `Category ID` = {ID}";

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Category[] getAll()
        {
            var categories = new List<Category>();
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("SELECT * FROM Category;",
                                                     conn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new Category(reader.GetInt32(0), reader.GetString(1)));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return categories.ToArray();
        }

        public Category getByID(int ID)
        {
            Category category = null;
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand($"SELECT * FROM Category where `Category ID` = {ID} ",
                                                     conn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    category = new Category(reader.GetInt32(0), reader.GetString(1));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return category;
        }

        public Category update(Category entity)
        {
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("", conn);

                command.CommandText = $"Update category set `Name` = '{entity.Name}', " +
                                      $"Where `Category ID` = {entity.ID}";

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Category newCategory = getByID(entity.ID);

            return newCategory;
        }
    }
}
