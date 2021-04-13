using System;
using System.IO;

namespace Program
{
    static class PasswordChecker
    {
        static public bool try_receiving_input(ref string userName, ref string userPassword, ref int age, ref string input)
        {
            bool is_valid = false;
            try
            {
                is_valid = false;
                // Get values
                Console.Write("Username: ");
                while (is_valid == false)
                {
                    userName = Console.ReadLine();
                    if (userName.Length < 5)
                        Console.WriteLine("Please enter a longer name:");
                    else if (userName != "")
                        is_valid = true;
                    else
                    {
                        Console.Write("Please enter a valid username:");

                    }
                }
                Console.WriteLine();
                is_valid = false;
                Console.Write("Password: ");
                while (is_valid == false)
                {
                    userPassword = Console.ReadLine();

                    if (userPassword.Length < 5)
                        Console.Write("Please enter a stronger password:");
                    else if (userPassword != "")
                        is_valid = true;
                    else
                        Console.Write("Please enter a valid password:");
                }
                Console.WriteLine();
                is_valid = false;
                Console.Write("Age: ");
                while (is_valid == false)
                {
                    age = Convert.ToInt32(Console.ReadLine());
                    if (age <= 0 || age > 130)
                        Console.Write("Please enter a valid age:");
                    else
                        is_valid = true;
                }

                // Put the values in the file
                input = $"Username: {userName}\nPassword: {userPassword}\nAge: {age}";
                File.WriteAllText("UserAccount.txt", input);
                Console.WriteLine("\nSuccesfully saved credentials. You can now log in!");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't receive input correctly!\n");
                Console.WriteLine($"Error message {e.Message}");
                return false;
            }
        }

        static public void try_logging_in()
        {
            // Get input from file
            string my_input = File.ReadAllText("UserAccount.txt");

            // Get new login input;
            string userName;
            string userPassword;
            int age;
            string new_input;

            // Check credentials    
            while (true)
            {
                // Get input
                Console.Write("Username: ");
                userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Password: ");
                userPassword = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Age: ");
                age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                new_input = $"Username: {userName}\nPassword: {userPassword}\nAge: {age}";

                if (my_input == new_input)
                {
                    Console.WriteLine("Logged in successfully!");
                    break;
                }
                else
                {
                    Console.WriteLine("Login failed!");
                    loop:
                    Console.WriteLine("Try again? Type \"yes\" or \"no\"");
                    string userWantsToContinue = Console.ReadLine();
                    if (userWantsToContinue.ToLower() == "yes")
                    {
                        continue;
                    }
                    else if(userWantsToContinue.ToLower() == "no")
                    {
                        Console.WriteLine("Sorry to see you go!");
                        break;
                    }
                    else
                    {
                        Console.Write("Invalid input! Try again:");
                        goto loop;
                    }
                }
            }
        }
    }
}
