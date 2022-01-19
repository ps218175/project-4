using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace StonksPizza.Models
{
    class PizzaDb
    {
        private MySqlConnection conn = new MySqlConnection(
          ConfigurationManager.ConnectionStrings["PizzaCS"].ConnectionString
          );

        public List<pizza> GetAllPizza()
        {
            List<pizza> result = new List<pizza>();

            conn.Open();
            MySqlCommand sql = conn.CreateCommand();
            sql.CommandText = "SELECT * FROM `pizza`";
            MySqlDataReader reader = sql.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                pizza item = new pizza();
                item.id = (int)row["id"];
                item.naam = (string)row["naam"];
                item.beschrijving = (string)row["beschrijving"];
                item.prijs = (string)row["prijs"];

                result.Add(item);
            }

            conn.Close();

            return result;
        }
        public List<ingredienten> GetAllIngredient()
        {
            List<ingredienten> result = new List<ingredienten>();

            conn.Open();
            MySqlCommand sql = conn.CreateCommand();
            sql.CommandText = "SELECT * FROM `ingredienten`";
            MySqlDataReader reader = sql.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                ingredienten item = new ingredienten();
                item.id = (int)row["id"];
                item.naam = (string)row["naam"];
               
                item.prijs = (int)row["prijs"];

                result.Add(item);
            }

            conn.Close();

            return result;
        }
        public List<medewerker> GetAllMedewerker()
        {
            List<medewerker> result = new List<medewerker>();

            conn.Open();
            MySqlCommand sql = conn.CreateCommand();
            sql.CommandText = "SELECT * FROM `employees`";
            MySqlDataReader reader = sql.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                medewerker item = new medewerker();
                item.id = (int)row["id"];
                item.last_name = (string)row["last_name"];

                item.city = (string)row["city"];

                result.Add(item);
            }

            conn.Close();

            return result;
        }

        public bool InsertIntoMedewerker(medewerker newMedewerker)
        {
            bool result = true;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                MySqlCommand sql = conn.CreateCommand();
                sql.CommandText =
                    @"
INSERT INTO `employees`(`id`, `first_name`, `last_name`, `address`, `phone`, `zipcode`, `city`, `country`, `personal_email`, `birth_date`, `burger_service_nummer`) VALUES (@id, @first_name, @last_name, @address, @phone, @zipcode, @city, @country, @personal_email,@birth_date,@burger_service_nummer)";

                sql.Parameters.AddWithValue("@id", newMedewerker.id);
                sql.Parameters.AddWithValue("@first_name", newMedewerker.first_name);
                sql.Parameters.AddWithValue("@last_name", newMedewerker.last_name);
                sql.Parameters.AddWithValue("@address", newMedewerker.address);
                sql.Parameters.AddWithValue("@phone", newMedewerker.phone);
                sql.Parameters.AddWithValue("@zipcode", newMedewerker.zipcode);
                sql.Parameters.AddWithValue("@city", newMedewerker.city);
                sql.Parameters.AddWithValue("@country", newMedewerker.country);
                sql.Parameters.AddWithValue("@personal_email", newMedewerker.personal_email);
                sql.Parameters.AddWithValue("@birth_date", newMedewerker.birth_date);

                sql.Parameters.AddWithValue("@burger_service_nummer", newMedewerker.burger_service_nummer);
                sql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("***InsertIntoCountry***");
                Console.WriteLine(e.Message);
                result = false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }
    }
}
