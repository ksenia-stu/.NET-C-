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

namespace Day08BigTodo
{
    /// <summary>
    /// Interaction logic for AddEditTodoDialog.xaml
    /// </summary>
    public partial class AddEditTodoDialog : Window
    {
        Todo receivedTodo;

        public AddEditTodoDialog(Todo todo)
        {
            receivedTodo = todo;
            InitializeComponent();
            if(receivedTodo != null)
            {
                btCreateUpdate.Content = "Update";
                lblId.Content = receivedTodo.Id;
                tbTask.Text = receivedTodo.Task;
                dpDueDate.Text = receivedTodo.DueDate.ToString();
                if(receivedTodo.Status.ToString() == "Done")
                {
                    cbIsDone.IsChecked = true;
                }
                else
                {
                    cbIsDone.IsChecked = false;
                }
            }
        }

        private void btCreateUpdate_Click(object sender, RoutedEventArgs e)
        {
            string task = tbTask.Text;

            DateTime.TryParse(dpDueDate.Text,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime dueDate);
            if(dueDate == null)
            {
                MessageBox.Show("Choose a due date ", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool? isDone = cbIsDone.IsChecked;
            string statusStr = "";
            if (isDone == true)
            {
                statusStr = "Done";
            }
            if(isDone == null || isDone == false)
            {
                statusStr = "Pending";
            } 
            Enum.TryParse(statusStr, out Todo.StatusEnum status);

            try
            {
                if (receivedTodo == null)
                {
                    database.AddTodo(new Todo(0, task, dueDate, status));
                }
                if (receivedTodo!= null)
                {
                    receivedTodo.Task = task;
                    receivedTodo.DueDate = dueDate;
                    receivedTodo.Status = status;
                    database.UpdateTodo(receivedTodo);
                }
                DialogResult = true;
            }
            catch (InvalidValueException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
