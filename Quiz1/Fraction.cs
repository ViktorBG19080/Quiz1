using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1
{
    internal class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        private Fraction(int[] a)
        {
            this.numerator = a[0];
            this.denominator = a[1];
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            int resultNumerator = a.numerator * b.denominator + b.numerator * a.denominator;
            int resultDenominator = a.denominator * b.denominator;
            return SimplifyFraction(resultNumerator, resultDenominator);
        }


        public static Fraction operator -(Fraction a, Fraction b)
        {
            int resultNumerator = a.numerator * b.denominator - b.numerator * a.denominator;
            int resultDenominator = a.denominator * b.denominator;
            return SimplifyFraction(resultNumerator, resultDenominator);
        }

        public static Fraction operator !(Fraction a)
        {
            return new Fraction(a.denominator, a.numerator);
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {

            int resultNumerator = a.numerator * b.denominator;
            int resultDenominator = a.denominator * b.numerator;
            return SimplifyFraction(resultNumerator, resultDenominator);

        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            int resultNumerator = a.numerator / a.denominator;
            int resultDenominator = a.denominator / b.numerator;
            return SimplifyFraction(resultNumerator, resultDenominator);

        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            a = SimplifyFraction(a.numerator, a.denominator);
            b = SimplifyFraction(b.numerator, b.denominator);
            return (a.denominator == b.denominator) && (a.denominator == b.denominator);
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        public override string ToString()
        {
            string sign = this.getSign();
            return $"{sign}{numerator / denominator}";
        }
        private string getSign()
        {
            string sign = String.Empty;
            if (this.numerator != this.denominator && (this.numerator < 0 || this.denominator < 0)) sign = "-";
            return sign;
        }

        private static Fraction SimplifyFraction(int resultNumerator, int resultDenominator)
        {
            int[] simplifiedFraction = new int[] { resultNumerator, resultDenominator };
            Simplify(simplifiedFraction);
            return new Fraction(simplifiedFraction);
        }
        static private void Simplify(int[] numbers)
        {
            int gcd = GCD(numbers);
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] /= gcd;
        }
        static private int GCD(int a, int b)
        {
            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }
        static private int GCD(int[] args)
        {
            return args.Aggregate((gcd, arg) => GCD(gcd, arg));
        }
    }
}
