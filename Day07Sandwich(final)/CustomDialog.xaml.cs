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

namespace Day07Sandwich_final_
{
    /// <summary>
    /// Interaction logic for CustomDialog.xaml
    /// </summary>
    public partial class CustomDialog : Window
    {
        public event Action<string, string, string> AssignResult;

        public CustomDialog()
        {
            InitializeComponent();
        }

        private void SaveButtonClicked(object sender, RoutedEventArgs e)
        {
            //bread
            string bread = comboBread.Text;
            
            //veggies
            List<string> veggies = new List<string>();
            if(cbVegLettuce.IsChecked == true)
            {
                veggies.Add("Lettuce");
            }
            if (cbVegTomatoes.IsChecked == true)
            {
                veggies.Add("Tomatoes");
            }
            if (cbVegCucubmers.IsChecked == true)
            {
                veggies.Add("Cucumbers");
            }

            string vegs = string.Join(",", veggies);

            //meat
            string meat = "";
            if (rbMeatChicken.IsChecked == true)
            {
                meat = "Chicken";
            }
            else if (rbMeatTurkey.IsChecked == true)
            {
                meat = "Turkey";
            }
            else if (rbMeatTofu.IsChecked == true)
            {
                meat = "Tofu";
            }
            else
            {
                MessageBox.Show("Please choose meat", "Action required", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            AssignResult?.Invoke(bread, vegs, meat);
         /*   if (AssignResult != null)
            {
                AssignResult.Invoke(bread, vegs, meat);
            } */
            DialogResult = true;
        }
    }
}
