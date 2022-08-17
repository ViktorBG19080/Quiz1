using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1
{
    public class Person {
        private int yearOfBirth;
        private string name;
        protected string IDNumber;
        private string healthInfo;

        public Person(int yearOfBirth, string name, string IDNumber, string healhInfo)
        {
            this.yearOfBirth = yearOfBirth;
            this.name = name;
            this.IDNumber = IDNumber;
            string healthInfo = healhInfo;
        }

        public string GetHealthStatus() {
            return name + ": " + yearOfBirth + ". " + healthInfo;
        }
    

    }

    public class Child : Person
    {
        public Child(int yearOfBirth, string name, string IDNumber, string healhInfo) : base(yearOfBirth, name, IDNumber, healhInfo)
        {
        }

        public string ChildNumber {
            get => this.IDNumber;
            set => this.IDNumber = value;
        }
    }

    public class Adult : Person
    {
        public Adult(int yearOfBirth, string name, string IDNumber, string healhInfo) : base(yearOfBirth, name, IDNumber, healhInfo)
        {
        }

        public string passportNumber
        {
            get => this.IDNumber;
            set => this.IDNumber = value;
        }
    }
}
