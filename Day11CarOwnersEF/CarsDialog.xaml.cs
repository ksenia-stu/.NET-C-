using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Day11CarOwnersEF
{
    /// <summary>
    /// Interaction logic for CarsDialog.xaml
    /// </summary>
    public partial class CarsDialog : Window
    {
        //context
        CarOwnerDbContext context;

        //owner received from main window
        Owner receivedOwner;

      //  public event Action<ICollection<Car>> AssignCarsToOwner;

        public CarsDialog(Owner owner)
        {
            receivedOwner = owner;
            InitializeComponent();
            context = new CarOwnerDbContext();
            lblOwnerName.Content = owner.Name;
            RefreshCarsClearFields();
        }

        private void RefreshCarsClearFields()
        {
            try
            {
                // List<Car> carsList = (from c in context.Cars where c.OwnerId == receivedOwner.Id select c).ToList<Car>();
                List<Car> carsList = receivedOwner.CarsInGarage.ToList<Car>();
                lstCars.ItemsSource = carsList;

                tbMakeModel.Text = "";
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btAddCar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string makeModel = tbMakeModel.Text;

                Car car = new Car { MakeModel = makeModel, OwnerId = receivedOwner.Id, Owner = receivedOwner };

                context.Cars.Add(car);
                context.SaveChanges();
                RefreshCarsClearFields();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Database operation failed: " + ex.Message);
            }
            
        }

        private void btUpdateCar_Click(object sender, RoutedEventArgs e)
        {
            Car car = (Car)lstCars.SelectedItem;

            try
            {
                car.MakeModel = tbMakeModel.Text;
                context.SaveChanges();
                RefreshCarsClearFields();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Database operation failed: " + ex.Message);
            }
        }

        private void btDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = (Car)lstCars.SelectedItem;
                
                    context.Cars.Remove(car);
                    context.SaveChanges();
                    RefreshCarsClearFields();
                
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Database operation failed: " + ex.Message);
            }
        }

        private void lstCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car car = (Car)lstCars.SelectedItem;

            lblCarId.Content = car.Id;
            tbMakeModel.Text = car.MakeModel;
        }

        private void btDone_Click(object sender, RoutedEventArgs e)
        {

           // AssignCarsToOwner?.Invoke((IList<Car>)lstCars.SelectedItems);
            DialogResult = true;
        }
    }
}
