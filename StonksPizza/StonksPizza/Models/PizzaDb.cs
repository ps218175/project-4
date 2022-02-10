using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.Security.Cryptography;

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
            sql.CommandText = "SELECT * from pizzas";
            MySqlDataReader reader = sql.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                pizza item = new pizza();
                item.id = (ulong)row["id"];
                item.naam = (string)row["name"];
                item.beschrijving = (string)row["description"];
                item.prijs = (decimal)row["amount"];
                

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
            sql.CommandText = "SELECT * FROM `ingredients`";
            MySqlDataReader reader = sql.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                ingredienten item = new ingredienten();
                item.id = (ulong)row["id"];
                item.naam_ingr = (string)row["naam_ingr"];
                item.unit = (int)row["unit"];
                item.prijs_ingr = (decimal)row["prijs_ingr"];

                result.Add(item);
            }

            conn.Close();

            return result;
        }
        public List<bestelling> GetAllBestellingen()
        {
            List<bestelling> result = new List<bestelling>();

            conn.Open();
            MySqlCommand sql = conn.CreateCommand();
            sql.CommandText = "SELECT * from bestelling inner join status on bestelling.status_id = status.id INNER JOIN customers ON bestelling.klant_id = customers.id";
            MySqlDataReader reader = sql.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                bestelling item = new bestelling();
                item.id = (int)row["id"];
                item.Status_Id = (int)row["Status_Id"];
                item.Bestel_Id = (int)row["Bestel_Id"];
                item.status = (string)row["status"];
                item.KlantId = (int)row["klant_id"];
                item.last_name = (string)row["last_name"];
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
INSERT INTO `pizzas`(`id`, `name`, `description`, `amount`) VALUES (@id,@naam,@beschrijving,@prijs)";

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
INSERT INTO `ingredients`(`id`, `naam_ingr`, `unit`, `prijs_ingr`) VALUES (@id,@naam,@unit,@prijs)";

                sql.Parameters.AddWithValue("@id", newIngredient.id);
                sql.Parameters.AddWithValue("@naam", newIngredient.naam_ingr);
                sql.Parameters.AddWithValue("@unit", newIngredient.unit);
                sql.Parameters.AddWithValue("@prijs", newIngredient.prijs_ingr);

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
UPDATE `pizzas` SET `id`=@id,`name`=@naam,`description`=@beschrijving,`amount`=@prijs WHERE `id` = @id";


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
UPDATE `ingredients` SET `id`=@id,`naam_ingr`=@naam,`unit`=@unit,`prijs_ingr`=@prijs WHERE `id` = @id";


                if (UpdateIngredient.naam_ingr == null)
                {
                    UpdateIngredient.naam_ingr = SelectedIngredient.naam_ingr;
                }
                else
                {
                    UpdateIngredient.naam_ingr = UpdateIngredient.naam_ingr;
                }
                if (UpdateIngredient.unit <= 0)
                {
                    UpdateIngredient.unit = SelectedIngredient.unit;
                }
                else
                {
                    UpdateIngredient.unit = UpdateIngredient.unit;
                }
                if (UpdateIngredient.prijs_ingr <= 0)
                {
                    UpdateIngredient.prijs_ingr = SelectedIngredient.prijs_ingr;
                }
                else
                {
                    UpdateIngredient.prijs_ingr = UpdateIngredient.prijs_ingr;
                }
                sql.Parameters.AddWithValue("@id", SelectedIngredient.id);
                sql.Parameters.AddWithValue("@naam", UpdateIngredient.naam_ingr);
                sql.Parameters.AddWithValue("@unit", UpdateIngredient.unit);
                sql.Parameters.AddWithValue("@prijs", UpdateIngredient.prijs_ingr);

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

        public bool UpdateBestelling(bestelling SelectedBestelling, bestelling UpdateBestelling)
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
UPDATE `bestelling` SET `id`=@id,`klant_id`=@KlantId,`Bestel_Id`=@Bestel_Id,`Status_Id`=@Status_Id WHERE `id` = @id";



                if (UpdateBestelling.Status_Id <= 0)
                {
                    UpdateBestelling.Status_Id = SelectedBestelling.Status_Id;
                }
                else
                {
                    UpdateBestelling.Status_Id = UpdateBestelling.Status_Id;
                }
                sql.Parameters.AddWithValue("@id", SelectedBestelling.id);
                sql.Parameters.AddWithValue("@KlantId", SelectedBestelling.KlantId);
                sql.Parameters.AddWithValue("@Bestel_Id", SelectedBestelling.Bestel_Id);
                sql.Parameters.AddWithValue("@Status_Id", UpdateBestelling.Status_Id);

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
        public bool DeletePizza(ulong id)
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
                    @"DELETE FROM pizzas 
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
        public bool DeleteIngredient(ulong id)
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
                    @"DELETE FROM ingredients 
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
