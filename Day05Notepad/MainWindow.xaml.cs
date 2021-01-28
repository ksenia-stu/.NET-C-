using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Day05Notepad
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

        static OpenFileDialog openFileDialog;
        private void FileOpenButtonClicked(object sender, RoutedEventArgs e)
        {
            if (tbEditor.Text.Length != 0)
            {
                MessageBoxResult result = MessageBox.Show("Save data before opening new file?", "Confirmation needed",
                 MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (openFileDialog == null)
                    {
                        SaveDataToFile();
                    }
                    if(openFileDialog != null)
                    {
                        SaveData();
                    }
                    MessageBox.Show("File saved", "Success",
               MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                tbEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }

        

        static SaveFileDialog saveFileDialog;
        private void FileSaveButtonClicked(object sender, RoutedEventArgs e)
        {

            SaveData();

        }

        private void SaveData()
        {
            if (openFileDialog != null)
            {
                try
                {
                    using (TextWriter tw = new StreamWriter(openFileDialog.FileName))
                    {

                        tw.WriteLine(tbEditor.Text);
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            else
            {
                SaveDataToFile();
            }
        }

        private void SaveDataToFile()
        {
            saveFileDialog = new SaveFileDialog();
            if (openFileDialog != null)
            {
                saveFileDialog.FileName = openFileDialog.SafeFileName; // Default file name
            }

            saveFileDialog.Filter = "Text Files | *.txt";
            saveFileDialog.DefaultExt = "txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                //check file extension
                // SaveFileDialog sv = (sender as SaveFileDialog);

                /*    string fileName = saveFileDialog.FileName;
                    if (System.IO.Path.GetExtension(fileName).ToLower() != ".txt")
                    {
                        fileName = System.IO.Path.GetFileNameWithoutExtension(fileName) + ".txt";
                     //   MessageBox.Show("Please omit the extension or use 'CSV'");
                     //   return;
                    } */

                try
                {
                    using (TextWriter tw = new StreamWriter(saveFileDialog.FileName))
                    {

                        tw.WriteLine(tbEditor.Text);
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                MessageBox.Show("File saved", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void FileSaveAsButtonClicked(object sender, RoutedEventArgs e)
        {
            SaveDataToFile();
        }

        private void tbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (openFileDialog == null)
            {
                Console.WriteLine("open dialog null");
                if (saveFileDialog != null)
                {
                    Console.WriteLine("save dialog not null");
                    Title = System.IO.Path.GetFileNameWithoutExtension(saveFileDialog.FileName) + " (Modified)";
                    FilePath.Text = saveFileDialog.FileName;
                }

                Title = "Untitled (Modified)";
                FilePath.Text = "No file open";
            }
            else
            {
                Console.WriteLine("open dialog not null");
                string filePath = openFileDialog.FileName;
                Title = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName) + " (Modified)";
                FilePath.Text = filePath;
            }
        }
        private void FileExitButtonClicked(object sender, RoutedEventArgs e)
        {
       
                Close();
         
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Save data before exiting the program?", "Confirmation needed",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                SaveDataToFile();
            }
            
            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
