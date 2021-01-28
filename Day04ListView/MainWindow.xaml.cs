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

namespace Day04ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Person> people = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void LoadPeopleFromList()
        {
            foreach (Person p in people)
            {
                lstPeople.Items.Add(p);
            }
        }

        private void ClearInputs()
        {
            tbName.Text = "";
            sliderAge.Value = 20;
        }

        private Person CreateUpdatePersonFromInputs(Person p)
        {
            //name 
            string name = tbName.Text;

        /*    if (name.Length == 0)
            {
                throw new ArgumentException ("Name must not be empty");
              //  MessageBox.Show("Name must not be empty", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
               // return;
            }  */

            //age
            int age = Convert.ToInt32(sliderAge.Value);

            if(p ==null)
            {
                //create object person
                Person person1 = null;
                try
                {
                    person1 = new Person(name, age);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                  
                }
                return person1;   
            }      
                p.Name = name;
                p.Age = age;
                return p;  
        } 
        

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            Person person=null;
           
            person = CreateUpdatePersonFromInputs(null);
            
           
            people.Add(person);
            lstPeople.Items.Clear();
            LoadPeopleFromList();
            ClearInputs();

        }

        private void lstPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = lstPeople.SelectedIndex;

            if(selectedIndex == -1)
            {
                tbName.Text = "";
                sliderAge.Value = 20;

            }
            else
            {
                Person person = (Person)lstPeople.SelectedItem;
                tbName.Text = person.Name;
                sliderAge.Value = person.Age;
            }
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if(lstPeople.Items.Count == 0)
            {
                MessageBox.Show("First add people to list, it is empty","Action required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (lstPeople.SelectedIndex == -1)
            {
                MessageBox.Show("Please select person to delete", "Action required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete this person:\n " + lstPeople.SelectedValue, "Action required", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                people.RemoveAt(lstPeople.SelectedIndex);
                lstPeople.Items.Clear();
                LoadPeopleFromList();
            }
        }

        private void UpdateButtonClicked(object sender, RoutedEventArgs e)
        {
            if (lstPeople.Items.Count == 0)
            {               
                 MessageBox.Show("First add people to list, it is empty", "Action required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (lstPeople.SelectedIndex == -1)
            { 
                MessageBox.Show("Please select person to update", "Action required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            people[lstPeople.SelectedIndex] = CreateUpdatePersonFromInputs((Person)lstPeople.SelectedItem);
            
            
            lstPeople.Items.Clear();
            LoadPeopleFromList();

        }
    }
}
