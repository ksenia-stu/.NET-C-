using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08BigTodo
{
    public class Todo
    {
        public int Id { get; set; }
        string _task;
        DateTime _dueDate;
        StatusEnum _status;

        public enum StatusEnum {Pending, Done}

        //constructor
        public Todo(int id, string task, DateTime dueDate, StatusEnum status)
        {
            Id = id;
            Task = task;
            DueDate = dueDate;
            Status = status;
        }

        //constructor of Todo from Database
        public Todo(SqlDataReader reader) // ex SQL and InvalidValue Ex
        {

            Id = reader.GetInt32(reader.GetOrdinal("Id"));
            Task = reader.GetString(reader.GetOrdinal("Task"));
            DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate"));
            string statusStr = reader.GetString(reader.GetOrdinal("Status"));
            if (!Enum.TryParse<StatusEnum>(statusStr, out StatusEnum statusParsed))
            {
                throw new InvalidValueException("Cannot parse Status");
            }
            Status = statusParsed;
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
                if (value.Length < 1 || value.Length > 50 || value.Contains(';'))
                {
                    throw new InvalidValueException("Task description must be between 1 and 50 characters without semicolons");
                }
                _task = value;
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
            return string.Format("{0} by {1}, {2}", Task, DueDate.ToShortDateString(), Status);
        }

        public string ToDataString()
        {
            return string.Format("{0};{1};{2}", Task, DueDate.ToShortDateString(), Status);
        }
    }
}
