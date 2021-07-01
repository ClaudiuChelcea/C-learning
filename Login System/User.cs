using System;
using System.IO;
using UserNamespace;

namespace UserNamespace
{
    sealed public class User : Person
    {
        // Fields for the user
        const string file_name = "users_file.txt";
        private string Password
        {
            get;
            set;
        }
        public static int ID
        {
            get;
            set;
        }

        // Constructor
        public User()
        {
            ResetUser(this);
        }

        public User(string UserName, decimal Salary, int Age, bool IsMarried, string Password, int ID_x) :
            base(UserName, Salary, Age, IsMarried)
        {
            this.Password = Password;
            ID = ID_x;
        }

        // Read user
        public static User ScanUser()
        {
            User my_user = new();
            try
            {
                // Create fields
                Console.Write("Username: ");
                my_user.UserName = Console.ReadLine();
                while (my_user.UserName.Length < 3)
                {
                    Console.Write("\nUsername too short, minimum 3 characters! Try again! Username: ");
                    my_user.UserName = Console.ReadLine();
                }

                Console.Write("Salary: ");
                my_user.Salary = Convert.ToDecimal(Console.ReadLine());
                while (my_user.Salary < 0)
                {
                    Console.Write("Salary can't be negative! Try again! Salary: ");
                    my_user.Salary = Convert.ToDecimal(Console.ReadLine());
                }

                Console.Write("Age: ");
                my_user.Age = Convert.ToInt32(Console.ReadLine());
                while (my_user.Age < 0 || my_user.Age > 150)
                {
                    Console.Write("\nInvalid age! Try again! Age: ");
                    my_user.Age = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("Are you married? (true/false): ");
                my_user.IsMarried = Convert.ToBoolean(Console.ReadLine());

                Console.Write("Password: ");
                my_user.Password = Console.ReadLine();
                while (my_user.Password.Length < 5)
                {
                    Console.Write("\nPassword too short, minimum 5 characters! Try again!\nPassword: ");
                    my_user.Password = Console.ReadLine();
                }

                ++ID;

                // Validate input
                Debug.Validate_Message("User created successfully!");
                return my_user;
            }
            catch
            {
                // Invalidate input
                Debug.Invalidate_Message("Error! Couldn't receive input correctly! Try again!");
                return ScanUser();
            }
        }

        // Clear user`s fields
        static private void ResetUser(User my_user)
        {
            my_user.Age = 0;
            my_user.IsMarried = false;
            my_user.Password = "";
            my_user.Salary = 0m;
            my_user.UserName = "";
        }

        // Display user`s fields
        static public void PrintUser(User user_to_print)
        {
            // Check if the user exists
            if (user_to_print == null)
            {
                Debug.Invalidate_Message("User doesn't exist!");
                return;
            }

            // Create fields
            Console.WriteLine($"Username: {user_to_print.UserName}");
            Console.WriteLine($"Salary: {user_to_print.Salary}$");
            Console.WriteLine($"Age: {user_to_print.Age}");
            Console.WriteLine($"Are you married?: {user_to_print.IsMarried}");
            Console.WriteLine($"Password: {user_to_print.Password}");
            Console.WriteLine($"ID: 00{ID}");
        }

        // Put user in a file
        public static void RegisterUser()
        {
            User my_user = ScanUser();
            LogUserToFile(file_name, my_user);
        }

        // Put user in a file
        static void LogUserToFile(string outputFile, User my_user)
        {
            string outputText = "Username: " + my_user.UserName +
                "\nSalary: " + Convert.ToString(my_user.Salary) +
                "\nAge: " + my_user.Age.ToString() +
                "\nAre you married?: " + my_user.IsMarried.ToString() +
                "\nPassword: " + my_user.Password.ToString() +
                "\nID: 00" + User.ID.ToString() + "\n";

            File.AppendAllText(outputFile, outputText);
        }

        // Check if we want to insert more users
        public static void PromptRegisterAnotherUser()
        {
            while (true)
            {
                Console.WriteLine("Do you want to add another user? (true / false): ");
                try
                {
                    bool answer = Convert.ToBoolean(Console.ReadLine());
                    if (answer == true)
                    {
                        RegisterUser();
                    }
                    else
                    {
                        return;
                    }
                }
                catch
                {
                    Debug.Invalidate_Message("Couldn't resolve your answer! Try again ( true / false )!");
                    PromptRegisterAnotherUser();
                    return;
                }
            }
        }

        static bool CheckUserExists(string name)
        {
            // Get the content of the file
            string file_content = File.ReadAllText(file_name);

            // Check if the name is in the file
            if (file_content.Contains(name))
                return true;
            return false;
        }

        static public User ReturnUserByName(string name)
        {
            if (!CheckUserExists(name))
            {
                return null;
            }
            else
            {
                // Get the content of the file
                string file_content = File.ReadAllText(file_name);

                // Create user
                string get_Username = "Username: " + name;
                string get_substring = file_content.Substring(file_content.IndexOf(get_Username));

                // Get user`s data
                string user_name = get_substring.Substring(get_substring.LastIndexOf(get_Username) + 10, get_substring.IndexOf("Salary: ") - 10);
                string user_salary = get_substring.Substring(get_substring.LastIndexOf("Salary: ") + 8, get_substring.IndexOf("Age: ") - get_substring.IndexOf("Salary: ") - 8);
                string user_age = get_substring.Substring(get_substring.IndexOf("Age: ") + 5, get_substring.IndexOf("Are you married?: ") - get_substring.IndexOf("Age: ") - 5);
                string user_married_status = get_substring.Substring(get_substring.IndexOf("Are you married?: ") + 18, get_substring.IndexOf("Password: ") - get_substring.IndexOf("Are you married?: ") - 18);
                string user_password = get_substring.Substring(get_substring.IndexOf("Password: ") + 10, get_substring.IndexOf("ID: ") - get_substring.IndexOf("Password: ") - 10);
                string user_id = get_substring.Substring(get_substring.IndexOf("ID: ") + 4, 3);

                // Create and return the user
                User my_user = new(user_name, Convert.ToDecimal(user_salary), Convert.ToInt32(user_age),
                    Convert.ToBoolean(user_married_status), user_password, Convert.ToInt32(user_id));
                return my_user;
            }
        }

        // Check if we have users, and, if we dont, create them
        public static void CheckForUsers()
        {
            if (!File.Exists(file_name))
            {
                Console.WriteLine("No users found! Register...");
                RegisterUser();
                PromptRegisterAnotherUser();
            }
        }

        // Login menu
        public static void LoginMenu()
        {
            Console.WriteLine("\nPick operation: 1. Login | 2. Register new user | 3. Quit");
            Console.WriteLine("Type '1', '2' or '3'!");
            int operation = 0;

            try
            {
                operation = Convert.ToInt32(Console.ReadLine());
                if (operation != 1 && operation != 2)
                    throw new ApplicationException();
            }
            catch (ApplicationException)
            {
                Debug.Invalidate_Message("Invalid operation! Quiting...");
                Environment.Exit(0);
            }
            catch
            {
                Debug.Invalidate_Message("Unrecognized input! Quiting...");
                Environment.Exit(0);
            }

            if (operation == 2)
            {
                RegisterUser();
                PromptRegisterAnotherUser();
                Console.WriteLine("\nDo you want to login now? (true / false): ");
                bool answer;
                try
                {
                    answer = Convert.ToBoolean(Console.ReadLine());
                    if (answer == false)
                    {

                        Debug.Validate_Message("Sorry to see you go!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        TryLogin();
                    }
                }
                catch
                {
                    Debug.Invalidate_Message("Couldn't solve input! Try again: ");
                    answer = Convert.ToBoolean(Console.ReadLine());
                    while (answer != false || answer != true)
                    {
                        Debug.Invalidate_Message("Invalid answer!");
                        answer = Convert.ToBoolean(Console.ReadLine());
                    }
                }

            }
            else if (operation == 1)
            {
                TryLogin();
            }
            else if (operation == 3)
            {
                Debug.Validate_Message("Sorry to see you go!");
                Environment.Exit(0);
            }
            else
            {
                Debug.Invalidate_Message("Unrecognized operation! Quiting...");
                Environment.Exit(0);
            }
        }

        // Try logging in
        private static void TryLogin()
        {
            try
            {
                // Get credientials
                Debug.Validate_Message("\nLogin prompt:");
                Console.Write("Username: ");
                string name = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                // Get the user from the file(if it exists)
                User my_user = ReturnUserByName(name);

                if (my_user == null || Convert.ToInt32(Debug.Strncmp(name, my_user.UserName, my_user.UserName.Length - 1)) != 0 || Convert.ToInt32(Debug.Strncmp(password, my_user.Password, my_user.Password.Length - 1)) != 0)
                {
                    Debug.Invalidate_Message("Invalid account!");

                    bool try_again = false;
                    try
                    {
                        Console.WriteLine("Would you like to try again? (true / false): ");
                        try_again = Convert.ToBoolean(Console.ReadLine());
                        if (try_again == true)
                            TryLogin();
                        else
                        {
                            Debug.Validate_Message("Sorry to see you go!");
                            Environment.Exit(0);
                        }
                    }
                    catch
                    {
                        Debug.Invalidate_Message("Could not resolve input! Quiting...");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Debug.Validate_Message("Connected successfully!");
                    Console.WriteLine("Logged in as: ");
                    PrintUser(my_user);
                }

            }
            catch (Exception exception)
            {
                Debug.Invalidate_Message("Couldn't resolve input! Quiting...");
                Console.WriteLine("Exception thrown: " + exception.Message);
                Environment.Exit(0);
            }

        }

        // Get all users from the file
        static private User[] ReturnUsersFromFile()
        {
            // Create Users array
            User[] users = new User[20];
            int user_index = 0;

            System.IO.StreamReader file = new(file_name);
            string line;
            int step = 0;

            string username = "";
            decimal salary = 0m;
            int age = 0;
            bool married = false;
            string password = "";
            int id = 0;
            while ((line = file.ReadLine()) != null)
            {
                if (step % 6 == 0)
                    username = line.Substring(10);
                else if (step % 6 == 1)
                    salary = Convert.ToDecimal(line.Substring(8));
                else if (step % 6 == 2)
                    age = Convert.ToInt32(line.Substring(5));
                else if (step % 6 == 3)
                    married = Convert.ToBoolean(line.Substring(18));
                else if (step % 6 == 4)
                    password = line.Substring(10);
                else if (step % 6 == 5)
                    id = Convert.ToInt32(line.Substring(4));

                step++;
                if (step == 6)
                {
                    step = 0;
                    users[user_index++] = new User(username, salary, age, married, password, id);
                }
            }

            file.Close();

            return users;
        }

        // Display all users from the file
        public static void DisplayUsers()
        {
            Console.WriteLine("\n\nPrinting all users:");
            User[] array_of_users = ReturnUsersFromFile();
            if (array_of_users == null)
            {
                Debug.Invalidate_Message("No users found to display!");
                return;
            }

            // Print each user from the array
            foreach (var user in array_of_users)
            {
                if (user == null)
                    return;

                PrintUser(user);
                Console.WriteLine();
            }
        }
    }
}
