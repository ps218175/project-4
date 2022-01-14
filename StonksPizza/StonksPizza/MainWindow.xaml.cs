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

        private ObservableCollection<Models.pizza> pizza = new ObservableCollection<Models.pizza>();
        public ObservableCollection<Models.pizza> Pizza
        {
            get { return pizza; }
            set { pizza = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadData();

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

    }
}
