using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsAndQuerryWithLambda
{
    sealed class Program
    {
        enum Status
        {
            programStarted,
            programFinished
        }
        private static void Main(string[] args)
        {
            // Create a list of persons
            Console.WriteLine("{0}: Created list!\n", Status.programStarted);
            List<Person> people = new List<Person>() {
                new Person {
                    Name = "Alex", Age = 18, Salary = 1839.25m
                },
                new Person {
                    Name = "George", Age = 23, Salary = 3452.25m
                },
                new Person {
                    Name = "Mara", Age = 15, Salary = 983.2m
                },
                new Person {
                    Name = "Maria", Age = 29, Salary = 4053.64m
                },
                new Person {
                    Name = "Claudiu", Age = 21, Salary = 2000.00m
                }
            };

            // Display each person after sorting the list by name
            Console.WriteLine("Sorted list by name:");
            var sorted_people = people.OrderBy(item => item.Name);
            foreach (var item in sorted_people)
            {
                Console.WriteLine("Person {0} of age {1} has a salary of {2:C}", item.Name, item.Age, item.Salary);
            }

            // Add each person to a dictionary
            Console.WriteLine("\nAdd persons to dictionary.");
            Dictionary<string, Person> my_dict = new Dictionary<string, Person>();
            people.ForEach(item => my_dict.Add(item.Name, item));
            people.ForEach(item => Console.WriteLine("Added person {0} to dictionary", item.Name));

            // Return all people with salary between 1000 and 2500
            Console.WriteLine("\nReturn all people with salary between {0:C} and {1:C}", 1000, 2500);
            var medium_people = sorted_people.Where(item => item.Salary >= 1000m && item.Salary <= 2500m);
            foreach (var person in medium_people)
            {
                Console.WriteLine("Person {0} with salary of {1:C}.", person.Name, person.Salary);
            }

            // Print elements by name using dictionary
            Console.WriteLine("\nPrint element's name and age using the dict.");
            foreach (var person in people)
            {
                string name = person.Name;
                Console.WriteLine("{0} --- {1}", my_dict[name].Name, my_dict[name].Age);
            }
            Console.WriteLine("\n{0}", Status.programFinished);
        }
    }

    class Person
    {
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public decimal Salary
        {
            get;
            set;
        }
    }
}
