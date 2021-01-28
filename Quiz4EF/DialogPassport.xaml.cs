using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DialogPassport.xaml
    /// </summary>
    public partial class DialogPassport : Window
    {
       Person receivedPerson;

        public const string passportPattern = "^[A-Z]{2}[0-9]{6}$";

        byte[] currPassportImage;

        public DialogPassport(Person person)
        {
            
            receivedPerson = person;
            InitializeComponent();
            if (receivedPerson != null)
            {
                lblName.Content = receivedPerson.Name;
            }
            if (receivedPerson.Passport == null)
            {
                btSave.Content = "Add";
            }
            if (receivedPerson.Passport != null)
            {
                btSave.Content = "Update";
                tbPassportNo.Text = receivedPerson.Passport.PassportNo;
                image.Source = Utils.GetBitmapImage(receivedPerson.Passport.Image);
                    
            }
        }

        private bool VerifyFields()
        {

            if (!Regex.IsMatch(tbPassportNo.Text, passportPattern))
            {
                MessageBox.Show("Passport number must have two capital letters followed by six digits","Input error",MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (image == null)
            {
                MessageBox.Show("Please choose an image", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            //adding
            if (receivedPerson.Passport == null)
            {

                if (!VerifyFields()) { return; }
                try
                {
                    Passport passport = new Passport { Person = receivedPerson,PassportNo =tbPassportNo.Text, Image = currPassportImage};
                    Utils.context.Passports.Add(passport);
                    Utils.context.SaveChanges();
                    tbPassportNo.Text = "";
                    image.Source = null;
                    tbImage.Visibility = Visibility.Visible;
                }
                catch (SystemException ex)
                {
                    MessageBox.Show("Database error: "+ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            //updating
            if (receivedPerson.Passport != null)
            {
                    if (!VerifyFields()) { return; }
                    try
                    {
                        receivedPerson.Passport.PassportNo = tbPassportNo.Text;
                        receivedPerson.Passport.Image = currPassportImage;
                        Utils.context.SaveChanges();
                        tbPassportNo.Text = "";
                        image.Source = null;
                        tbImage.Visibility = Visibility.Visible;
                    }
                    catch (SystemException ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
            }
            DialogResult = true;
        }

        private void btImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    tbImage.Visibility = Visibility.Hidden;
                    currPassportImage = File.ReadAllBytes(dlg.FileName);
                    BitmapImage bitmap = Utils.ByteArrayToBitmapImage(currPassportImage);
                    image.Source = bitmap;
                }
                catch (Exception ex) when (ex is SystemException || ex is IOException)
                {
                    MessageBox.Show(ex.Message, "File reading failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
