using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1Multi
{
    class Airport
    {
		const string CodePattern = "^[A-Z]{3}$";
        const string CityPattern = "^[-A-Za-z0-9,.]{1,50}$";  

        //defining delegate
        public delegate void LoggerDelegate(string message);
        //define Airport's class field of delegated type
        public static LoggerDelegate Logger = null;

        public Airport(string code, string city, double lat, double lng, int elevM)
        {
            Code = code;
            City = city;
            Latitude = lat;
            Longitude = lng;
            ElevationMeters = elevM;
        }
		public Airport(string dataLine)
        {
            string[] words = dataLine.Split(';');
            if (words.Length != 5)
            {
                throw new InvalidDataException("Wrong data structure in line: "+ dataLine);
            }
            Code = words[0];
            City = words[1];
            double latitude;
            if (!double.TryParse(words[2], out latitude))
            {
                throw new InvalidDataException("Latitude must be a number in line: " + dataLine);
            }
            Latitude = latitude;
            double longitude;
            if (!double.TryParse(words[3], out longitude))
            {
                throw new InvalidDataException("Longitude must be a number in line: " + dataLine);
            }
            Longitude = longitude;
            int elevationMeters;
            if (!int.TryParse(words[4], out elevationMeters))
            {
                throw new InvalidDataException("Elevation must be a number in line: " + dataLine);
            }
            ElevationMeters = elevationMeters;
        }

		string _code; // exactly 3 uppercase letters, use regexp
		string _city; // 1-50 characters, made up of uppercase and lowercase letters, digits, and .,- characters
		double _latitude, _longitude; // -90 to 90, -180 to 180
		int _elevationMeters; //-1000 to 10000


        public string Code  
        {
            get
            {
                return _code;
            }
            set
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, CodePattern))
                {
                    Logger?.Invoke("Code must be made of exactly 3 upper case letters");
                    throw new InvalidDataException("Code must be made of exactly 3 upper case letters");
                }
                _code = value;
            }
        }

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, CityPattern))
                {
                    Logger?.Invoke("City must contain 1-50 characters, made up of uppercase and lowercase letters, digits, and .,- characters");
                    throw new InvalidDataException("City must contain 1-50 characters, made up of uppercase and lowercase letters, digits, and .,- characters");
                }
                _city = value;
            }
        }

        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                if (value < -90 || value > 90)
                {
                    Logger?.Invoke("Latitude must be between -90 and 90");
                    throw new InvalidDataException("Latitude must be between -90 and 90");
                }
                _latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                if (value < -180 || value > 180)
                {
                    Logger?.Invoke("Longitude must be between -180 and 180");
                    throw new InvalidDataException("Longitude must be between -180 and 180");
                }
                _longitude = value;
            }
        }

        public int ElevationMeters
        {
            get
            {
                return _elevationMeters;
            }
            set
            {
                if (value < -1000 || value > 10000)
                {
                    Logger?.Invoke("Elevation must be between -1000 and 10000 meters");
                    throw new InvalidDataException("Elevation must be between -1000 and 10000 meters");
                }
                _elevationMeters = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} in {1} at {2} lat / {3} lng at {4}m elevation", Code, City,Latitude,Longitude, ElevationMeters);
        }
        public string ToDataString()
        {
            return string.Format("{0};{1};{2};{3};{4}", Code, City, Latitude, Longitude, ElevationMeters);
        }

    }
}
