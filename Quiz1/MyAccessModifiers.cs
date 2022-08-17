using System;

namespace Quiz1
{
    public class MyAccessModifiers
    {
        static byte averageMiddleAge = 50;
        private string _name;
        readonly int _age;
        private string _nickName;

        private int birthYear;
        protected string personalInfo;
        private protected string IdNumber;

        public MyAccessModifiers(int birthYear, string IdNumber, string personalInfo)
        {
            this.birthYear = birthYear;
            this.personalInfo = personalInfo ?? "Undeclared";
            this.IdNumber = IdNumber;
            this.Name = "Undeclared";
            DateTime currentDate = System.DateTime.Now;
            this._age = currentDate.Year - this.birthYear;

        }

        internal string Name
        {
            get => this._name;
            set => _name = value;
        }
        public int Age
        {

            get => this._age;
        }

        public string NickName
        {
            get => this._nickName;
            internal set => this._nickName = value;
        }

        protected internal bool HasLivedHalfOfLife()
        {
            return this.Age >= (MyAccessModifiers.averageMiddleAge / 2);
        }

        public static bool operator ==(MyAccessModifiers objectA, MyAccessModifiers objectB)
        {
            bool x = objectA.Age == objectB.Age;
            bool y = objectA.Name == objectB.Name;
            bool z = objectA.personalInfo == objectB.personalInfo;
            return x && y && z;
        }

        public static bool operator !=(MyAccessModifiers objectA, MyAccessModifiers objectB)
        {
            return !(objectA == objectB);
        }

        public override bool Equals(object? obj)
        {

            return obj != null && this == (MyAccessModifiers)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
