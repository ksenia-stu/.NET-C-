using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Day10TodosEntity
{
    public class Todo
    {
        public int Id { get; set; }
        [Required] //non null
        [StringLength(100)]  //nvarchar(50)
        string _task;
        int _difficulty;
        DateTime _dueDate;
        [EnumDataType(typeof(StatusEnum))]
        StatusEnum _status;

        public enum StatusEnum { Peding, Done, Delegated }

        



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
                if (value < 1 || value > 5)
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

    }
}
