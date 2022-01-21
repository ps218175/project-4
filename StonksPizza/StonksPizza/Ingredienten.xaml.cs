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
    /// Interaction logic for Ingredienten.xaml
    /// </summary>
    public partial class Ingredienten : Window
    {
        private PizzaDb _db = new PizzaDb();

        private Models.ingredienten updateIngredient;
        public Models.ingredienten UpdateIngredient
        {
            get { return updateIngredient; }
            set { updateIngredient = value; }
        }

        private Models.ingredienten newIngredient;
        public Models.ingredienten NewIngredient
        {
            get { return newIngredient; }
            set { newIngredient = value; }
        }

        private Models.ingredienten selectedIngredient;

        public Models.ingredienten SelectedIngredient
        {
            get { return selectedIngredient; }
            set
            {
                selectedIngredient = value;

            }
        }

        private ObservableCollection<Models.ingredienten> ingredienten = new ObservableCollection<Models.ingredienten>();
        public ObservableCollection<Models.ingredienten> Ingredient
        {
            get { return ingredienten; }
            set { ingredienten = value; }
        }

        public Ingredienten()
        {
            InitializeComponent();
            LoadData();
            UpdateIngredient = new Models.ingredienten();
            NewIngredient = new Models.ingredienten();
            DataContext = this;
        }
        private void LoadData()
        {
            ingredienten.Clear();
            foreach (Models.ingredienten naam in _db.GetAllIngredient())
            {
                ingredienten.Add(naam);

            }

        }

        private void lijstIngr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lijstIngr.SelectedItem == null)
            {
                return;
            }
            ingredienten updateIngredient = lijstIngr.SelectedItem as ingredienten;
            id.Text = selectedIngredient.id.ToString();
            naam.Text = selectedIngredient.naam.ToString();
            unit.Text = selectedIngredient.unit.ToString();
            prijs.Text = selectedIngredient.prijs.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIngredient.naam))
            {
                MessageBox.Show("Vul een naam voor de customer in");
                return;
            }
            if (!_db.UpdateIngredienten(selectedIngredient, UpdateIngredient))
            {
                MessageBox.Show("Fout bij het toevoegen van een customer");
                return;
            };

            DialogResult = true;


            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (selectedIngredient == null)
            {
                MessageBox.Show("Selecteer eerst een customer");
                return;
            }
            if (_db.DeleteIngredient(selectedIngredient.id))
            {
                ingredienten.Remove(selectedIngredient);

            }
            else
            {
                MessageBox.Show($"Het {selectedIngredient.naam} kon niet worden verwijderd.");
            }
            id.Text = "";
            naam.Text = "";
            unit.Text = "";
            prijs.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NewIngredient.naam))
            {
                MessageBox.Show("Vul een naam voor de customer in");
                return;
            }
            if (!_db.InsertIntoIngredient(NewIngredient))
            {
                MessageBox.Show("Fout bij het toevoegen van een customer");
                return;
            };

            DialogResult = true;


            Close();
        }
    }
}
