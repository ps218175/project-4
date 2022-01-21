using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
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
        MySqlConnection con = new MySqlConnection();
        public Login()
        {
            InitializeComponent();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user=root;database=Pizza;";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sTUDENTDataSet.login' table. You can move, or remove it, as needed.  
            //this.loginTableAdapter.Fill(this.sTUDENTDataSet.login);  
            MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=Pizza;");
            con.Open();

            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user=root;database=Pizza;";
            con.Open();
            string userid = textBox1.Text;
            string password = textBox2.Text;
            MySqlCommand cmd = new MySqlCommand("select email,name from users where email='" + textBox1.Text + "'and name='" + textBox2.Text + "'", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                Dashboard signIn = new Dashboard();
                signIn.ShowDialog();
                this.Show();



            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();
        }

        
    }
}
