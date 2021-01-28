using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace Day11CarOwnersEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //context
        CarOwnerDbContext context;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                context = new CarOwnerDbContext();
                RefreshOwnersClearFields();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Fatal error connecting to database:\n" + ex.Message);
                Environment.Exit(1);
            }
        }

        private void RefreshOwnersClearFields()
        {
            try
            {

                lstOwners.ItemsSource = context.Owners.Include("CarsInGarage").ToList();
                tbName.Text = "";
                btPhoto.Content = "Click to pick picture";
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private bool VerifyFields()
        {
            List<String> errorsList = new List<string>();
            if (tbName.Text.Length < 2 || tbName.Text.Length > 100)
            {
                errorsList.Add("Owner's name length must be 1 to 100 characters");
            }
       
            if (btPhoto.Content == null)
            {
                errorsList.Add("Photo must be selected");
            }
            
            if (errorsList.Count != 0)
            {
                MessageBox.Show(string.Join("\n", errorsList));
            }
            return (errorsList.Count == 0);
        }

        private byte[] imageToByteArray(System.Drawing.Image photo)
        {
            using (var ms = new MemoryStream())
            {
                photo.Save(ms, photo.RawFormat);
                return ms.ToArray();
            }
        }

        private System.Drawing.Image arrayToImage(byte [] photoArray)
        {
            using (var ms = new MemoryStream(photoArray))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!VerifyFields()) { return; }

            try
            {
                string ownerName = tbName.Text;

                byte[] photo = imageToByteArray((System.Drawing.Image)btPhoto.Content);

               // ICollection<Car> carsInGarage = (from c in context.Cars select c).ToList();

                Owner owner = new Owner { Name = ownerName, Photo = photo};

                context.Owners.Add(owner);
                context.SaveChanges();
                RefreshOwnersClearFields();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Database operation failed: " + ex.Message);
            }
            

        }

        private void PhotoButtonClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {

              /*  ImageSource imageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                imgPhoto.Source = imageSource; 

               Uri fileUri = new Uri(openFileDialog.FileName);
                imgPhoto.Source = fileUri; */

                btPhoto.Content = System.Drawing.Image.FromFile(openFileDialog.FileName); 


            }
        }

        private void btManageCars_Click(object sender, RoutedEventArgs e)
        {
            Owner selectedOwner = (Owner)lstOwners.SelectedItem;

            CarsDialog dlg = new CarsDialog(selectedOwner);
            dlg.Owner = this;
            dlg.AssignCarsToOwner += CustDlg_AssignResult;
            dlg.ShowDialog();
            RefreshOwnersClearFields();
        }

        private void CustDlg_AssignResult(ICollection<Car> carsIngar)
        {
            Owner owner = (Owner)lstOwners.SelectedItem;
            owner.CarsInGarage = carsIngar;
        }

        private void lstOwners_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstOwners.Items.Count != 0 && lstOwners.SelectedIndex != -1)
            {
                try
                {
                    btManageCars.IsEnabled = true;

                    Owner owner = (Owner)lstOwners.SelectedItem;

                    lblOwnerId.Content = owner.Id;
                    tbName.Text = owner.Name;
                    btPhoto.Content = arrayToImage(owner.Photo);
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message, "Loading image failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            Owner owner = (Owner)lstOwners.SelectedItem;

            try
            {
                owner.Name = tbName.Text;
                owner.Photo = imageToByteArray((System.Drawing.Image)btPhoto.Content);
                context.SaveChanges();
                RefreshOwnersClearFields();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Database operation failed: " + ex.Message);
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Owner owner = (Owner)lstOwners.SelectedItem;

                context.Owners.Remove(owner);
                context.SaveChanges();
                RefreshOwnersClearFields();

            }
            catch (SystemException ex)
            {
                MessageBox.Show("Database operation failed: " + ex.Message);
            }
        }
    }
}
