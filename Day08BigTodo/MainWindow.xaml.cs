using CsvHelper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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

namespace Day08BigTodo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        //list
        List<Todo> todos = new List<Todo>();

        //default sort order
        Database.SortOrder currentSortOrder = Database.SortOrder.Task; 


        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Globals.db = new Database(); // ex (fatal)
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error connecting to database" + ex.Message, "Database connection fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }

            

        }

        private void RefreshLv()
        {
            todos = Globals.db.GetAllTodos(currentSortOrder);
            lstTodos.ItemsSource = todos;
            // lstTodos.Items.Refresh();
        }

        private void CreateUpdateButtonClicked(object sender, RoutedEventArgs e)
        {
            AddEditTodoDialog dlg = new AddEditTodoDialog(null);
            dlg.Owner = this;
            dlg.ShowDialog();
        }

        private void lstTodos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstTodos.Items.Count != 0 && lstTodos.SelectedIndex != -1)
            {
                Todo todo = (Todo)lstTodos.SelectedItem;
                AddEditTodoDialog dlg = new AddEditTodoDialog(todo);
                dlg.Owner = this;
                dlg.ShowDialog();
            }
        }

        private void lstTodos_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (lstTodos.Items.Count == 0 || lstTodos.SelectedIndex == -1)
                e.Handled = true; //do not open context menu
        }

        private void DeleteTodo_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete todo:\n"
               + lstTodos.SelectedValue, "Confirmation needed",
            MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Todo todo = (Todo)lstTodos.SelectedItem;
                Globals.db.DeleteTodo(todo.Id);

            }
            RefreshLv();
        }

        private void FileExportButtonClicked(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.Title = "Export to file";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (var writer = new StreamWriter(saveFileDialog.FileName))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.Configuration.Delimiter = ";";
                        csv.WriteRecords(db.GetAllTodos()); 
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error writing file: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void FileExitButtonClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void SortByTask(object sender, RoutedEventArgs e)
        {
            lstTodos.ItemsSource = db.SortByTask();
        }

        private void SortByDueDate(object sender, RoutedEventArgs e)
        {
            lstTodos.ItemsSource = db.SortByDueDate();
        }
    }
}
