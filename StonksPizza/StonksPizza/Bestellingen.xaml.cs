using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Bestellingen.xaml
    /// </summary>
    public partial class Bestellingen : Window
    {
        private PizzaDb _db = new PizzaDb();
        private ObservableCollection<Models.bestelling> bestelling = new ObservableCollection<Models.bestelling>();
        public ObservableCollection<Models.bestelling> Bestelling
        {
            get { return bestelling; }
            set { bestelling = value; }
        }
        private Models.bestelling updateBestelling;
        public Models.bestelling UpdateBestelling
        {
            get { return updateBestelling; }
            set { updateBestelling = value; }
        }
        private Models.bestelling selectedBestelling;

        public Models.bestelling SelectedBestelling
        {
            get { return selectedBestelling; }
            set
            {
                selectedBestelling = value;

            }
        }

        public Bestellingen()
        {
            DataContext = this;
            LoadData();
            InitializeComponent();
            UpdateBestelling = new Models.bestelling();
        }
        private void LoadData()
        {
           
            foreach (Models.bestelling id in _db.GetAllBestellingen())
            {
                bestelling.Add(id);

            }
            
        }

        private void lijstbestelling_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lijstbestelling.SelectedItem == null)
            {
                return;
            }
            bestelling updateBestelling = lijstbestelling.SelectedItem as bestelling;
           
            Status_Id.Text = selectedBestelling.Status_Id.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Status_Id.SelectedIndex == 0)
            {
                UpdateBestelling.Status_Id = 1;
            }
            if (Status_Id.SelectedIndex == 1)
            {
                UpdateBestelling.Status_Id = 2;
            }
            if (Status_Id.SelectedIndex == 2)
            {
                UpdateBestelling.Status_Id = 3;

            }
            if (Status_Id.SelectedIndex == 3)
            {
                UpdateBestelling.Status_Id = 4;
            }
            if (string.IsNullOrEmpty(selectedBestelling.status))
            {
                MessageBox.Show("Vul een naam voor de customer in");
                return;
            }
            if (!_db.UpdateBestelling(selectedBestelling, updateBestelling))
            {
              
                MessageBox.Show("Fout bij het toevoegen van een customer");
                return;
            };

            DialogResult = true;


            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
