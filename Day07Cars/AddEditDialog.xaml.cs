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

namespace Day07Cars
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {
        public event Action<Car> AssignResult;

        //field Car
        Car car;

        public AddEditDialog(Car car)
        {
            this.car = car;  //NOT TO USE this (change variable name)
            InitializeComponent();
            comboFuelType.ItemsSource = Enum.GetValues(typeof(FuelTypeEnum));
            if (car != null)
            {
                btAddEdit.Content = "Update";
                tbMakeModel.Text = car.MakeModel;
                sliderEngineSize.Value = car.EngineSize;
                comboFuelType.SelectedItem = car.FuelType;
            }
            
        }

        private void CreateUpdateButtonClicked(object sender, RoutedEventArgs e)
        {
            string makeModel = tbMakeModel.Text;

            double engineSize = sliderEngineSize.Value;

            Enum.TryParse(comboFuelType.SelectedItem.ToString(), out FuelTypeEnum fuelType);

        try
            {
                if (car == null) //create
                {
                    car = new Car(makeModel, engineSize, fuelType);
                }
                if (car != null)  //update
                {
                    car.MakeModel = tbMakeModel.Text;
                    car.EngineSize = sliderEngineSize.Value;
                    Enum.TryParse(comboFuelType.SelectedItem.ToString(), out FuelTypeEnum fuelT);
                    car.FuelType = fuelT;
                }
            }
            catch (DataInvalidException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            AssignResult?.Invoke(car);
            DialogResult = true;
        }
    }
}
