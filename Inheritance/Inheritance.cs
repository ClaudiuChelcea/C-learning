using System;

namespace Inheritance {
    public class Program {
        private static void Main(string[] args) {
            // Create object of student class
            Student my_student = new Student();
            my_student.ReadStudent();
            my_student.Student_Say();

            // Create object of inherited student class with overridden mithods
            Pupil my_pupil = new Pupil();
            my_pupil.ReadStudent();
            my_pupil.Student_Say();
        }
    }

    class Student {
        // Create properties
        public string FirstName {
            get;
            set;
        }
        public string SecondName {
            get;
            set;
        }
        public int Age {
            get;
            set;
        }
        public double GradeAverage {
            get;
            set;
        }
        public static int nr_Students {
            get;
            set;
        }

        // Constructor
        public Student(string FirstName = "\"default\"", string SecondName = "\"default\"", int Age = -1, double GradeAverage = 0.00) {
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.Age = Age;
            this.GradeAverage = GradeAverage;
            nr_Students++;
        }

        // Scan student
        public virtual void ReadStudent() {
            // Get input or display error
            try {
                Console.Write("First name: ");
                FirstName = Console.ReadLine();
                Console.Write("Second name: ");
                SecondName = Console.ReadLine();
                Console.Write("Age: ");
                Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Grade average: ");
                GradeAverage = Convert.ToDouble(Console.ReadLine());
            } catch (Exception my_exception) {
                Console.WriteLine(my_exception.Message);
            } finally {
                Console.WriteLine("Done scanning!");
            }
        }

        // Display student
        public virtual void Student_Say() {
            Console.WriteLine("Student {0} {1}, with age of {2} has a grade average of {3}!\n",
                FirstName,
                SecondName,
                Age,
                GradeAverage);
        }
    }

    class Pupil: Student {
        DateTime BirthDay = new DateTime();

        // OVerride scanning
        public override void ReadStudent() {
            // Get input or display error
            try {
                Console.Write("First name: ");
                FirstName = Console.ReadLine();
                Console.Write("Second name: ");
                SecondName = Console.ReadLine();
                Console.Write("Age: ");
                Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Grade average: ");
                GradeAverage = Convert.ToDouble(Console.ReadLine());
                Console.Write("Birthday: mm/dd/yyyy: ");
                BirthDay = DateTime.Parse(Console.ReadLine());
            } catch (Exception my_exception) {
                Console.WriteLine(my_exception.Message);
            } finally {
                Console.WriteLine("Done scanning!");
            }
        }

        // Override displaying
        public override void Student_Say() {
            Console.WriteLine("Pupil {0} {1}, with GA of {2}, age of {3} and birthday on {4}!\n",
                FirstName,
                SecondName,
                Age,
                GradeAverage,
                BirthDay.ToLongDateString());
        }
    }
}
