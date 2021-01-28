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

namespace Day10TodosEntity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //list to store todos
        List<Todo> TodosList = new List<Todo>();

        //context
        AgendaDbContext context;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                context = new AgendaDbContext();
                ReloadTodos();
                //load enums to combo
                comboStatus.ItemsSource = Enum.GetValues(typeof(Todo.StatusEnum));
            }
            catch(SystemException ex)
            {
                MessageBox.Show("Fatal error connecting to database: " + ex.Message);
                Environment.Exit(1);
            }
        }

        private void ReloadTodos()
        {
            TodosList = (from t in context.Todos select t).ToList<Todo>();
            lstTodos.ItemsSource = TodosList;
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            //task
            string task = tbTask.Text;

            //difficulty
            int diff = Convert.ToInt32(sliderDiff.Value);

            //duedate
            DateTime dueDate;
            DateTime.TryParse(tbDueDate.Text,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dueDate);


            //status
            Enum.TryParse(comboStatus.SelectedValue.ToString(), out Todo.StatusEnum status);


            Todo td = null;
            try
            {
                td = new Todo { Task = task, Difficulty = diff, DueDate = dueDate, Status = status };
            }
            catch (InvalidValueException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            try
            {
                context.Todos.Add(td);
                context.SaveChanges();
                ReloadTodos();
            }
            catch (SystemException ex) // catch-all for EF, SQL and many other exceptions
            {
                MessageBox.Show("Database operation failed: " + ex.Message);
            }
        }

        private void lstTodos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstTodos.Items.Count != 0 && lstTodos.SelectedIndex != -1)
            {
                btDelete.IsEnabled = true;
                btUpdate.IsEnabled = true;
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            Todo selectedTodo = (Todo)lstTodos.SelectedItem;

            try
            {
                context.Todos.Remove(selectedTodo);
                context.SaveChanges();
                ReloadTodos();
            }
            catch (SystemException ex) // catch-all for EF, SQL and many other exceptions
            {
                MessageBox.Show("Database operation failed: " + ex.Message);
            }
        }

        

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {

            Todo selectedTodo = (Todo)lstTodos.SelectedItem;

          //  Todo todo = (from t in context.Todos where t.Id == selectedTodo.Id select t).FirstOrDefault<Todo>(); //if there is at least 1 record then give first of them, if not give null


            try
            {
                selectedTodo.Task = tbTask.Text;
                selectedTodo.Difficulty = Convert.ToInt32(sliderDiff.Value);
                DateTime dueDate;
                DateTime.TryParse(tbDueDate.Text,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out dueDate);
                selectedTodo.DueDate = dueDate;
                //status
                Todo.StatusEnum status;
                Enum.TryParse(comboStatus.SelectedValue.ToString(), out status);
                selectedTodo.Status = status;

                context.SaveChanges();// synchronize objects in memory with database
                ReloadTodos();
            }
            catch (InvalidValueException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            catch (SystemException ex) // catch-all for EF, SQL and many other exceptions
            {
                MessageBox.Show("Database operation failed: " + ex.Message);
            }
        }
    }
    }
