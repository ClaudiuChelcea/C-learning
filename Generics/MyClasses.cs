using System;

namespace Program
{
    partial class Program
    {
        // Create names
        enum names
        {
            Husky,
            Birmanese
        };

        // Animall class and interface
        public abstract class Animal
        {
            abstract public void Say_Hello();
        }

        interface IAnimalProperties
        {
            public string Type
            {
                get;
                set;
            }
            public int Height
            {
                get;
                set;
            }
            public int Weight
            {
                get;
                set;
            }
        }

        // Inherit class dog
        public class Dog : Animal, IAnimalProperties
        {
            // Override hello method
            public override void Say_Hello()
            {
                Console.WriteLine("WOF! WOF!\n");
            }

            public string Type
            {
                get;
                set;
            }
            public int Height
            {
                get;
                set;
            }
            public int Weight
            {
                get;
                set;
            }

            // Default constructor
            public Dog()
            {
                Type = "default";
                Height = 0;
                Weight = 0;
            }

            // Custom constructor
            public Dog(string dog_Type = "default", int dog_Height = 0, int dog_Weight = 0)
            {
                Type = dog_Type;
                Height = dog_Height;
                Weight = dog_Weight;
            }
        }

        // Inherit class cat
        public class Cat : Animal, IAnimalProperties
        {
            // Override hello method
            public override void Say_Hello()
            {
                Console.WriteLine("Meow! Meow!\n");
            }

            public string Type
            {
                get;
                set;
            }
            public int Height
            {
                get;
                set;
            }
            public int Weight
            {
                get;
                set;
            }

            // Default method
            public Cat()
            {
                Type = "default";
                Height = 0;
                Weight = 0;
            }

            // Custom constructor
            public Cat(string cat_Type = "default", int cat_Height = 0, int cat_Weight = 0)
            {
                Type = cat_Type;
                Height = cat_Height;
                Weight = cat_Weight;
            }
        }

        // Debug class
        public static class Debug
        {
            // Display cat object
            public static void Display_Object(Cat my_cat)
            {
                Console.WriteLine("My animal is {0} cat with height of {1}cm and weight of {2}kg!\n", my_cat.Type, my_cat.Height, my_cat.Weight);
            }
            // Display dog object
            public static void Display_Object(Dog my_dog)
            {
                Console.WriteLine("My animal is {0} dog with height of {1}cm and weight of {2}kg!\n", my_dog.Type, my_dog.Height, my_dog.Weight);
            }

            // Compare values of different data types
            public static void compare_values<Val01, Val02>(Val01 el1, Val02 el2)
            {
                if (el1.Equals(el2))
                    Console.WriteLine("Same values!");
                else
                {
                    Console.WriteLine("Different values!");
                }
            }

            // Compare data types of different values
            public static void compare_data_types<Val01, Val02>(Val01 el1, Val02 el2)
            {
                if (typeof(Val01).Equals(typeof(Val02)))
                    Console.WriteLine("Same data type!");
                else
                    Console.WriteLine("Different data type!");
            }
        }
    }

    // Pair class
    public class my_pair<Tkey, Tval>
    {
        public Tkey my_key;
        public Tval my_val;

        public my_pair() { }

        public my_pair(Tkey aKey, Tval aVal)
        {
            my_key = aKey;
            my_val = aVal;
        }

        public my_pair<Tkey,
        Tval> make_pair(Tkey aKey, Tval aVal)
        {
            my_pair<Tkey, Tval> my_pair = new my_pair<Tkey, Tval>();
            my_pair.my_key = aKey;
            my_pair.my_val = aVal;
            return my_pair;
        }

        public void print_pair()
        {
            Console.WriteLine("My pair key is {0} and the type of the value is {1}!", my_key, my_val.GetType());

        }
    }
}
