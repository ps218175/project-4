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

        //Get All
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
                item.unit = (int)row["unit"];
                item.prijs = (decimal)row["prijs"];

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

        //Insert
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
        public bool InsertIntoPizza(pizza newPizza)
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
INSERT INTO `pizza`(`id`, `naam`, `beschrijving`, `prijs`) VALUES (@id,@naam,@beschrijving,@prijs)";

                sql.Parameters.AddWithValue("@id", newPizza.id);
                sql.Parameters.AddWithValue("@naam", newPizza.naam);
                sql.Parameters.AddWithValue("@beschrijving", newPizza.beschrijving);
                sql.Parameters.AddWithValue("@prijs", newPizza.prijs);
                
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
        public bool InsertIntoIngredient(ingredienten newIngredient)
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
INSERT INTO `ingredienten`(`id`, `naam`, `unit`, `prijs`) VALUES (@id,@naam,@unit,@prijs)";

                sql.Parameters.AddWithValue("@id", newIngredient.id);
                sql.Parameters.AddWithValue("@naam", newIngredient.naam);
                sql.Parameters.AddWithValue("@unit", newIngredient.unit);
                sql.Parameters.AddWithValue("@prijs", newIngredient.prijs);

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
        //Update
        public bool UpdatePizza(pizza SelectedPizza, pizza UpdatePizza)
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
UPDATE `pizza` SET `id`=@id,`naam`=@naam,`beschrijving`=@beschrijving,`prijs`=@prijs WHERE `id` = @id";

                
                if (UpdatePizza.naam == null)
                {
                    UpdatePizza.naam = SelectedPizza.naam;
                }
                else
                {
                    UpdatePizza.naam = UpdatePizza.naam;
                }
                if (UpdatePizza.beschrijving == null)
                {
                    UpdatePizza.beschrijving = SelectedPizza.beschrijving;
                }
                else
                {
                    UpdatePizza.beschrijving = UpdatePizza.beschrijving;
                }
                if (UpdatePizza.prijs == null)
                {
                    UpdatePizza.prijs = SelectedPizza.prijs;
                }
                else
                {
                    UpdatePizza.prijs = UpdatePizza.prijs;
                }
                sql.Parameters.AddWithValue("@id", SelectedPizza.id);
                sql.Parameters.AddWithValue("@naam", UpdatePizza.naam);
                sql.Parameters.AddWithValue("@beschrijving", UpdatePizza.beschrijving);
                sql.Parameters.AddWithValue("@prijs", UpdatePizza.prijs);
               
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
        public bool UpdateIngredienten(ingredienten SelectedIngredient, ingredienten UpdateIngredient)
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
UPDATE `ingredienten` SET `id`=@id,`naam`=@naam,`unit`=@unit,`prijs`=@prijs WHERE `id` = @id";


                if (UpdateIngredient.naam == null)
                {
                    UpdateIngredient.naam = SelectedIngredient.naam;
                }
                else
                {
                    UpdateIngredient.naam = UpdateIngredient.naam;
                }
                if (UpdateIngredient.unit <= 0)
                {
                    UpdateIngredient.unit = SelectedIngredient.unit;
                }
                else
                {
                    UpdateIngredient.unit = UpdateIngredient.unit;
                }
                if (UpdateIngredient.prijs <= 0)
                {
                    UpdateIngredient.prijs = SelectedIngredient.prijs;
                }
                else
                {
                    UpdateIngredient.prijs = UpdateIngredient.prijs;
                }
                sql.Parameters.AddWithValue("@id", SelectedIngredient.id);
                sql.Parameters.AddWithValue("@naam", UpdateIngredient.naam);
                sql.Parameters.AddWithValue("@unit", UpdateIngredient.unit);
                sql.Parameters.AddWithValue("@prijs", UpdateIngredient.prijs);

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

        //Delete
        public bool DeletePizza(int id)
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
                    @"DELETE FROM pizza 
                       WHERE id = @id";

                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("***DeleteCustomer***");
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
        public bool DeleteIngredient(int id)
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
                    @"DELETE FROM ingredienten 
                       WHERE id = @id";

                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("***DeleteCustomer***");
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
