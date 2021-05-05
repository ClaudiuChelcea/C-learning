using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Program
{
    class MainProgram
    {
        private static void Main()
        {
            // Tools.Debug.Test_OUTPUT();
            Console.WriteLine("Scan 3 users:\n");

            // Initialise user's list
            SuperUser root = new SuperUser();

            // Add 3 users
            for (int i = 0; i < 3; i++)
                root.add_user();

            // Display the 3 users
            SuperUser.display_users();

            // Remove one of the users
            Console.WriteLine("Remove first user:");
            User first_user = root.get_first_user();
            root.remove_user(first_user);

            // Display the remaining users
            Console.WriteLine("Users left:");
            SuperUser.display_users();
        }
    }

    // User class
    public class User
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
        public string Gender
        {
            get;
            set;
        }

        // Default user constructor
        public User()
        {
            this.Name = "N/A";
            this.Age = -1;
            this.Gender = "N/A";
        }

        // User constructor
        public User(string Name = "N/A", int Age = -1, string Gender = "N/A")
        {
            this.Name = Name;
            this.Age = Age;
            this.Gender = Gender;
        }

        // Scan user
        public void ReadUser()
        {
            // Get name
            Console.Write("Name: ");
            this.Name = Console.ReadLine();
            Console.WriteLine();

            // Get age
            Console.Write("Age: ");
            try
            {
                this.Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
            catch (Exception my_exception)
            {
                Console.WriteLine("Your exception was: " + my_exception.Message + "\n");
                ReadUser();
                return;
            }

            // Get gender
            Console.Write("Gender (male | female | other): ");
            this.Gender = Console.ReadLine();
            Console.WriteLine();

            // Check input
            if (check_input(this.Name, this.Age, this.Gender) == false)
                ReadUser();
        }

        // Check if the user is valid
        private bool check_input(string Name = "N/A", int Age = -1, string Gender = "N/A")
        {
            if (Name.Length < 4)
            {
                Console.WriteLine("Insert a longer name!\n");
                return false;
            }
            else if (Age < 0 || Age > 150)
            {
                Console.WriteLine("Insert a correct age!\n");
                return false;
            }
            else if (Gender.Length < 3)
            {
                Console.WriteLine("Insert a longer gender!\n");
                return false;
            }
            else if (Gender != "male" && Gender != "female" && Gender != "other")
            {
                Console.WriteLine("Input not accepted\n");
                return false;
            }

            Console.WriteLine("Scanned user succesfully!\n");
            return true;
        }
    }

    // Advanced user
    public class SuperUser : User
    {
        // Hold a list of the current users
        public static List<User> my_users = new List<User>();

        // Add user
        public void add_user()
        {
            User my_user = new User();
            my_user.ReadUser();
            my_users.Add(my_user);
        }

        // Remove user
        public void remove_user(User user_to_remove)
        {
            string user_name = "";
            while (my_users.Contains(user_to_remove))
            {
                user_name = user_to_remove.Name;
                my_users.Remove(user_to_remove);
            }

            Console.WriteLine($"Removed first user. His name was {user_name}\n");
        }

        // Show the users
        public static void display_users()
        {
            var list = my_users.Select(el => el);
            foreach (var user in list)
            {
                Console.WriteLine($"UserName: {user.Name}\nAge: {user.Age}\nGender: {user.Gender}\n");
            }
        }

        // Get first user
        public User get_first_user()
        {
            var list = my_users.Select(el => el);
            return list.First<User>();
        }
    }
}

namespace Tools
{
    class Debug
    {
        public static void Test_OUTPUT()
        {
            const string debug_Message = "Hello World!";
            System.Console.WriteLine($"{debug_Message}");
        }
    }
}
