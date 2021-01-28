using CsvHelper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Day07Cars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Car> CarsList = new List<Car>();

        public Car carToSend;

        //file to save data
        string FileName = @"..\..\cars.txt";


        public MainWindow()
        {
            InitializeComponent();
            lstCars.ItemsSource = CarsList;

            try
            {
                LoadDataFromFile();
            }
            catch (DataInvalidException ex)
            {
                MessageBox.Show(ex.Message, "Import error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void LoadDataFromFile()
        {
            Car car1 = null; //car object
            string[] lines = null; //to store lines from file

            try
            {
                lines = System.IO.File.ReadAllLines(FileName);  //IO exception

                foreach (string line in lines)
                {
                    car1 = new Car(line);
                    CarsList.Add(car1);
                }
            }
            catch (FileNotFoundException ex)
            {
                //ignore it
            }
            catch (IOException ex)
            {
                throw new DataInvalidException(ex.Message);
            }
            catch (DataInvalidException ex)
            {
                throw new DataInvalidException(ex.Message);
            }

        }

        private void SaveDataToFile()
        {
            if (lstCars.Items.Count != 0)
            {
                try
                {
                    using (TextWriter tw = new StreamWriter(FileName))
                    {
                        foreach (Car car1 in CarsList)
                        {
                            tw.WriteLine(car1);
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error saving to file:  " + ex.Message, "Export error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            carToSend = null;
            AddEditDialog aeDialog = new AddEditDialog(carToSend);
            aeDialog.Owner = this;
            aeDialog.AssignResult += AddEditDlg_AssignResult;

            //show dialog
            bool? result = aeDialog.ShowDialog();
        }

        private void AddEditDlg_AssignResult(Car car)
        {
            int selectedIndex = lstCars.SelectedIndex;

            if (carToSend == null)
            {
                CarsList.Add(car);
                lstCars.Items.Refresh();
            }
            if (carToSend != null)
            {
                CarsList[selectedIndex] = car;
                lstCars.Items.Refresh();
            }
        }



        private void lstCars_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (lstCars.Items.Count == 0 || lstCars.SelectedIndex == -1)
                e.Handled = true; //do not open context menu
        }

        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete car:\n"
               + lstCars.SelectedValue, "Confirmation needed",
            MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                CarsList.RemoveAt(lstCars.SelectedIndex);
                lstCars.Items.Refresh();
            }
        }

        private void EditCar_Click(object sender, RoutedEventArgs e)
        {
            carToSend = (Car)lstCars.SelectedItem;
            AddEditDialog aeDialog1 = new AddEditDialog(carToSend);
            aeDialog1.Owner = this;

            aeDialog1.AssignResult += AddEditDlg_AssignResult;
            //show dialog
            bool? result = aeDialog1.ShowDialog();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveDataToFile();
        }

        private void FileExitButtonClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FileExportButtonClicked(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.Title = "Export to file";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (var writer = new StreamWriter(saveFileDialog.FileName))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.Configuration.Delimiter = ";";
                        csv.WriteRecords(CarsList);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error writing file: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
