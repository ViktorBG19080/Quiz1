using System;
namespace Tests 
{
    public class Test
    {
        static void Main()
        {
            Fraction f = new Fraction(10, -5);
            Console.WriteLine(f);
            f = new Fraction(12, 15);
            Console.WriteLine(-f);
            Console.WriteLine(!(-f));
            f = new Fraction(-17 ,-13);
            Console.WriteLine(f);
            
        }
    }

}