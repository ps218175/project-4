﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
                item.prijs = (string)row["prijs"];

                result.Add(item);
            }

            conn.Close();

            return result;
        }
    }
}