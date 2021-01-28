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

namespace Quiz4EF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Utils.context = new PeopleDbContext();
                LoadRecords();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }

        public void LoadRecords()
        {
            try
            {
                lvPeople.ItemsSource = Utils.context.People.Include("Passport").ToList();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Database error: "+ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void miAddPerson_Click(object sender, RoutedEventArgs e)
        {
            DialogAddPerson addPeronDlg = new DialogAddPerson() { Owner = this };
            bool? result = addPeronDlg.ShowDialog();


            if (result == true)
            {
                LoadRecords();
            }
        }

        private void lvPeople_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(lvPeople.Items.Count != 0 && lvPeople.SelectedIndex != -1)
            {
                Person selectedPerson = (Person)lvPeople.SelectedItem;

                DialogPassport passportDlg = new DialogPassport(selectedPerson) { Owner = this };
                bool? result = passportDlg.ShowDialog();

                if (result == true)
                {
                    LoadRecords();
                }
            }
        }
    }
}
