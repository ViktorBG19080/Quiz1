using System;

namespace Quiz1
{
    public class Person {
        protected int yearOfBirth;
        protected string name;
        protected string healthInfo;

        public Person(int yearOfBirth, string name, string healthInfo)
        {
            this.yearOfBirth = yearOfBirth;
            this.name = name;
            this.healthInfo = healthInfo;
        }
        public string GetHealthStatus() { return name + ": " + yearOfBirth + ". " + healthInfo; }
    }

    public class Child : Person
    {
        private  string childIDNumber;
        public Child(int yearOfBirth, string name, string healhInfo, string childNumber) : base(yearOfBirth, name, healhInfo)
        {
            this.childIDNumber = childNumber;
        }

       
        public override string ToString()
        {
            return $"{name} {childIDNumber}";
        }
    }

    public class Adult : Person
    {
        private string passportNumber;
        public Adult(int yearOfBirth, string name, string healhInfo, string passportNumber) : base(yearOfBirth, name, healhInfo)
        {
            this.passportNumber = passportNumber;
        }
   
        public override string ToString()
        {
            return $"{this.name} {this.passportNumber}";
        }
    }
}
