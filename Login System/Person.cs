using System;

namespace UserNamespace
{
    public class Person
    {
        // Fields
        protected string UserName
        {
            get;
            set;
        }
        protected decimal Salary
        {
            get;
            set;
        }
        protected int Age
        {
            get;
            set;
        }
        protected bool IsMarried
        {
            get;
            set;
        }

        // Constructor
        public Person()
        {
            UserName = "";
            Salary = 0m;
            Age = 0;
            IsMarried = false;
        }

        // Constructor
        protected Person(string x_UserName, decimal x_Salary, int x_Age, bool x_IsMarried)
        {
            this.UserName = x_UserName;
            this.Salary = x_Salary;
            this.Age = x_Age;
            this.IsMarried = x_IsMarried;
        }
    }
}