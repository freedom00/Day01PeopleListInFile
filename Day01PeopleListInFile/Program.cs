using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day01PeopleListInFile
{
    internal class Program
    {
        private const string PATH = @"..\..\person.txt";
        private static List<Person> people = new List<Person>();

        private enum PersonInfo { Name, Age, City };

        private static void AddPersionInfo()
        {
            try
            {
                Person person = new Person();
                Console.WriteLine("Adding a person.");
                Console.Write("Enter name: ");
                person.Name = Console.ReadLine();
                Console.Write("Enter age: ");
                person.Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter city: ");
                person.City = Console.ReadLine();
                people.Add(person);
                Console.WriteLine("Person added.\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine();
            }
        }

        private static void ListAllPersonsInfo()
        {
            Console.WriteLine("Listing all persons");
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine();
        }

        private static void FindPersonByName()
        {
            Console.WriteLine("Enter partial person name:");
            string tempName = Console.ReadLine();
            Console.WriteLine("Matches found:");
            var peopleContainName = from p in people where p.Name.Contains(tempName) select p;
            foreach (Person person in peopleContainName)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine();
        }

        private static void FindPersonYoungerThan()
        {
            Console.WriteLine("Enter maximum age:");
            int tempAge;
            if (!int.TryParse(Console.ReadLine(), out tempAge))
            {
                Console.WriteLine("Age must be 0-150.\n");
                return;
            }
            Console.WriteLine("Matches found:");
            var peopleUnderAge = from p in people where p.Age < tempAge select p;
            foreach (Person person in peopleUnderAge)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine();
        }

        private static void ReadAllPeopleFromFile()
        {
            try
            {
                String[] lines = File.ReadAllLines(PATH);
                foreach (string s in lines)
                {
                    string[] temp = s.Split(';');
                    people.Add(new Person(temp[(int)PersonInfo.Name], Convert.ToInt32(temp[(int)PersonInfo.Age]), temp[(int)PersonInfo.City]));
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine();
            }
        }

        private static void SaveAllPeopleToFile()
        {
            try
            {
                File.WriteAllText(PATH, string.Empty);
                foreach (Person person in people)
                {
                    File.AppendAllText(PATH, person.ToFileString() + "\n");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine();
            }
        }

        private static int ShowMenu()
        {
            int choice;
            bool isContinue;
            do
            {
                Console.WriteLine("What do you want to do?\n1. Add person info\n2.List persons info\n3.Find a person by name\n4.Find all persons younger than age\n0.Exit");
                Console.Write("Choice: ");
                isContinue = false;
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
                {
                    Console.WriteLine("Invalid choice try again.\n");
                    isContinue = true;
                }
            } while (isContinue);
            Console.WriteLine();
            return choice;
        }

        private static void ChoiceMenu()
        {
            int choice;
            do
            {
                choice = ShowMenu();
                switch (choice)
                {
                    case 1:
                        AddPersionInfo();
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
                        break;

                    default:
                        choice = 0;
                        SaveAllPeopleToFile();
                        break;
                }
            } while (choice != 0);
            Console.WriteLine("\nGood bye!");
        }

        private static void Main(string[] args)
        {
            ReadAllPeopleFromFile();
            ChoiceMenu();

            Console.ReadKey();
        }
    }
}