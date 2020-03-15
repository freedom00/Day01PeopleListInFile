using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01PeopleListInFile
{
    internal class Person
    {
        private string name;
        private int age;
        private string city;

        public Person()
        {
        }

        public Person(string name, int age, string city)
        {
            Name = name;
            Age = age;
            City = city;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length >= 2 && value.Length <= 100 && !value.Contains(";"))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Name must be 2-100 characters long, not containing semicolons.");
                }
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value >= 0 && value <= 150)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Age must be 0-150.");
                }
            }
        }

        public string City
        {
            get => city;
            set
            {
                if (value.Length >= 2 && value.Length <= 100 && !value.Contains(";"))
                {
                    city = value;
                }
                else
                {
                    throw new ArgumentException("City must be 2-100 characters long, not containing semicolons");
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0} is {1} from {2}", Name, Age, City);
        }

        public virtual string ToFileString()
        {
            return string.Format("{0};{1};{2}", Name, Age, City);
        }
    }
}