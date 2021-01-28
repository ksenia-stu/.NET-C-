using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05TodoInFile
{
	public class Todo
	{
		string _task;
		int _difficulty;
		DateTime _dueDate;
		StatusEnum _status;

		public enum StatusEnum { Peding, Done, Delegated }

        //constructor
        public Todo(string task, int difficulty, DateTime dueDate, StatusEnum status)
        {
            Task = task;
            Difficulty = difficulty;
            DueDate = dueDate;
            Status = status;
        }

        //constructor from dataline
        public Todo(string dataLine)
        {
            string[] words = dataLine.Split(';');
            if (words.Length != 4)
            {
                throw new InvalidValueException("Wrong data structure: " + dataLine);
            }
            //task
            Task = words[0];

            //duedate
            DateTime dueDate;
            if (!DateTime.TryParse(words[1],
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dueDate))
            {
                throw new InvalidValueException("Due Date must be a date: " + dataLine);
            }
            DueDate = dueDate;

            //difficulty
            int difficulty;
            if (!int.TryParse(words[2], out difficulty))
            {
                throw new InvalidValueException("Difficulty must be a number: " + dataLine);
            }
            Difficulty = difficulty;

            
            //DO WE NEED TO VALIDATE 2 TIMES?????
            //status
            if(!Enum.TryParse(words[3], out StatusEnum status))
            {
                throw new InvalidValueException("Status has wrong format: " + dataLine);
            }
            Status = status;

        }


        //task
        public string Task  
        {
            get
            {
                return _task;
            }
            set
            {
                if (value.Contains(';'))
                {
                    throw new InvalidValueException("Task description must not contain semicolons");
                }
                _task = value;
            }
        }

        //difficulty
        public int Difficulty
        {
            get
            {
                return _difficulty;
            }
            set
            {
                if (value < 1 || value >5)
                {
                    throw new InvalidValueException("Diificulty must be between 1 and 5");
                }
                _difficulty = value;
            }
        }

        //duedate
        public DateTime DueDate
        {
            get
            {
                return _dueDate;
            }
            set
            {
             /*   if (value.Year < 1900 || value.Year > 2020)
                {
                    throw new InvalidValueException("Year must be between 1900 and 2020");
                } */
                _dueDate = value;
            }
        }

        //status
        public StatusEnum Status { get => _status; set => _status = value; }


        public override string ToString()
        {
            return string.Format("{0} by {1} /diff.{2}, {3}", Task, DueDate.ToShortDateString(), Difficulty, Status);
        }

        public virtual string ToDataString()
        {
            return string.Format("{0};{1};{2};{3}", Task, DueDate.ToShortDateString(), Difficulty, Status);
        }
    }
}
