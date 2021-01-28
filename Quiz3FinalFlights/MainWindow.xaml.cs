using CsvHelper;
using CsvHelper.TypeConversion;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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

namespace Quiz3FinalFlights
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //list to store flights
        public List<Flight> flightsList = new List<Flight>();
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Globals.db = new Database();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Fatal database error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
            refreshFlights();
        }

        private void refreshFlights()
        {
            try
            {
                if (Globals.db == null)
                {
                    return; 
                }
                flightsList = Globals.db.GetAllFlights(); 
                lstFlights.ItemsSource = flightsList;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: "+ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            AddEditDialog dlg = new AddEditDialog(null);
            dlg.Owner = this;
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                refreshFlights();
            }
        }

        private void lstFlights_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstFlights.Items.Count != 0 && lstFlights.SelectedIndex != -1)
            {
                Flight flight = (Flight)lstFlights.SelectedItem;
                AddEditDialog dlg = new AddEditDialog(flight);
                dlg.Owner = this;
                bool? result = dlg.ShowDialog();
                if (result == true)
                {
                    refreshFlights();
                }
            }
        }

        private void lstFlights_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (lstFlights.Items.Count == 0 || lstFlights.SelectedIndex == -1)
                e.Handled = true; //do not open context menu
        }

        private void DeleteFlight_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete flight:\n"
               + lstFlights.SelectedValue, "Confirmation needed",
            MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Flight flight = (Flight)lstFlights.SelectedItem;
                Globals.db.DeleteFlight(flight.Id);

            }
            refreshFlights();
        }

        private void FileSaveSelectedButtonClicked(object sender, RoutedEventArgs e)
        {
            if (lstFlights.Items.Count != 0 && lstFlights.SelectedIndex != -1)
            {
                //selected flights
                var selectedFlights = lstFlights.SelectedItems;

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV file (*.csv)|*.csv";
                saveDialog.Title = "Export to file";
                if (saveDialog.ShowDialog() == true)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                        using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csv.Configuration.Delimiter = ";";
                            var options = new TypeConverterOptions { Formats = new[] { "dd-MM-yyyy" } };
                            csv.Configuration.TypeConverterOptionsCache.AddOptions<DateTime>(options);
                            csv.WriteRecords(selectedFlights);
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Error exporting to csv: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void FileExitButtonClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
