using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Day08CarDb
{
    public class Database
    {
        //connection string
        const string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\2020-ipd23-dotnet\Day08CarDb\CarsDb.mdf;Integrated Security=True;Connect Timeout=30";

        //instance of connection
        private SqlConnection conn;
        public Database() // sql ex
        {
            //connect to database
            conn = new SqlConnection(ConnString);
            conn.Open(); //sql  ex
        }

        //GET ALL CARS FROM DATABASE to List<Car>
        //returns List<Car>
        public List<Car> GetAllCars() // ex
        {
            List<Car> list = new List<Car>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Cars", conn))
                using (SqlDataReader reader = cmd.ExecuteReader()) // ex
                {
                    while (reader.Read())
                    {
                        list.Add(new Car(reader)); // ex
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
        public void AddCar(Car car)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Cars (MakeModel, EngineSize, FuelType)" +
                    " VALUES (@MakeModel, @EngineSize, @FuelType)", conn))
                {
                    cmd.Parameters.AddWithValue("@MakeModel", car.MakeModel);
                    cmd.Parameters.AddWithValue("@EngineSize", car.EngineSize);
                    cmd.Parameters.AddWithValue("@FuelType", car.FuelType);
                    cmd.ExecuteNonQuery(); //SQLException IO exception
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error connection to database" + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error connection to database "+ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show("Error connection to database " + ex.Message, "Database connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //UPDATE
        public void UpdateCar(Car car)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Cars SET MakeModel = @MakeModel, EngineSize = @EngineSize, FuelType = @FuelType WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@MakeModel", car.MakeModel);
                    cmd.Parameters.AddWithValue("@EngineSize", car.EngineSize);
                    cmd.Parameters.AddWithValue("@FuelType", car.FuelType);
                    cmd.Parameters.AddWithValue("@Id", car.Id);
                    cmd.ExecuteNonQuery(); //SQLException IO exception


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
        }

        //DELETE
        public void DeleteCar(int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Cars WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery(); //SQLException IO exception


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
        }

    }
}
