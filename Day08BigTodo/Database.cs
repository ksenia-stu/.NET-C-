using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Day08BigTodo
{
    public class Database
    {
        // NOT TO CATCH EXCEPTIONS AT DATABASE LEVEL


        //connection string
        const string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\2020-ipd23-dotnet\Day08BigTodo\TodosDb.mdf;Integrated Security=True;Connect Timeout=30";

        //instance of connection
        private SqlConnection conn;
        public Database() // sql ex
        {
            //connect to database
            conn = new SqlConnection(ConnString);
            conn.Open(); //sql  ex
        }

        public enum SortOrder { Task, DueDate }

        //GET ALL TODOS FROM DATABASE to List<Todo>
        //returns List<Todo>
        public List<Todo> GetAllTodos(SortOrder order) // ex
        {
            List<Todo> list = new List<Todo>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Todos ORDER BY"+ order, conn))
                using (SqlDataReader reader = cmd.ExecuteReader()) // ex
                {
                    while (reader.Read())
                    {
                        list.Add(new Todo(reader)); // ex
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error connection to database" + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error connection to database " + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Error connection to database " + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return list;
        }

       
        //INSERT DATA TO DB
        public void AddTodo(Todo todo)
        {
          //  try
          //  {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Todos (Task, DueDate, Status)" +
                    " VALUES (@Task, @DueDate, @Status)", conn))
                {
                    cmd.Parameters.AddWithValue("@Task", todo.Task);
                    cmd.Parameters.AddWithValue("@DueDate", todo.DueDate);
                    cmd.Parameters.AddWithValue("@Status", todo.Status.ToString());
                    cmd.ExecuteNonQuery(); //SQLException IO exception
                }
         //   }
         /*   catch (SqlException ex)
            {
                MessageBox.Show("Error connection to database" + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error connection to database " + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Error connection to database " + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            } */
        }

        //UPDATE
        public void UpdateTodo(Todo todo)
        {
          //  try
          //  {
                using (SqlCommand cmd = new SqlCommand("UPDATE Todos SET Task = @Task, DueDate = @DueDate, Status = @Status WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Task", todo.Task);
                    cmd.Parameters.AddWithValue("@DueDate", todo.DueDate);
                    cmd.Parameters.AddWithValue("@Status", todo.Status.ToString());
                    cmd.Parameters.AddWithValue("@Id", todo.Id);
                    cmd.ExecuteNonQuery(); //SQLException IO exception
                }
          //  }
         /*   catch (SqlException ex)
            {
                MessageBox.Show("Error connection to database" + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error connection to database " + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            } */
        }

        //DELETE
        public void DeleteTodo(int id)
        {
           // try
           // {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Todos WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery(); //SQLException IO exception
                }
       /*     }
            catch (SqlException ex)
            {
                MessageBox.Show("Error connection to database" + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error connection to database " + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            } */
        }

        //GET ALL TODOS SORT BY TASK
        public List<Todo> SortByTask() // ex
        {
            List<Todo> list = new List<Todo>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Todos ORDER BY Task ASC", conn))
                using (SqlDataReader reader = cmd.ExecuteReader()) // ex
                {
                    while (reader.Read())
                    {
                        list.Add(new Todo(reader)); // ex
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error connection to database" + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error connection to database " + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Error connection to database " + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return list;
        }

        //GET ALL TODOS SORT BY DUEDATE
        public List<Todo> SortByDueDate() // ex
        {
            List<Todo> list = new List<Todo>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Todos ORDER BY DueDate ASC", conn))
                using (SqlDataReader reader = cmd.ExecuteReader()) // ex
                {
                    while (reader.Read())
                    {
                        list.Add(new Todo(reader)); // ex
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error connection to database" + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error connection to database " + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Error connection to database " + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return list;
        }

    }
}
