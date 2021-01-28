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

namespace Quiz3FinalFlights
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {
        //flight from main window
        Flight receivedFlight;
        public AddEditDialog(Flight flight)
        {
            receivedFlight = flight;
            InitializeComponent();
            comboType.ItemsSource = Enum.GetValues(typeof(Flight.TypeEnum));
            if (receivedFlight != null)
            {
                btCreateEdit.Content = "Update";
                lblId.Content = receivedFlight.Id;
                dpDate.SelectedDate = receivedFlight.Date;
                tbFromCode.Text = receivedFlight.FromCode;
                tbToCode.Text = receivedFlight.ToCode;
                comboType.SelectedItem = receivedFlight.Type;
                sliderPassengers.Value = flight.Passengers;
            }
        }

        private void btCreateEdit_Click(object sender, RoutedEventArgs e)
        {
            DateTime.TryParse(dpDate.Text,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime date);
            if (date == null)
            {
                MessageBox.Show("Choose a date ", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string fromCode = tbFromCode.Text;
            string toCode = tbToCode.Text;
            Enum.TryParse(comboType.SelectedItem.ToString(), out Flight.TypeEnum type);
            int passengers = (int)sliderPassengers.Value;

            try
            {
                if (receivedFlight == null)
                {
                    Globals.db.AddFlight(new Flight(0, date, fromCode, toCode, type, passengers));
                }
                if (receivedFlight != null)
                {
                    receivedFlight.Date = date;
                    receivedFlight.FromCode = fromCode;
                    receivedFlight.ToCode = toCode;
                    receivedFlight.Type = type;
                    receivedFlight.Passengers = passengers;
                    Globals.db.UpdateFlight(receivedFlight);
                }
                DialogResult = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
