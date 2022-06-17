using DB_Optics_core.Data;
using DB_Optics_core.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD_Optics_Ifrastructure.Repositories
{
    public class AnalyticalStuff : IAnalyticalStuff
    {

        protected string connString { get; set; }

        public AnalyticalStuff()
        {
            connString = "server=127.0.0.1;uid=root;pwd=M4SOPMODIIJr;database=optics";
        }

        public Special_Offer_list[] AvalibleOffers(int startDate, int EndDate)
        {
            var Offers = new List<Special_Offer_list> ();
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("select `Special offer ID`, Discount from `special offer`" +
                                                     $"where(`Start date` > {startDate} and `Start date` < {EndDate}) and " +
                                                     $"(`End date` > {startDate} and `End date` < {EndDate}); ", conn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Offers.Add(new Special_Offer_list(reader.GetInt32(0), reader.GetFloat(1)));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Offers.ToArray();
        }

        public float AverSalary()
        {
            float result = -1;
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("select avg(Salary) from employees;", conn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetFloat(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public Category[] SaleRating()
        {
            var categories = new List<Category>();
            try
            {
                using var conn = new MySqlConnection();

                conn.ConnectionString = connString;

                conn.Open();

                using var command = new MySqlCommand("select" + 
                                                         "category.`Category ID`, Category.`Name`, sum(Quanity)" +
                                                     "from" +
                                                         "Category" +
                                                             "left join" +
                                                         "Wares on Category.`Category ID` = Wares.`Categoty ID`" +
                                                             "left join" +
	                                                     "`Ware - order` on Wares.`Ware ID`=`Ware - order`.`Ware ID`" +
                                                     "group by Category.`Name`" +
                                                     "order by sum(Quanity) desc; ", conn);

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
    }
}
