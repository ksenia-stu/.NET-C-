using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10FirstEF
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SocietyDbContext context = new SocietyDbContext();
                Random random = new Random();

                Person p1 = new Person() { Name = "Jerry", Age = random.Next(100) };
                context.People.Add(p1);  //insert operation is scheduled but not executed
                context.SaveChanges();// synchronize objects in memory with database
                Console.WriteLine("Record added");

                //update  (fetch and modify, then save changes)
                Person p2 = (from p in context.People where p.Id == 2 select p).FirstOrDefault<Person>(); //if there is at least 1 record then give first of them, if not give null
                if(p2 != null)
                {
                    //found record to update
                    p2.Name = "Alabama" + (random.Next(10000) + 10000);
                    context.SaveChanges();// synchronize objects in memory with database
                    Console.WriteLine("Record updated");
                }
                else
                {
                    Console.WriteLine("Record to update not found");
                }

                //delete (fetch and scedule for deletinn then save changes)
                Person p3 = (from p in context.People where p.Id == 3 select p).FirstOrDefault<Person>();
                if(p3 != null)
                {
                    context.People.Remove(p3);
                    context.SaveChanges();
                    Console.WriteLine("Record deleted");
                }
                else
                {
                    Console.WriteLine("Record to delete not found");
                }

                //get all records
                List<Person> peopleList = (from p in context.People select p).ToList<Person>();
                foreach(Person p in peopleList)
                {
                    Console.WriteLine($"{p.Id}: {p.Name} is {p.Age} y/o");
                }


            }
            catch(SystemException ex) //catch all for EF, SQL and mmany other exceptions
            {
                Console.WriteLine("Database operation failed: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Pless any key");
                Console.ReadKey();
            }
        }
    }
}
