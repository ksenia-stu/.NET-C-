using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz3FinalFlights
{
    public class Database
    {
        const string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\2020-ipd23-dotnet\Quiz3FinalFlights\FlightsDb.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection conn;
        public Database() // sql ex
        {
            conn = new SqlConnection(ConnString);
            conn.Open(); // sql ex
        }

        //get flights
        public List<Flight> GetAllFlights() // SqlException, ArgumentException
        {
            List<Flight> list = new List<Flight>();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Flights", conn))
            using (SqlDataReader reader = cmd.ExecuteReader()) // ex
            {
                while (reader.Read())
                {
                    list.Add(new Flight(reader)); // SqlException, ArgumentException
                }
            }
            return list;
        }

        //add flight
        public void AddFlight(Flight flight) // ex
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Flights (Date, FromCode, ToCode, Type, Passengers) VALUES (@Date, @FromCode, @ToCode, @Type, @Passengers)", conn))
            {
                cmd.Parameters.AddWithValue("@Date", flight.Date);
                cmd.Parameters.AddWithValue("@FromCode", flight.FromCode);
                cmd.Parameters.AddWithValue("@ToCode", flight.ToCode);
                string type = flight.Type.ToString();
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Passengers", flight.Passengers);
                cmd.ExecuteNonQuery(); // ex
            }
        }

        //update flight
        public void UpdateFlight(Flight flight)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Flights SET Date = @Date, FromCode = @FromCode, ToCode = @ToCode, Type = @Type, Passengers = @Passengers WHERE Id=@Id", conn))
            {
                cmd.Parameters.AddWithValue("@Date", flight.Date);
                cmd.Parameters.AddWithValue("@FromCode", flight.FromCode);
                cmd.Parameters.AddWithValue("@ToCode", flight.ToCode);
                string type = flight.Type.ToString();
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Passengers", flight.Passengers);
                cmd.Parameters.AddWithValue("@Id", flight.Id);
                cmd.ExecuteNonQuery();
            }
        }

        //delete flight
        public void DeleteFlight(int id)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Flights WHERE Id=@Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
