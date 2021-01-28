using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07Cars
{
	public class Car
	{
		string _makeModel; // 2-50 characters
		double _engineSize; // 0-20
        FuelTypeEnum _fuelType;
		
		
        public Car(string makeModel, double engineSize, FuelTypeEnum fuelType)
        {
            MakeModel = makeModel;
            EngineSize = engineSize;
            FuelType = fuelType;

        }

        //constructor from dataline
        public Car(string dataLine)
        {
            string[] words = dataLine.Split(';');
            if (words.Length != 3)
            {
                throw new DataInvalidException("Wrong data structure: " + dataLine);
            }
            //make model
            MakeModel = words[0];
            //engine size
            double engineSize;
            if (!double.TryParse(words[1], out engineSize))
            {
                throw new DataInvalidException("Engine size must be a number: " + dataLine);
            }
            EngineSize = engineSize;
            //fuel type
            if (!Enum.TryParse(words[2], out FuelTypeEnum fuelType))
            {
                throw new DataInvalidException("Fuel type has wrong format: " + dataLine);
            }
            FuelType = fuelType;
        }

        //make model
        public string MakeModel
        {
            get
            {
                return _makeModel;
            }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new DataInvalidException("Make model must be between 2 and 30 characters");
                }
                _makeModel = value;
            }
        }

        //engine size
        public double EngineSize
        {
            get
            {
                return _engineSize;
            }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new DataInvalidException("Engine size must be between 0 and 20");
                }
                _engineSize = value;
            }
        }

        //fuel type
        public FuelTypeEnum FuelType { get => _fuelType; set => _fuelType = value; }


        //toString
        public override string ToString()
        {
            return string.Format("{0};{1};{2}", MakeModel, EngineSize, FuelType);
        }


    }
}
