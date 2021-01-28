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

namespace Day04IceCreamSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            // Bind data from List to lstFlavours    
            lstFlavours.ItemsSource = LoadFlavours();


        }

        //method to load flavours from List to lstFlavours
        private List<string> LoadFlavours()
        {
            List<string> flavours = new List<string>();
            flavours.Add("Vanilla");
            flavours.Add("Strawberry");
            flavours.Add("Peach");
            flavours.Add("Lemon");
            
            return flavours;
        }


        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            if(lstFlavours.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a flavour to add", "Selection required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            lstSelected.Items.Add(lstFlavours.SelectedItem);
            lstFlavours.SelectedIndex =-1;
           
            //if we add items to model im xaml
            //ListViewItem item = (ListViewItem) lstFlavours.SelectredValue;
            //lstSwelected.Items.Add(item.Content);
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (lstSelected.Items.Count == 0)
            {
                MessageBox.Show("The list is empty, first add flavours", "Action required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (lstSelected.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a flavour to delete", "Selection required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete this flavour: " + lstSelected.SelectedValue, "Action required", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                lstSelected.Items.RemoveAt(lstSelected.SelectedIndex);
            }
               
        }

        private void ClearButtonClicked(object sender, RoutedEventArgs e)
        {
            lstSelected.Items.Clear();
        }
    }
}
