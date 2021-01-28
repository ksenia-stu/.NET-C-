using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace CatsDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;

        List<Cat> CatsList = new List<Cat>();

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                db = new Database();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(1);
            }
            RefreshList("Loaded from database");

        }

        public void RefreshList(string status)
        {
            try
            {
                if (db == null)
                {
                    return;
                }

                CatsList = db.GetAllCats();
                lstCats.ItemsSource = CatsList;
                lblStatus.Content = status;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearFields()
        {
            lblId.Content = "...";
            tbName.Text = "";
            sliderAge.Value = 10;
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            int age = (int)sliderAge.Value;
            Cat cat= null;
            int newId = 0;
            try
            {
                cat = new Cat(0, name, age);

               newId = db.AddCat(cat);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            ClearFields();
            RefreshList("Item added: "+ newId + ": "+ cat.Name + " is " + cat.Age + "y/o");
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if(lstCats.Items.Count == 0)
            {
                MessageBox.Show("List is empty, nothing to delete");
                return;
            }
            if (lstCats.SelectedIndex == -1)
            {
                MessageBox.Show("First select cat to delete");
                return;
            }
            Cat cat = null;
            try
            {
                cat = (Cat)lstCats.SelectedItem;

                db.DeleteCat(cat.Id);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            ClearFields();
            RefreshList("Item deleted: " + cat);
            ReloadOwners();
        }

        public void ReloadOwners()
        {
            List<Owner> owners = new List<Owner>();

            if (db == null)
            {
                return;
            }
            if (lstCats.SelectedIndex == -1)
            {
                lstOwners.ItemsSource = owners;
                return;
            }
            Cat cat = (Cat)lstCats.SelectedItem;
           
                try
                {
                    owners = db.GetAllOwnersWithCatId(cat.Id);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                lstOwners.ItemsSource = owners;
        }

        private void lstCats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cat cat = (Cat)lstCats.SelectedItem;

            if (lstCats.Items.Count != 0 && lstCats.SelectedIndex != -1)
            {
                lblId.Content = cat.Id;
                tbName.Text = cat.Name;
                sliderAge.Value = cat.Age;

                ReloadOwners();
            }
            
        }

        private void UpdateButtonClicked(object sender, RoutedEventArgs e)
        {

            if (lstCats.Items.Count == 0)
            {
                MessageBox.Show("List is empty, nothing to update");
                return;
            }
            if (lstCats.SelectedIndex == -1)
            {
                MessageBox.Show("First select cat to update");
                return;
            }
            Cat cat = null;
            try
            {
                cat = (Cat)lstCats.SelectedItem;
                cat.Name = tbName.Text;
                cat.Age = (int)sliderAge.Value;

                db.UpdateCat(cat);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            ClearFields();
            RefreshList("Item updated: "+ cat);

        }

        private void btAddOwner_Click(object sender, RoutedEventArgs e)
        {
            if (lstCats.Items.Count == 0)
            {
                MessageBox.Show("There are no cats to add owner to");
                return;
            }
            if (lstCats.SelectedIndex == -1)
            {
                MessageBox.Show("First select cat to add owner");
                return;
            }
            Cat cat = (Cat)lstCats.SelectedItem;

            string fullName = tbFullName.Text;
            int catId = cat.Id;

            Owner owner = null;
           
            try
            {
                owner = new Owner(0, fullName, catId);

                db.AddOwner(owner);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            tbFullName.Text = "";
            ReloadOwners();
        }

        private void btUpdateOwner_Click(object sender, RoutedEventArgs e)
        {

            if (lstOwners.Items.Count == 0)
            {
                MessageBox.Show("List is empty, nothing to update");
                return;
            }
            if (lstCats.SelectedIndex == -1)
            {
                MessageBox.Show("First select owner to update");
                return;
            }
            Owner owner = null;
            try
            {
                owner = (Owner)lstOwners.SelectedItem;
                owner.FullName = tbFullName.Text;

                db.UpdateOwner(owner);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            tbFullName.Text = "";
            ReloadOwners();

        }

        private void lstOwners_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstOwners.Items.Count != 0 && lstOwners.SelectedIndex != -1)
            {
                Owner owner = (Owner)lstOwners.SelectedItem;

                tbFullName.Text = owner.FullName;
            }
        }

        private void btDeleteOwner_Click(object sender, RoutedEventArgs e)
        {
            if (lstOwners.Items.Count == 0)
            {
                MessageBox.Show("List is empty, nothing to delete");
                return;
            }
            if (lstOwners.SelectedIndex == -1)
            {
                MessageBox.Show("First select owner to delete");
                return;
            }
            Owner owner = null;
            try
            {
                owner = (Owner)lstOwners.SelectedItem;

                db.DeleteOwner(owner.Id);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            tbFullName.Text = "";
            ReloadOwners();
        }
    }
}
