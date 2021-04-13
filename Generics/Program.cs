using System;
using System.Collections.Generic;

namespace Program
{
    partial class Program
    {
        private static void Main(string[] args)
        {
            // Create dog instance and display it
            Dog my_dog = new Dog(names.Husky.ToString(), 30, 40);
            Debug.Display_Object(my_dog);

            // Create cats and display them
            List<Cat> my_cats = new List<Cat> {
                new Cat {
                    Type = "Birmanese", Height = 20, Weight = 15
                },
                new Cat {
                    Type = "British shorthair", Height = 30, Weight = 19
                },
                new Cat {
                    Type = "Sphynx", Height = 35, Weight = 10
                }
            };

            foreach (var cat in my_cats)
            {
                Debug.Display_Object(cat);
            }

            // Associate the dog with a name
            my_pair<string, Dog> myDOG = new my_pair<string, Dog>("Alex", my_dog);
            myDOG.print_pair();
            Console.WriteLine();

            // Compare a cat and a dog
            Console.WriteLine("Comparing a cat and a dog...");
            Debug.compare_values(my_cats[0], my_dog);
            Debug.compare_data_types(my_cats[0], my_dog);
            Console.WriteLine();

            // Compare two cats
            Console.WriteLine("Comparing two different cats...");
            Debug.compare_values(my_cats[0], my_cats[1]);
            Debug.compare_data_types(my_cats[0], my_cats[1]);
            Console.WriteLine();

            // Compare same object
            Console.WriteLine("Comparing the dog with himself...");
            Debug.compare_values(my_dog, my_dog);
            Debug.compare_data_types(my_dog, my_dog);
            Console.WriteLine();

            // End the program
            Console.WriteLine("\nPress any key to end the program...");
            Console.ReadKey();

        }
    }
}
