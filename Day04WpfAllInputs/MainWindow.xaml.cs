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

namespace Day04WpfAllInputs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearFields()
        {
            tbName.Text = "";
            rbAgeBelow18.IsChecked = true;
            rbAge1835.IsChecked = false;
            rbAge36Up.IsChecked = false;
            cbPetsCat.IsChecked = false;
            cbPetsDog.IsChecked = false;
            cbPetsOther.IsChecked = false;
            comboContinent.SelectedIndex = 0;
            sliderTemp.Value = 20;
            lblTemp.Content = 20;
        }

        private void btRegister_Click(object sender, RoutedEventArgs e)
        {
            //name
            string name = tbName.Text;
            if (name.Length == 0)
            {
                MessageBox.Show("Name must not be empty", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //age
            string age;

            if (rbAgeBelow18.IsChecked == true)
            {
                age = "below 18";
            }
            else if (rbAge1835.IsChecked == true)
            {
                age = "18-35";
            }
            else if (rbAge36Up.IsChecked == true)
            {
                age = "36 and up";
            }
            else
            {
                MessageBox.Show("Select age", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //pets
            List<string> PetsList = new List<string>();

            if (cbPetsCat.IsChecked == true)
            {
                PetsList.Add("cat");
            }
            if (cbPetsDog.IsChecked == true)
            {
                PetsList.Add("dog");
            }
            if (cbPetsOther.IsChecked == true)
            {
                PetsList.Add("other");
            }

            string pets = string.Join(",", PetsList);


            //continent
            string continent = comboContinent.Text;

            //temperature
            double temperature = sliderTemp.Value;
            if (temperature < 15 || temperature > 35)
            {
                MessageBox.Show("Temperature must be between 15 and 35", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //save to file (append)
            try
            {
                using (StreamWriter fileOutput = File.AppendText("inputs.txt"))
                {

                    string line = string.Format("{0};{1};{2};{3};{4:0}", name, age, pets, continent, temperature);
                    fileOutput.WriteLine(line);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error writing to file:" + ex.Message, "Output error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("You are registered","Success", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
            ClearFields();

        }
    }
}
