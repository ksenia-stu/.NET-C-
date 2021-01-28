using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CarDb
{
    public class Car
    {
        public int Id { get; set; }
        string _makeModel; // 2-50 characters
        double _engineSize; // 0-20
        FuelTypeEnum _fuelType;

        public enum FuelTypeEnum { Gasoline, Diesel, Hybrid, Electric, Other }

        public Car(int id,string makeModel, double engineSize, FuelTypeEnum fuelType)
        {
            Id = id;
            MakeModel = makeModel;
            EngineSize = engineSize;
            FuelType = fuelType;

        }

        //constructor of Car from Database
        public Car(SqlDataReader reader) // ex SQL and DataInvalid Ex
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id"));
            MakeModel = reader.GetString(reader.GetOrdinal("MakeModel"));
            EngineSize = reader.GetFloat(reader.GetOrdinal("EngineSize"));
            string fuelTypeStr = reader.GetString(reader.GetOrdinal("FuelType"));
            if (!Enum.TryParse<FuelTypeEnum>(fuelTypeStr, out FuelTypeEnum fuelTypeParsed))
            {
                throw new DataInvalidException("Cannot parse Fuel Type");
            }
            FuelType = fuelTypeParsed;
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
