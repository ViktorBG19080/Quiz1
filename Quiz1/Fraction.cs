public class Fraction
{
    private readonly int numerator;
    private readonly int denominator;

    public Fraction(int numerator ,int denominator)
    {
        if (denominator == 0) 
        {
            throw new ArgumentException("Denominator cannot be null");
        }
        this.numerator = numerator;
        this.denominator = denominator;
    }
    
    public int Numerator 
    {
        get { return numerator; }
    } 

    public int Denominator
    {
        get { return denominator; }
    }

    public static  Fraction operator +(Fraction f) => SimplifyFraction(f);
    public static Fraction operator -(Fraction f) => SimplifyFraction(new Fraction(-f.numerator,f.denominator));
    public static Fraction operator !(Fraction f) => SimplifyFraction(new Fraction(f.denominator, f.numerator));
    public static Fraction operator +(Fraction x, Fraction y) { 
        Fraction sum= new Fraction (x.numerator*y.denominator + y.numerator*x.denominator, x.denominator* y.denominator);
        return SimplifyFraction(sum);
    }
    public static Fraction operator -(Fraction x, Fraction y) {
        Fraction sum = x +(-y);
        return SimplifyFraction(sum);
    }

    public static Fraction operator *(Fraction x, Fraction y) {
        Fraction result = new Fraction(x.numerator * y.numerator, x.denominator* y.denominator);
        return SimplifyFraction(result);
    }
    public static Fraction operator /(Fraction x, Fraction y)
    {
        y = !y;
        Fraction result = new Fraction(x.numerator * y.numerator, x.denominator * y.denominator);
        return SimplifyFraction(result);
    }

    public static bool operator ==(Fraction x, Fraction y)
    {
        x = SimplifyFraction(x);
        y = SimplifyFraction(y);
        return (x.numerator == y.numerator) && (x.denominator == y.denominator); 
    }

    public static bool operator !=(Fraction x, Fraction y) 
    {
        return !(x == y);
    }

    #region overrids
    public override string ToString()
    {
        Fraction f = SimplifyFraction(this);
        int x = f.numerator;
        int y = f.denominator;
       
        return $"{x}/{y}";
    }

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
    private static Fraction SimplifyFraction(Fraction f) {

        int x = f.numerator;
        int y = f.denominator;

        if ((x > 0 && y < 0) || (x < 0 && y < 0))
        {
            x = -x;
            y = -y;
        }

        int greatestCommonDivisior = GetGreatestCommonDivisior(x,y);
        x /= greatestCommonDivisior;
        y /= greatestCommonDivisior;

        f = new Fraction(x, y);
        return f;
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