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
    /// Interaction logic for Medewerker.xaml
    /// </summary>
    public partial class Medewerker : Window, INotifyPropertyChanged
    {
        #region OnPropertyChanged
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        private PizzaDb _db = new PizzaDb();

        private Models.medewerker newMedewerker;
        public Models.medewerker NewMedewerker
        {
            get { return newMedewerker; }
            set { newMedewerker = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Models.medewerker> medewerker = new ObservableCollection<Models.medewerker>();
        public ObservableCollection<Models.medewerker> Medewerkers
        {
            get { return medewerker; }
            set { medewerker = value; }
        }


        public Medewerker()
        {
            InitializeComponent();
            LoadData();
            NewMedewerker = new Models.medewerker();
            DataContext = this;
        }
        private void LoadData()
        {
            medewerker.Clear();
            foreach (Models.medewerker last_name in _db.GetAllMedewerker())
            {
                medewerker.Add(last_name);

            }
            DateTime.Now.ToString("yyMMdd");
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(newMedewerker.first_name))
            {
                MessageBox.Show("Vul een naam voor de customer in");
                return;
            }
            if (!_db.InsertIntoMedewerker(NewMedewerker))
            {
                MessageBox.Show("Fout bij het toevoegen van een customer");
                return;
            };

            DialogResult = true;


            Close();
        }
    }
}
