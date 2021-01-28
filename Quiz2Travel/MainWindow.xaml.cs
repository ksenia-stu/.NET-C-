using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Quiz2Travel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //list to store trips
        static List<Trip> TripsList = new List<Trip>();

        //file to save data
        string FileName = @"..\..\trips.txt";

        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromFile();

            lstTrips.ItemsSource = TripsList;
        }

        private void LoadDataFromFile()
        {
            Trip trip = null; //trip object
            string[] lines = null; //to store lines from file

            try
            {
                lines = System.IO.File.ReadAllLines(FileName);  //IO exception

                foreach (string line in lines)
                {
                    trip = new Trip(line);
                    TripsList.Add(trip);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error loading data: " + ex.Message);
            }
            catch (DataInvalidException ex)
            {
                Console.WriteLine("Error loading data: " + ex.Message);
            }
        }

        private void SaveDataToFile()
        {
            if (lstTrips.Items.Count != 0)
            {
                try
                {
                    using (TextWriter tw = new StreamWriter(FileName))
                    {
                        foreach (Trip trip in TripsList)
                        {
                            tw.WriteLine(trip);
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error saving to file: " + ex.Message);
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveDataToFile();
        }

        private void SaveSelectedButtonClicked(object sender, RoutedEventArgs e)
        {
            if (lstTrips.Items.Count == 0)
            {
                MessageBox.Show("The list is empty, no items to be exported ", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (lstTrips.SelectedIndex == -1)
            {
                MessageBox.Show("First select items to be exported ", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            //selected values from list
            var selectedTrips = lstTrips.SelectedItems;

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Trip files (*.trips)|*.trip|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = "trips";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (TextWriter tw = new StreamWriter(saveFileDialog.FileName))
                    {

                        foreach (Trip t in selectedTrips)
                        {
                            tw.WriteLine(t);
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Export error:" + ex.Message, "Export error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                MessageBox.Show("File saved", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ClearInputs()
        {
            tbDestination.Text = "";
            tbName.Text = "";
            tbPassportNo.Text = "";
            dpDeparture.Text = "";
            dpReturn.Text = "";
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                string destination = tbDestination.Text;
                string name = tbName.Text;
                string passportNo = tbPassportNo.Text;

                if (dpDeparture.SelectedDate == null)
                {
                    MessageBox.Show("Select departure date first", "Action required", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                DateTime departure = (DateTime)(dpDeparture.SelectedDate ?? null);
                if (dpReturn.SelectedDate == null)
                {
                    MessageBox.Show("Select return date first", "Action required", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                DateTime retDate = (DateTime)(dpReturn.SelectedDate ?? null);

                Trip trip = new Trip(destination, name, passportNo, departure, retDate);
                TripsList.Add(trip);
                lstTrips.Items.Refresh();
                ClearInputs();
            }
            catch (DataInvalidException ex)
            {
                MessageBox.Show("Input Error : " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (lstTrips.Items.Count == 0)
            {
                MessageBox.Show("The list is empty, first add items", "Action required", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (lstTrips.SelectedIndex == -1)
            {
                MessageBox.Show("First select an item to delete", "Action required", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete record:\n"
                + lstTrips.SelectedValue, "Confirmation needed",
             MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                TripsList.RemoveAt(lstTrips.SelectedIndex);
                lstTrips.Items.Refresh();
                ClearInputs();
            }
        }

        private void UpdateButtonClicked(object sender, RoutedEventArgs e)
        {
            if (lstTrips.Items.Count == 0)
            {
                MessageBox.Show("The list is empty, first add items", "Action required", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (lstTrips.SelectedIndex == -1)
            {
                MessageBox.Show("First select an item to update", "Action required", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            Trip trip = TripsList[lstTrips.SelectedIndex];
            string destination = tbDestination.Text;
            string name = tbName.Text;
            string passportNo = tbPassportNo.Text;
            DateTime departure = (DateTime)(dpDeparture.SelectedDate ?? null);
            DateTime retDate = (DateTime)(dpReturn.SelectedDate ?? null);

            trip.Destination = destination;
            trip.Name = name;
            trip.PassportNo = passportNo;
            trip.Departure = departure;
            trip.Return = retDate;

            lstTrips.Items.Refresh();
            ClearInputs();
        }

        private void lstTrips_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstTrips.Items.Count != 0)
            {
                if (lstTrips.SelectedIndex != -1)
                {
                    Trip trip = (Trip)lstTrips.SelectedItem;
                    tbDestination.Text = trip.Destination;
                    tbName.Text = trip.Name;
                    tbPassportNo.Text = trip.PassportNo;
                    dpDeparture.Text = trip.Departure.ToString();
                    dpReturn.Text = trip.Return.ToString();
                }
            }
        }
    }
}
