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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Day04TempConverter
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

        private void ConvertTemp()
        {
            if (rbInputCelcius == null)
            { // UI not ready
                // Console.WriteLine("skipping");
                return;
            }
            // Console.WriteLine("Convert temp triggered");
            string inTempStr = tbInputTemp.Text;
            double inTemp;
            if (inTempStr == "")
            { // ignore
                tbOutputTemp.Text = "No value entered";
                return;
            }
            if (!double.TryParse(inTempStr, out inTemp))
            {
                MessageBox.Show("Input temperature must be a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Celcius
            if (rbInputCelcius.IsChecked == true)
            {
                if (rbOutputCelcius.IsChecked == true)
                {
                    tbOutputTemp.Text = string.Format("{0:0.00} ° C", inTemp);
                }
                else if (rbOutputFarenh.IsChecked == true)
                {
                    tbOutputTemp.Text = string.Format("{0:0.00} ° F", ((inTemp * 9 / 5) + 32));
                }
                else if (rbOutputKelvin.IsChecked == true)
                {
                    tbOutputTemp.Text = string.Format("{0:0.00} ° K", (inTemp + 273.15));
                }
                else
                {
                    tbOutputTemp.Text = "";
                }
            }

            //Farenheit
            if (rbInputFarenh.IsChecked == true)
            {
                if (rbOutputCelcius.IsChecked == true)
                {

                    tbOutputTemp.Text = string.Format("{0:0.00} ° C", ((inTemp - 32) * 5 / 9));
                }
                else if (rbOutputFarenh.IsChecked == true)
                {
                    tbOutputTemp.Text = string.Format("{0:0.00} ° F", inTemp);
                }
                else if (rbOutputKelvin.IsChecked == true)
                {

                    tbOutputTemp.Text = string.Format("{0:0.00} ° K", ((inTemp - 32) * 5 / 9 + 273.15));
                }
                else
                {
                    tbOutputTemp.Text = "";
                }
            }

            //Kelvin
            if (rbInputKelvin.IsChecked == true)
            {
                if (rbOutputCelcius.IsChecked == true)
                {

                    tbOutputTemp.Text = string.Format("{0:0.00} ° C", inTemp - 273.15);
                }
                else if (rbOutputFarenh.IsChecked == true)
                {
                    tbOutputTemp.Text = string.Format("{0:0.00} ° F", ((inTemp - 273.15) * 9 / 5 + 32));
                }
                else if (rbOutputKelvin.IsChecked == true)
                {

                    tbOutputTemp.Text = string.Format("{0:0.00} ° K", inTemp);
                }
                else
                {
                    tbOutputTemp.Text = "";
                }
            }
        }

        private void textChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            ConvertTemp();
        }

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            ConvertTemp();
        }
    }
}
