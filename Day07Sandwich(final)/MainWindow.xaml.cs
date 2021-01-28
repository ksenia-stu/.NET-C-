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

namespace Day07Sandwich_final_
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

        //we can create separate method INSTEAD OF LAMBDA
        private void CustDlg_AssignResult(string bread, string veg, string meat)
        {
            lblBread.Content = bread;
            lblVeggies.Content = veg;
            lblMeat.Content = meat;
        }

        private void MakeSandwichButtonClicked(object sender, RoutedEventArgs e)
        {
          /*  string breadVal = "";
            string veggiesVal = "";
            string meatVal = ""; */

            CustomDialog cd = new CustomDialog();
            cd.Owner = this;
            // cd.AssignResult += (b, v, m) => { breadVal = b; veggiesVal = v; meatVal = m; };
            cd.AssignResult += CustDlg_AssignResult; //alternative to lambda

            bool? result = cd.ShowDialog();  // cd.ShowDialog() not null then show it and save result to bool(true/false)

         /*   if(result == true)
            {
                lblBread.Content = breadVal;
                lblVeggies.Content = veggiesVal;
                lblMeat.Content = meatVal;
            } */
        }
    }
}
