public class Fraction
{
    private readonly int numerator;
    private readonly int denominator;

    public Fraction(int numerator ,int denominator)
    {

        int[] simplifiedFraction= SimplifyFraction(numerator, denominator);
        this.numerator = simplifiedFraction[0];
        this.denominator = simplifiedFraction[1];
    }
    
    public int Numerator 
    {
        get { return numerator; }
    } 

    public int Denominator
    {
        get { return denominator; }
    }

    public static Fraction operator +(Fraction f) => f;

    public static Fraction operator -(Fraction f) =>new Fraction(-f.Numerator,f.Denominator);

    public static Fraction operator !(Fraction f) 
    {
        if (f.Numerator == 0)
        {
            throw new InvalidOperationException("Denominator can not be zero.");
        }

        return new Fraction(f.Denominator, f.Numerator); 
    }

    public static Fraction operator +(Fraction x, Fraction y) { 
        Fraction sum= new Fraction (x.Numerator*y.Denominator + y.Numerator*x.Denominator, x.Denominator* y.Denominator);
        return sum;
    }

    public static Fraction operator -(Fraction x, Fraction y) => -y + x;

    public static Fraction operator *(Fraction x, Fraction y) {
        Fraction result = new Fraction(x.Numerator * y.Numerator, x.Denominator* y.Denominator);
        return result;
    }

    public static Fraction operator /(Fraction x, Fraction y)
    {
        y = !y;
        Fraction result = new Fraction(x.Numerator * y.Numerator, x.Denominator * y.Denominator);
        return result;
    }

    public static bool operator ==(Fraction x, Fraction y)
    {
        return (x.Numerator == y.Numerator) && (x.Denominator == y.Denominator); 
    }

    public static bool operator !=(Fraction x, Fraction y) => !(x == y);
  
    #region overrids
    public override string ToString() => (this.Denominator!=1)?$"{this.Numerator}/{this.Denominator}":this.Numerator.ToString();
    

    public override bool Equals(object? obj)
    {
        return obj != null && this == (Fraction)obj; ;
    }
   
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    #endregion
    #region helper methods
    public static int[] SimplifyFraction(int numerator, int denominator) 
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero");
        }

        if ((numerator > 0 && denominator < 0) || (numerator < 0 && denominator < 0))
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        int greatestCommonDivisior = GetGreatestCommonDivisior(numerator, denominator);

        numerator /= greatestCommonDivisior;
        denominator /= greatestCommonDivisior;

        return new int[2] { numerator,denominator};
    }

    private static int GetGreatestCommonDivisior(int a, int b )
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        if (a == 0) return b;
        if (b == 0) return a;

        //Euclidean algorithm
        if (a < b) {
            int z = a;
            a = b; b = z;
        }

        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    #endregion
}