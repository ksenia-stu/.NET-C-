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

namespace Day05TodoInFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        //list to store todos
        List<Todo> TodosList = new List<Todo>();

        //file to save data
        string FileName = @"..\..\todos.txt";




        public MainWindow()
        {
            InitializeComponent();
            try
            {
                LoadDataFromFile();
            }
            catch(InvalidValueException ex)
            {
                MessageBox.Show("Error loading data: \n " + ex.Message, "Import error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //load items from TodosList to lisview
            lstTodos.ItemsSource = TodosList;


            //load enums to combo
            comboStatus.ItemsSource = Enum.GetValues(typeof(Todo.StatusEnum));
        }
        private void ClearInputs()
        {
            tbTask.Text = "";
            sliderDiff.Value = 2;
            tbDueDate.Text = "";
            comboStatus.SelectedIndex = 0;
        }



        private void SaveDataToFile()
        {
            if (lstTodos.Items.Count != 0)
            {
                try
                {
                    using (TextWriter tw = new StreamWriter(FileName))
                    {
                        foreach (Todo todo in TodosList)
                        {
                            tw.WriteLine(todo.ToDataString());
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error saving to file:  " + ex.Message, "Export error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void LoadDataFromFile()
        {
            Todo todo = null; //todo object
            string[] lines = null; //to store lines from file

            try
            {
                lines = System.IO.File.ReadAllLines(FileName);  //file not found exception

                foreach (string line in lines)
                {
                    todo = new Todo(line);   
                    TodosList.Add(todo);
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw new InvalidValueException(ex.Message); 
            }
            catch (InvalidValueException ex)
            {
                throw new InvalidValueException(ex.Message);
            }
        }

            private Todo CreateUpdateTodoFromInputs(Todo todo)
            {
            //task
            string task = tbTask.Text;

            //difficulty
            int diff = Convert.ToInt32(sliderDiff.Value);

            //duedate
            DateTime dueDate;
            /*  DateTime.TryParseExact(tbDueDate.Text, "y-M-d", System.Globalization.CultureInfo.InvariantCulture,
              System.Globalization.DateTimeStyles.None, out dueDate); */
            DateTime.TryParse(tbDueDate.Text, 
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dueDate);


            //status
            Enum.TryParse(comboStatus.SelectedValue.ToString(), out Todo.StatusEnum status);

            if (todo == null)
            {
                //create object person
                Todo td = null;
                try
                {
                    td = new Todo(task, diff, dueDate, status);
                }
                catch (InvalidValueException ex)
                {
                    throw new InvalidValueException(ex.Message);
                }
                return td;
            }
            todo.Task = task;
            todo.Difficulty = diff;
            todo.DueDate = dueDate;
            todo.Status = status;
            return todo;
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            Todo todo = null;
            try
            {
                todo = CreateUpdateTodoFromInputs(null);
            }
            catch(InvalidValueException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            TodosList.Add(todo);
            lstTodos.Items.Refresh();
            ClearInputs();


        }

        private void lstTodos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstTodos.Items.Count != 0)
            {
                if(lstTodos.SelectedIndex != -1)
                {
                    btDelete.IsEnabled = true;
                    btUpdate.IsEnabled = true;
                    Todo todo = (Todo)lstTodos.SelectedItem;
                    tbTask.Text = todo.Task;
                    sliderDiff.Value = todo.Difficulty;
                    tbDueDate.Text = todo.DueDate.ToShortDateString();
                    comboStatus.SelectedValue = todo.Status;
                }
                else
                {
                    btDelete.IsEnabled = false;
                    btUpdate.IsEnabled = false;
                }
            }
            else
            {
                btDelete.IsEnabled = false;
                btUpdate.IsEnabled = false;
            }
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete record:\n" + lstTodos.SelectedValue, "Confirmation needed",
             MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                TodosList.RemoveAt(lstTodos.SelectedIndex);
                lstTodos.Items.Refresh();
                ClearInputs();
            }

        }

        private void UpdateButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateUpdateTodoFromInputs((Todo)lstTodos.SelectedItem);
            }
            catch (InvalidValueException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            lstTodos.Items.Refresh();
            ClearInputs();
        }

        private void ExportButtonClicked(object sender, RoutedEventArgs e)
        {
            if (lstTodos.Items.Count == 0)
            {
                MessageBox.Show("The list is empty. No data to be saved ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Untitled.txt"; // Default file name
            saveFileDialog.Filter = "Text Files | *.txt";
            saveFileDialog.DefaultExt = "txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (TextWriter tw = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (Todo todo in TodosList)
                        {
                            tw.WriteLine(todo.ToDataString());
                        }

                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error saving to file:  "+ex.Message, "Export error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                MessageBox.Show("File saved", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveDataToFile();
        }
    }
}
