using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1Multi
{
    class Program
    {

        //file to read and write data
        public const string DataFileName = @"..\..\data.txt";


        //List to store Airports
        static public List<Airport> AirportsList = new List<Airport>();

        //current time
        static readonly String currentTime = GetTimestamp(DateTime.Now);

        //method to get timestamp in format yyyy-mm-dd hh:mm:ss
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        //method for logging to console
        public static void LogToConsole(string msg)
        {
            Console.WriteLine("{0} {1} ", currentTime, msg);
        }

        //method for logging to file
        public static void LogToFile(string msg)
        {
            string line = string.Format("{0} {1} \n", currentTime, msg);
            try
            {
                File.AppendAllText(@"..\..\events.log", line);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                Console.ReadKey();
            }
        }

        private static int getMenuChoice()
        {
            while (true)
            {
                Console.Write(@"Menu:
1. Add Airport
2. List all airports
3. Find nearest airport by code
4. Find airport's elevation standard deviation
5. Change log delegates
0. Exit
Enter your choice: ");
                String choiceStr = Console.ReadLine();
                int choice;
                if (!int.TryParse(choiceStr, out choice))
                {
                    Console.WriteLine("Value must be a number");
                     continue;
                  
                }
                return choice;
            }
        }

        static void ReadDataFromFile()
        {
            if (File.Exists(DataFileName))
            {
                try
                {
                    string[] lines = File.ReadAllLines(DataFileName);
                    foreach (string line in lines)
                    {
                        try
                        {
                            Airport a = new Airport(line);
                            AirportsList.Add(a);
                        }
                        catch (InvalidDataException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error reading from file: " + ex.Message);
                }

            }
        }


        static void WriteDataToFile() 
        {
            try
            {
                using (StreamWriter fileOutput = new StreamWriter(DataFileName))
                {
                    foreach (Airport a in AirportsList)
                        fileOutput.WriteLine(a.ToDataString());
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void AddAirport()
        {
            Airport airport;

            Console.WriteLine("Adding airport");
            Console.Write("Enter code: ");
            string code = Console.ReadLine();
            Console.Write("Enter city: ");
            string city = Console.ReadLine();
            Console.Write("Enter latitude: ");
            string latStr = Console.ReadLine();
            double latitude;
            if (!double.TryParse(latStr, out latitude))
            {
                Console.WriteLine("Error: Latitude must be a valid decimal");
                return;
            }
            Console.Write("Enter longitude: ");
            string lngStr = Console.ReadLine();
            double longitude;
            if (!double.TryParse(lngStr, out longitude))
            {
                Console.WriteLine("Error: Longitude must be a valid decimal");
                return;
            }
            Console.Write("Enter elevation in meters: ");
            string elevStr = Console.ReadLine();
            int elevation;
            if (!int.TryParse(elevStr, out elevation))
            {
                Console.WriteLine("Error: Elevation must be a valid integer");
                return;
            }

            try
            {
                airport = new Airport(code, city, latitude, longitude, elevation);
                AirportsList.Add(airport);
                Console.WriteLine("Airport added");

            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        static void ListAllAirports()
        {
            foreach (Airport a in AirportsList)
            {
                Console.WriteLine(a);

            }

        }

        public static double CalculateDistance(double sLatitude, double sLongitude, double eLatitude,
                               double eLongitude)
        {
            var sCoord = new GeoCoordinate(sLatitude, sLongitude);
            var eCoord = new GeoCoordinate(eLatitude, eLongitude);

            return sCoord.GetDistanceTo(eCoord);
        }


            static void FindAirportByCode()
        {
            List<string> codes = new List<string>();
            Console.Write("Enter airport code: ");
            string code = Console.ReadLine();

          //  double distance = CalculateDistance()

            foreach (Airport a in AirportsList)
            {
                if (a.Code == code)
                {
                    //  Console.WriteLine(" Found nearest airport to be {0}/{1} distance is {2}km", a.Code, a.City, distance);  //FIX
                    codes.Add(a.Code);
                }
            }
            if(codes.Count == 0)
            {
                Console.WriteLine("Error: No airports found");
            }

        }

        public static void GetStandardDeviation()
        {
            //get a list of airports elevation
            List<double> elevationsList = new List<double>();

            foreach (Airport a in AirportsList)
            {  
                elevationsList.Add(a.ElevationMeters);  
            }

            //get average
            double average = elevationsList.Average();
            double deviation;

            // Then for each number: subtract average and square (multiply by itself) the result
            for (int i = 0; i < elevationsList.Count; i++)
            {
                elevationsList[i] = Math.Pow(elevationsList[i] - average, 2);
            }

            // find average of new numbers in list and then square root of it
            deviation = Math.Sqrt(elevationsList.Average());

            double deviationFinal = elevationsList.Count > 0 ? deviation : 0.0;

            Console.WriteLine("For all airports the standard deviation of their elevation is {0:0.##},",deviationFinal);
        }

        public static void ChangeLogDelegates()
        {
            

                while (true)
                {
                    int result;


                    Console.WriteLine(@"Changing logging settings:
1-Logging to console
2-Logging to file
Enter your choices, comma-separated, empty for none:  ");
                    string choiceStr = Console.ReadLine();

                    if (!int.TryParse(choiceStr, out result) || result < 1 || result > 2)
                    {
                        Console.WriteLine("Value must be a number between 1-3");

                    }



                    // show the menu and ask user's choice
                    int choice = result;
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Logging to console enabled");
                            Quiz1Multi.Airport.Logger += LogToConsole;
                            break;
                        case 2:
                            Console.WriteLine("Logging to file enabled");
                            Quiz1Multi.Airport.Logger += LogToFile;
                            break;
                        case 3:
                            Console.WriteLine("No errors will be logged");
                            break;
                        default:
                            Console.WriteLine("Internal error: invalid control flow in menu, errors will not be logged ");
                            break;
                    }
                }
            
            }

        static void Main(string[] args)
        {
            ReadDataFromFile();
            while (true)
            {
                int choice = getMenuChoice();
                switch (choice)
                {
                    case 1:
                       AddAirport();
                        break;
                    case 2:
                       ListAllAirports();
                        break;
                    case 3:
                      //  FindAirportByCode();
                        break;
                    case 4:
                        GetStandardDeviation();
                        break;
                    case 5:
                        ChangeLogDelegates();
                        break;
                    case 0:
                        WriteDataToFile();
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong choice, please enter valid number");
                        break;
                }
            }
            
        }
    }
}
