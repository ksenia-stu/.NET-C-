using Microsoft.Win32;
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

namespace BooksDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;

        List<Book> BooksList = new List<Book>();

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                db = new Database();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(1);
            }
            RefreshBooksList();
        }

        private void RefreshBooksList()
        {
            if(db == null)
            {
                return;
            }
            try
            {
                BooksList = db.GetAllBooks();
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
            lstBooks.ItemsSource = BooksList;
        }

        private void AddBookButtonClicked(object sender, RoutedEventArgs e)
        {
            string title = tbTitle.Text;
            string isbn = tbIsbn.Text;
            if(dpPubDate.SelectedDate == null)
            {
                MessageBox.Show("Please select a date");
                return;
            }
            DateTime pubDate = (DateTime)dpPubDate.SelectedDate;
           

            //cover
            var bmp = imgCover.Source as BitmapImage;

            int height = bmp.PixelHeight;
            int width = bmp.PixelWidth;
            int stride = width * ((bmp.Format.BitsPerPixel + 7) / 8);

            byte[] cover = new byte[height * stride];
            bmp.CopyPixels(cover, stride, 0);

            Book book;

            try
            {
                book = new Book(0,title, isbn, pubDate, cover);
                db.AddBook(book);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ho ho" +ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show("hi hi" +ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("bi bi" +ex.Message);
            }

        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)  //oK button clicked
            {
                string selectedFileName = dlg.FileName;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(selectedFileName);
                image.EndInit();
                imgCover.Source = image;
            }
        }
    }
}
