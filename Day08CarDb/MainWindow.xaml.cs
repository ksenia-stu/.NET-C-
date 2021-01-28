using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Day08CarDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //create an instance of Database class
        Database db;


        public MainWindow()
        {
            InitializeComponent();
            try
            {
                db = new Database(); // ex (fatal)
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error connection to database", "Database connection fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
            lstCars.ItemsSource = db.GetAllCars();
            
           
        }


       

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            Car car;
            AddEditDialog aeDialog = new AddEditDialog(null, db);
            aeDialog.Owner = this;
            aeDialog.ShowDialog();
            
        }

        private void EditCar_Click(object sender, RoutedEventArgs e)
        {
            Car car = (Car)lstCars.SelectedItem;
            AddEditDialog aeDialog = new AddEditDialog(car, db);
            aeDialog.Owner = this;
            aeDialog.ShowDialog();
            
        }

        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete car:\n"
               + lstCars.SelectedValue, "Confirmation needed",
            MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Car car = (Car)lstCars.SelectedItem;
                db.DeleteCar(car.Id);
                
            }
            lstCars.ItemsSource = db.GetAllCars();
        }

    }
}
