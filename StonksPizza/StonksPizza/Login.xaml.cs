using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using StonksPizza.Models;
namespace StonksPizza
{

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private string salt;
        private string hash;
        private MySqlConnection conn = new MySqlConnection(
         ConfigurationManager.ConnectionStrings["PizzaCS"].ConnectionString
         );

        public Login()
        {
            InitializeComponent();
           

            DataContext = this;
        }
       

        private void LoginPass()
        {
            try
            {





                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "" +
                    @"SELECT u.id, u.name, u.email, u.password FROM users u  WHERE u.password = @password";
                command.Parameters.AddWithValue("@name", txtname.Text);
                command.Parameters.AddWithValue("@password", Password.Text);
                MySqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);


                if (table.Rows.Count > 0)
                {

                    this.Hide();
                    Dashboard signIn = new Dashboard();
                    signIn.ShowDialog();
                    this.Show();




                }




            }
            catch (Exception)
            {

                MessageBox.Show("");
                return;
            }
            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginPass();



        }




    }
}
