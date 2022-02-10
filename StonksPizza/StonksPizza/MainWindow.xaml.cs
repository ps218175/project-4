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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PizzaDb _db = new PizzaDb();

        private Models.pizza updatePizza;
        public Models.pizza UpdatePizza
        {
            get { return updatePizza; }
            set { updatePizza = value;}
        }

        private Models.pizza newPizza;
        public Models.pizza NewPizza
        {
            get { return newPizza; }
            set { newPizza = value; }
        }

        private ObservableCollection<Models.pizza> pizza = new ObservableCollection<Models.pizza>();
        public ObservableCollection<Models.pizza> Pizza
        {
            get { return pizza; }
            set { pizza = value; }
        }
        private Models.pizza selectedPizza;

        public Models.pizza SelectedPizza
        {
            get { return selectedPizza; }
            set
            {
                selectedPizza = value;

            }
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            UpdatePizza = new Models.pizza();
            NewPizza = new Models.pizza();
            DataContext = this;
            
        }
        private void LoadData()
        {
            pizza.Clear();
            foreach (Models.pizza naam in _db.GetAllPizza())
            {
                pizza.Add(naam);

            }
           
        }

        private void lijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lijst.SelectedItem == null)
            {
                return;
            }
            pizza updatePizza = lijst.SelectedItem as pizza;
            id.Text = selectedPizza.id.ToString();
            naam.Text = selectedPizza.naam.ToString();
            beschrijving.Text = selectedPizza.beschrijving.ToString();
            prijs.Text = selectedPizza.prijs.ToString();
           
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedPizza.naam))
            {
                MessageBox.Show("Vul een naam voor de customer in");
                return;
            }
            if (!_db.UpdatePizza(SelectedPizza, UpdatePizza))
            {
                MessageBox.Show("Fout bij het toevoegen van een customer");
                return;
            };

            DialogResult = true;


            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NewPizza.naam))
            {
                MessageBox.Show("Vul een naam voor de customer in");
                return;
            }
            if (!_db.InsertIntoPizza(NewPizza))
            {
                MessageBox.Show("Fout bij het toevoegen van een customer");
                return;
            };

            DialogResult = true;


            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (selectedPizza == null)
            {
                MessageBox.Show("Selecteer eerst een customer");
                return;
            }
            if (_db.DeletePizza(selectedPizza.id))
            {
                pizza.Remove(SelectedPizza);

            }
            else
            {
                MessageBox.Show($"Het {selectedPizza.naam} kon niet worden verwijderd.");
            }
            id.Text = "";
            naam.Text = "";
            beschrijving.Text = "";
            prijs.Text = "";
        }
    }
}
