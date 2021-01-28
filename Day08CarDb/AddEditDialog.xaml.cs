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
using System.Windows.Shapes;

namespace Day08CarDb
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {

        Database database;
        Car receivedCar;

        public AddEditDialog(Car car, Database db)
        {
            database = db;
            InitializeComponent();
            receivedCar = car;
            comboFuelType.ItemsSource = Enum.GetValues(typeof(Car.FuelTypeEnum));

            if (receivedCar != null)
            {
                btAddEdit.Content = "Update";
                lblId.Content = receivedCar.Id;
                tbMakeModel.Text = receivedCar.MakeModel;
                sliderEngineSize.Value = receivedCar.EngineSize;
                comboFuelType.SelectedItem = receivedCar.FuelType;
            }

           
        }

        private void btAddEdit_Click(object sender, RoutedEventArgs e)
        {
            string makeModel = tbMakeModel.Text;

            double engineSize = sliderEngineSize.Value;

            Enum.TryParse(comboFuelType.SelectedItem.ToString(), out Car.FuelTypeEnum fuelType);

            try
            {
                if (receivedCar == null)
                {
                    database.AddCar(new Car(0, makeModel, engineSize, fuelType));
                }
                if(receivedCar != null)
                {
                    receivedCar.MakeModel = makeModel;
                    receivedCar.EngineSize = engineSize;
                    receivedCar.FuelType = fuelType;
                    database.UpdateCar(receivedCar);
                }
                DialogResult = true;
            }
            catch(DataInvalidException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
        }

        
    }
}
