using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Quiz2Travel
{
    class Trip
    {
        string _destination;
        string _name;
        string _passportNo;
        DateTime _departure;
        DateTime _return;

        const string PassportPattern = "^[A-Z]{2}[0-9]{6}$";


        //constructor
        public Trip(string destination, string name, string passportNo, DateTime departure, DateTime retDate)
        {
            Destination = destination;
            Name = name;
            PassportNo = passportNo;
            Departure = departure;
            Return = retDate;
        }

        //constructor from dataline
        public Trip(string dataLine)
        {
            string[] words = dataLine.Split(';');
            if (words.Length != 5)
            {
                throw new DataInvalidException("Wrong data structure: " + dataLine);
            }
            //destination
            Destination = words[0];
            //name
            Name = words[1];
            //passportNo
            PassportNo = words[2];
            //departure
            DateTime departure;
            if (!DateTime.TryParse(words[3],
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out departure))
            {
                throw new DataInvalidException("Error parsing departure date: " + dataLine);
            }
            Departure = departure;
            //return
            DateTime retDate;
            if (!DateTime.TryParse(words[4],
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out retDate))
            {
                throw new DataInvalidException("Error parsing return date: " + dataLine);
            }
            Return = retDate;
        }


        //destination
        public string Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                if (value.Contains(';') || value.Length <2 || value.Length > 30)
                {
                    throw new DataInvalidException("Destination must be between 2 and 30 characters without semicolons");
                }
                _destination = value;
            }
        }

        //name
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Contains(';') || value.Length < 2 || value.Length > 30)
                {
                    throw new DataInvalidException("Name must be between 2 and 30 characters without semicolons");
                }
                _name = value;
            }
        }

        //passportNo
        public string PassportNo
        {
            get
            {
                return _passportNo;
            }
            set
            {
                if (!Regex.IsMatch(value, PassportPattern))
                {
                    throw new DataInvalidException("Passport number must start with two upper case letters followed by six digits");
                }
                _passportNo = value;
            }
        }

        //departure
        public DateTime Departure
        {
            get
            {
                return _departure;
            }
            set
            {
                if (value == null)
                {
                    throw new DataInvalidException("Departure date cannot be null");
                }
                _departure = value;
            }
        }

        //return
        public DateTime Return
        {
            get
            {
                return _return;
            }
            set
            {
                if (value == null)
                {
                    throw new DataInvalidException("Return date cannot be null");
                }
                if (value < Departure)
                {
                    throw new DataInvalidException("Return date cannot be earlier than departure date");
                }
                _return = value;
            }
        }

        //toString
        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4}", Destination, Name, PassportNo, Departure.ToShortDateString(), Return.ToShortDateString());
        }

       
    }
}
