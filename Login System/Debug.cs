using System;

static class Debug
{
    // Display message with green
    public static void Validate_Message(string Validate_Text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Validate_Text}\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Display message with red
    public static void Invalidate_Message(string Invalidate_Text)
    {
        // Invalidate input
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{Invalidate_Text}\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Check if file opened successfully
    public static bool CheckOpenedFile(string file_name)
    {
        if (!System.IO.File.Exists(file_name))
            return false;
        return true;
    }

    // Propt a fresh start
    public static void Prompt_fresh_start()
    {
        Console.WriteLine("Do you wish to delete all current users? (true / false): ");
        try
        {
            bool answer = Convert.ToBoolean(Console.ReadLine());
            if (answer == true)
            {
                System.IO.File.Delete("users_file.txt");
                Validate_Message("Users deleted successfully!");
                UserNamespace.User.ID = 0;
            }
            else
            {
                Console.WriteLine();
                return;
            }
        }
        catch
        {
            Invalidate_Message("Couldn't resolve your answer! Try again ( true / false)!");
            Prompt_fresh_start();
        }
    }

    // Display greeting message
    public static void Greeting()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Hello! This is a user management program! Have fun!\n\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Compare two strings
    public static int Strncmp(string s1, string s2, int length)
    {
        // Check the difference in length
        if (Math.Abs(s1.Length - s2.Length) > 1)
            return -1;

        // Letter by letter
        for (int i = 0; i < length; ++i)
        {
            if (s1[i] != s2[i])
                if (s1[i] > s2[i])
                    return 1;
                else
                    return -1;
        }

        return 0;
    }
}
