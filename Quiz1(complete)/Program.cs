using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1_complete_
{
    class Program
    {

        //file to read and write data
        public const string DataFileName = @"..\..\data.txt";

        //List to save airports
        static List<Airport> AirportsList = new List<Airport>();
        static public int GetUserChoice()
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

                int choice;
                string userChoice = Console.ReadLine();

                if (int.TryParse(userChoice, out choice))
                {
                    if(choice >= 0 && choice <=5)
                    {
                        return choice;
                    }
                    Console.WriteLine("Please enter number between 0 and 5 \n");
                    continue;
                }
                Console.WriteLine("You must enter a number\n");
            }
        }

        static public void  AddAirport()
        {
            Airport airport = null;
            
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
                    Console.WriteLine("Latitude must be a number\n");
                    return;
                }
                Console.Write("Enter longitude: ");
                string lngStr = Console.ReadLine();
                double longitude;
                if (!double.TryParse(lngStr, out longitude))
                {
                    Console.WriteLine("Longitude must be a number\n");
                    return;
                }
                Console.Write("Enter elevation in meters: ");
                string elevStr = Console.ReadLine();
                int elevation;
                if (!int.TryParse(elevStr, out elevation))
                {
                    Console.WriteLine("Elevation must be a number\n");
                    return ;
                }
                
                try
                {
                    airport = new Airport(code, city, latitude, longitude, elevation);
                }
                catch (InvalidDataException ex)
                {
                    Console.WriteLine("Error: " + ex.Message + "\n");
                return;
                }
            
            AirportsList.Add(airport);
            Console.WriteLine("Airport added.\n");

        }

        static public void ListAllAirports()
        {
            if (AirportsList.Count == 0)
            {
                Console.WriteLine("Sorry, there are no airports to display");
            }
            else
            {
                foreach (Airport a in AirportsList)
                {

                    Console.WriteLine(a);
                }
            }
            
            Console.WriteLine("");
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

        public static double CalculateDistance(Airport a1, Airport a2)
        {   
            var sCoord = new GeoCoordinate(a1.Latitude, a1.Longitude);
            var eCoord = new GeoCoordinate(a2.Latitude, a2.Longitude);

            return sCoord.GetDistanceTo(eCoord)/1000;
        }

        

        static public void FindNearestAirportByCode()
        {
            Console.Write("Enter airport code: ");
            string code = Console.ReadLine();

            if (AirportsList.Count == 0)
            {
                Console.WriteLine("Sorry, no airports are in the list");
                return;
            }
            if (AirportsList.Count == 1)
            {
                Console.WriteLine("Sorry, no airports nearby");
                return;
            }

            //find all airports from list with entered code
            var result = AirportsList.Where(a => a.Code.Contains(code));
            List<Airport> air = result.ToList();

            

            if(air.Count == 0)
            {
                Console.WriteLine("Sorry, airport with this code is not found");
                return;
            }
            else
            {
                Dictionary<Airport, double> AirDist = new Dictionary<Airport, double>();


                foreach (Airport a in AirportsList)
                {
                    if(CalculateDistance(air[0], a) != 0)
                    {
                        AirDist.Add(a, CalculateDistance(air[0], a));
                    }  
                }

                var closestAir = AirDist.OrderBy(kvp => kvp.Value).First();
                //  Console.WriteLine("{0} => {1}", closestAir.Key, closestAir.Value);
                Airport airport = closestAir.Key;

                Console.WriteLine("Found nearest airport to be {0}/{1} distance is {2}km", airport.Code, airport.City, closestAir.Value);
                
            }
            
          
        }

        static void Main(string[] args)
        {
            ReadDataFromFile();
            while(true)
            {
                int result = GetUserChoice();

                switch (result)
                {

                    case 1:
                        AddAirport();
                        break;
                    case 2:
                        ListAllAirports();
                        break;
                    case 3:
                        FindNearestAirportByCode();
                        break;
                    case 4:
                        //GetElevationDeviation();
                        break;
                    case 5:
                        //ChangeLogDelegates();
                        break;
                    case 0:
                        Console.WriteLine("Data saved back to file.\nGood bye.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Internal error: invalid control flow in menu");
                        break;
                }
            }
            

            Console.ReadKey();
        }
    }
}
