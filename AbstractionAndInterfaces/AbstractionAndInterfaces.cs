using System;

namespace AbstractClassesAndInterfaces
{
    // Interface for character's stats
    interface CharacterStats
    {
        int Health
        {
            get;
            set;
        }
        int Mana
        {
            get;
            set;
        }
        int Experience
        {
            get;
            set;
        }
        decimal Money
        {
            get;
            set;
        }
        void Display_Status();
    }

    // Interface for character's info
    interface CharacterInfo
    {
        string C_Name
        {
            get;
            set;
        }
        int C_Kills
        {
            get;
            set;
        }
        bool C_IsAlive
        {
            get;
            set;
        }
        void Display_Info();
    }

    // Class for the main character based on interfaces
    class MainCharacter : CharacterInfo, CharacterStats
    {
        // Implement interfaces
        private int health;
        private int mana;
        private int experience;
        private decimal money;
        private string c_Name;
        private int c_Kills;
        private bool c_IsAlive;

        public int Health
        {
            get;
            set;
        }
        public int Mana
        {
            get;
            set;
        }
        public int Experience
        {
            get;
            set;
        }
        public decimal Money
        {
            get;
            set;
        }
        public string C_Name
        {
            get;
            set;
        }
        public int C_Kills
        {
            get;
            set;
        }
        public bool C_IsAlive
        {
            get
            {
                return c_IsAlive;
            }
            set
            {
                c_IsAlive = value;
            }
        }

        // Implement methods
        public void Display_Info()
        {
            if (c_IsAlive == true)
                Console.WriteLine("Character {0} has {1} kills!", c_Name, c_Kills);
            else if (c_IsAlive == false)
                Console.WriteLine("Can't display info! Character is dead!");
        }

        public void Display_Status()
        {
            if (c_IsAlive == true)
                Console.WriteLine("CHARACTER: {0}\nHEALTH: {1}\nMANA: {2}\nEXPERIENCE: {3}\nMONEY: {4}",
                    c_Name,
                    health,
                    mana,
                    experience,
                    money);
            else if (c_IsAlive == false)
                Console.WriteLine("Can't display status! Character is dead!");
        }

        // Default constructor
        public MainCharacter()
        {
            health = 0;
            mana = 0;
            experience = 0;
            money = 0;
            c_Name = "";
            c_Kills = 0;
            c_IsAlive = false;
        }

        // Custom constructor
        public MainCharacter(int Health, int Mana, int Experience, decimal Money, string C_Name, int C_Kills, bool C_IsAlive)
        {
            health = Health;
            mana = Mana;
            experience = Experience;
            money = Money;
            c_Name = C_Name;
            c_Kills = C_Kills;
            c_IsAlive = C_IsAlive;
        }
    }

    // Create the enemy abstract class
    abstract class Enemy
    {
        public int Health
        {
            get;
            set;
        }
        public bool Is_Stunned
        {
            get;
            set;
        }
        public bool Is_Alive
        {
            get;
            set;
        }

        abstract public void Charge_Attack(ref MainCharacter player);
        public void Display_Status()
        {
            if (Is_Alive)
                Console.WriteLine("Enemy is alive!");
            else
                Console.WriteLine("Enemy is dead!");
        }
    }

    // Create the enemy class
    class My_Enemy : Enemy
    {
        // Implement abstract class
        public override void Charge_Attack(ref MainCharacter player)
        {
            if (Is_Alive && !Is_Stunned || player.C_IsAlive)
            {
                Console.WriteLine("Enemy charging at player...");
                player.Health = 0;
                Console.WriteLine("Killed player!");
                player.C_IsAlive = false;
            }
            else if (!Is_Alive)
                Console.WriteLine("Enemy is dead! It can't attack!");
            else if (!Is_Stunned)
                Console.WriteLine("Enemy is stunned! It can't attack!");
            else
                Console.WriteLine("Charge failed!");
        }

        // Default constructor
        public My_Enemy()
        {
            Health = 0;
            Is_Stunned = false;
            Is_Alive = false;
        }

        // Custom constructor
        public My_Enemy(int E_health, bool E_stunned, bool E_is_alive)
        {
            Health = E_health;
            Is_Stunned = E_stunned;
            Is_Alive = E_is_alive;
        }
    }

    // Main program
    class Game
    {
        private static void Main()
        {
            // Create default player
            MainCharacter player = new MainCharacter();
            Console.WriteLine("Try printing character's info:");
            player.Display_Info();
            player.Display_Status();

            // Initialise player
            Console.WriteLine("\nInitialise the character.");
            player = new MainCharacter(100, 100, 1000, 253.34m, "Warrenhari", 0, true);
            player.Display_Info();
            player.Display_Status();

            // Create enemy
            My_Enemy enemy = new My_Enemy(100, false, true);
            Console.WriteLine();

            // Kill player
            enemy.Charge_Attack(ref player);

            // Try to display the player
            Console.WriteLine("\nTry displaying character now:");
            player.Display_Info();
            player.Display_Status();
        }
    }
}
