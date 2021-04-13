using System;
using System.IO;

namespace Program
{
    class Program
    {
        static public void Main()
        {
            // Declare variables
            string userName = "";
            string userPassword = "";
            int age = 0;
            string input = "";

            // Create file with user's input
            Console.WriteLine("====== CREATE ACCOUNT ======");
            Console.WriteLine();

            // Try receiving input
            PasswordChecker.try_receiving_input(ref userName, ref userPassword, ref age, ref input);

            // Log in based on credentials
            Console.WriteLine("\n====== LOG IN ======");
            Console.WriteLine();

            // Try logging in
            PasswordChecker.try_logging_in();

            // Stop program
            Console.WriteLine("\nPress any key to finish the program...");
            Console.ReadKey();
        }
    }
}
