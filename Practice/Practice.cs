using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Program
{
    sealed class MainProgram
    {
        private static void Main()
        {
            Tools.Debug.Test_OUTPUT();

            Console.WriteLine("Scan 3 users.\n");

            // Initialise user's list
            SuperUser root = new SuperUser();

            // Add 3 users
            for (int i = 0; i < 3; i++)
                root.add_user();

            // Display the 3 users
            root.display_users();

            // Remove one of the users
            Console.WriteLine("===================");
            Console.WriteLine("Remove first user:");
            User first_user = root.get_first_user();
            root.remove_user(first_user);

            // Display the remaining users
            Console.WriteLine("\nUsers left:");
            root.display_users();

            // Clear users
            Console.WriteLine("===================");
            Console.WriteLine("Removing all users, adding guest users...");
            while (root.my_users.Count > 0)
                root.remove_user(root.get_first_user());
            Console.WriteLine("\nCheck if list is empty:");
            root.display_users();

            // Add guest users
            Console.WriteLine("\nAdd 3 guest users");
            for (int i = 0; i < 3; i++)
                root.add_guest();
            Console.WriteLine("Displaying guests...");
            root.display_guests();
            Console.WriteLine("\nCleaning guests...");
            while (root.my_guests.Count > 0)
                root.remove_guest(root.get_first_guest());
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
        public virtual void ReadUser()
        {
            // Get name
            Console.Write("Name: ");
            this.Name = Console.ReadLine();

            // Get age
            Console.Write("Age: ");
            try
            {
                this.Age = Convert.ToInt32(Console.ReadLine());
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

            // Check input
            if (check_input(this.Name, this.Age, this.Gender) == false)
                ReadUser();
        }

        // Check if the user is valid
        public virtual bool check_input(string Name = "N/A", int Age = -1, string Gender = "N/A")
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

    // Guest
    public class Guest : User
    {
        // Scan guest
        public override void ReadUser()
        {
            // Get name
            Console.Write("Name: ");
            this.Name = Console.ReadLine();

            // Check input
            if (check_input(this.Name, this.Age, this.Gender) == false)
                ReadUser();
        }

        // Check if the guest is valid
        public override bool check_input(string Name = "N/A", int Age = -1, string Gender = "N/A")
        {
            if (Name.Length < 4)
            {
                Console.WriteLine("Insert a longer name!\n");
                return false;
            }

            Console.WriteLine("Scanned guest succesfully!\n");
            return true;
        }
    }

    // Advanced user
    public class SuperUser : User
    {
        // Hold a list of the current users
        public List<User> my_users = new List<User>();

        // Hold a list of the current guest users
        public List<Guest> my_guests = new List<Guest>();

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

            Console.WriteLine($"Removed first user. His name was {user_name}");
        }

        // Show the users
        public void display_users()
        {
            var list = my_users.Select(el => el);
            if (list.Count() == 0)
            {
                Console.WriteLine("No users!");
                return;
            }
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

        // Add guest
        public void add_guest()
        {
            Guest my_guest = new Guest();
            my_guest.ReadUser();
            my_guests.Add(my_guest);
        }

        // Remove guest
        public void remove_guest(Guest guest_to_remove)
        {
            string guest_name = "";
            while (my_guests.Contains(guest_to_remove))
            {
                guest_name = guest_to_remove.Name;
                my_guests.Remove(guest_to_remove);
            }

            Console.WriteLine($"Removed first guest. His name was {guest_name}");
        }

        // Show the guests
        public void display_guests()
        {
            var list = my_guests.Select(el => el);
            if (list.Count() == 0)
            {
                Console.WriteLine("No guest users!");
                return;
            }
            foreach (var guest in list)
            {
                Console.WriteLine($"UserName: {guest.Name}");
            }
        }

        // Get first guest
        public Guest get_first_guest()
        {
            var list = my_guests.Select(el => el);
            return list.First<Guest>();
        }
    }
}

namespace Tools
{
    class Debug
    {
        public static void Test_OUTPUT()
        {
            const string debug_Message = "==============================\n            START           \n==============================\n";
            System.Console.WriteLine($"{debug_Message}");
        }
    }
}
