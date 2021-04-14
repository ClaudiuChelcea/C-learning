using System;

namespace ConsoleApp8 {
    class Program {
        // Delegate to bool even/odd functions
        public delegate bool Del(int element);

        static void Main(string[] args) {
            // Create an array
            int[] my_array = new int[10];
            Random random_number = new Random();
            for (int i = 0; i < 10; i++)
                my_array[i] = random_number.Next(0, 20);

            // Display array
            Console.WriteLine("Array:");
            foreach(int element in my_array) {
                Console.Write(element + " ");
            }

            // Return first even element by function
            Console.WriteLine("\n\nFirst even element by function:");
            Console.WriteLine(ReturnFirstEvenElementByFunction(my_array, IsEven));

            // Return last odd element by function
            Console.WriteLine("\nLast odd element by function:");
            Console.WriteLine(ReturnLastOddElementByFunction(my_array, LastOdd));

            // Stop program
            Console.WriteLine("\nPress any key to end the program...");
            Console.ReadKey();
        }

        // Check if number is even
        static public bool IsEven(int element) => element % 2 == 0;

        // Check if number is odd
        static public bool LastOdd(int element) => element % 2 == 1;

        // Return first even element
        static public int ReturnFirstEvenElementByFunction(int[] array, Del Function) {
            foreach(int element in array)
            if (Function(element))
                return element;
            return -1;
        }

        // Return last odd element
        static public int ReturnLastOddElementByFunction(int[] array, Del Function) {
            for (int i = array.Length - 1; i >= 0; i--)
                if (Function(array[i]))
                    return array[i];
            return -1;
        }
    }
}
