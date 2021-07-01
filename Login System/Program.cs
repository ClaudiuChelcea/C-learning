using System;
using UserNamespace;

sealed class Program
{
    [STAThread]
    static void Main()
    {
        // Display a simple greeting
        Debug.Greeting();

        // Prompt for a fresh start of the program
        Debug.Prompt_fresh_start();

        // Check user existence
        User.CheckForUsers();

        // Login into one of the accounts saved in the database
        User.LoginMenu();

        // Get all the users in the file in display them
        User.DisplayUsers();

        // Prevent autoclose
        Console.WriteLine("Press any key to quit...");
        Console.ReadKey();
    }
}
