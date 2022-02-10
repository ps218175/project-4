using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using StonksPizza.Models;

namespace TestProject_2022
{
    [TestClass]
    public class UnitTest1
    {
        private MySqlConnection conn = new MySqlConnection(
         ConfigurationManager.ConnectionStrings["PizzaCS"].ConnectionString
         );

        [TestMethod]
        public void TestMethod1()
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

            
        }
        [TestMethod]

        public void Check()

        {

             

          

        }
    }
}
