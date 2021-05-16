using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
using Enum = System.Enum;

namespace CA3_S00209014_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Connect to Database
        CarRentals2Entities db = new CarRentals2Entities();

        public MainWindow()
        {
            InitializeComponent();
            var carSize = Enum.GetNames(typeof(CarTypes));
            cboxCarType.ItemsSource = carSize;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void lbxAvailableCars_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var query = from o in db.Cars
            //    where o.Size.Equals(typeof(carType))
            //    select o;
        }


        public enum CarTypes { Small, Medium, Large, All}
        private void cboxCarType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var query = from c in db.Cars
                orderby c.Make
                select c;

            // need to get selected as a string

            var selected = cboxCarType.SelectedItem as string;

            switch (selected)
            {
                case "All":
                    break;
                case "Small":
                    query = from c in db.Cars
                        where c.Size.Equals("Small")
                        orderby c.Make
                        select c;
                    break;
                case "Medium":
                    query = from c in db.Cars
                        where c.Size.Equals("Medium")
                        orderby c.Make
                        select c;
                    break;
                case "Large":
                    query = from c in db.Cars
                        where c.Size.Equals("Large")
                        orderby c.Make
                        select c;
                    break;
            }

            lbxAvailableCars.ItemsSource = query.ToList();

        }
    }
}
