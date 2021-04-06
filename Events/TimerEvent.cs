using System;
using System.Timers;

namespace Program
{
    sealed class Event_Getter
    {

        private static void Main()
        {
            // Create timer
            Timer myTimer = new Timer(1000);
            myTimer.Elapsed += MyTimer_Elapsed;
            myTimer.Elapsed += MyTimer_Elapsed1;
            myTimer.Elapsed += Say_Hello;

            // Start timer
            myTimer.Start();
            Console.ReadLine();
        }

        private static void MyTimer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Time: {0:HH:mm:ss}", e.SignalTime);
        }

        private static void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Time: {0:HH:mm:ss}", e.SignalTime);
        }

        private static void Say_Hello(object sender, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Hello everyone!\n");
        }
    }

}
