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

namespace Quiz4EF
{
    /// <summary>
    /// Interaction logic for DialogAddPerson.xaml
    /// </summary>
    public partial class DialogAddPerson : Window
    {
        public DialogAddPerson()
        {
            InitializeComponent();
        }

        private bool VerifyFields()
        {
           
            if (tbName.Text.Length < 1 || tbName.Text.Length > 25)
            {
                MessageBox.Show("Name length must be 1 to 25 characters");
                return false;
            }
            int age = 0;
            try
            {
                int.TryParse(tbAge.Text, out age);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Age must be a number");
                return false;
            }
            if (age < 0 || age > 120)
            {
                MessageBox.Show("Age must be between 0 and 120");
                return false;
            }

            return true;
        }

        private void btAddClicked(object sender, RoutedEventArgs e)
        {
            if (!VerifyFields()) { return; }
            try
            {
                Person person = new Person { Name = tbName.Text, Age = int.Parse(tbAge.Text),};
                Utils.context.People.Add(person);
                Utils.context.SaveChanges();
                tbName.Text = "";
                tbAge.Text = "";
                DialogResult = true;
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Database error: "+ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
