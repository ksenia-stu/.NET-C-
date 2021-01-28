using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01PeopleListInFile
{


    

    class Program
    {
        //file name
        public const string FileName = "people.txt";

        //data will be loaded into this list from file
        static List<Person> people = new List<Person>();

        static void ReadAllPeopleFromFile()
        {
            string[] lines;

            try
            {
                //read each line from file and save into string array
                lines = System.IO.File.ReadAllLines(FileName);  //file not found exception

                if (lines.Length <= 0)
                {

                    throw new FormatException("The file is empty");

                }
                string[] words = null;
                //separate each line into words (strings)
                for (int i = 0; i < lines.Length; i++)
                {
                    words = lines[i].Split(';');

                    if (words.Length != 3)
                    {
                        throw new FormatException("The file has wrong data structure");
                    }
                    string name = words[0];
                    int age;
                    int.TryParse(words[1], out age);

                    string city = words[2];

                    Person person = new Person(name, age, city);  //ArgumentException

                    people.Add(person);
                }
                

               // Console.WriteLine(person);
            }
            catch(System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("Error: "+ex.Message);
                Console.ReadKey();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
            }

        }

        static void SaveAllPeopleToFile()
        {
            try
            {
                using (TextWriter tw = new StreamWriter("people.txt"))
                {
                    foreach (Person p in people)
                        tw.WriteLine(p.ToDataString());
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            
        }


        static void AddPersonInfo()
        {
            Person person;
            
                Console.WriteLine("Adding a person");
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter age: ");
                int age;
                int.TryParse(Console.ReadLine(), out age);
                Console.Write("Enter city: ");
                string city = Console.ReadLine();
            try
            {
                person = new Person(name, age, city);
                people.Add(person);
                Console.WriteLine("Person added");

            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Error: " +ex.Message);
            }
            
            
        }
        static void ListAllPersonsInfo()
        {
            foreach(Person p in people)
            {
                Console.WriteLine(p);
               
            }
            
        }
        static void FindPersonByName()
        {
            Console.Write("Enter partial person name: ");
            string namePart = Console.ReadLine();
            Console.WriteLine("Matches found:");

            foreach(Person p in people)
            {
                if(p.Name.Contains(namePart))
                {
                    Console.WriteLine(p);
                }
            }

        }
        static void FindPersonYoungerThan()
        {
            Console.Write("Enter maximum age: ");
            int age;
            int.TryParse(Console.ReadLine(), out age);

            Console.WriteLine("Matches found:");

            foreach (Person p in people)
            {
                if (p.Age < age)
                {
                    Console.WriteLine(p);
                }
            }
        }

        private static int getMenuChoice()
        {
            while(true)
            {
                Console.Write(@"1. Add person info
2. List persons info
3. Find a person by name
4. Find all persons younger than age
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

        static void Main(string[] args)
        {
            try
            {
                //load all people from file to people list
                ReadAllPeopleFromFile();

              //  int choice= 9;

                while (true)
                {
                    int choice = getMenuChoice();
                    switch (choice)
                    {
                        case 1:
                            AddPersonInfo();
                            break;
                        case 2:
                            ListAllPersonsInfo();
                            break;
                        case 3:
                            FindPersonByName();
                            break;
                        case 4:
                            FindPersonYoungerThan();
                            break;
                        case 0:
                            SaveAllPeopleToFile();
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Wrong choice, please enter valid number");
                            break;
                    }
                }
            }
            finally
            {
                Console.ReadKey();
            }
            
         
            



            //  SaveAllPeopleToFile();


            // Console.WriteLine(people);
            
         /*   while(true)
            {
                //show the menu and ask users choice
                int choice = getMenuChoice();
            } */
        }
    }
}
