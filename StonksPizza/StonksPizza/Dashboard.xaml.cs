using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace StonksPizza
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {


        public Dashboard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Medewerker item = new Medewerker();

            item.ShowDialog();

           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow item = new MainWindow();

            item.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Ingredienten item = new Ingredienten();

            item.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Bestellingen item = new Bestellingen();

            item.ShowDialog();
        }

    }
}
