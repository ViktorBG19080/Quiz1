public class Fraction
{
    private readonly int numerator;
    private readonly int denominator;
    public readonly int sign;

    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
        this.sign = GetSign(numerator, denominator);
    }

    public static  Fraction operator +(Fraction f) => new Fraction (f.numerator,f.denominator);
    public static Fraction operator -(Fraction f) => new Fraction(-f.numerator,f.denominator);
    public static Fraction operator !(Fraction f) => new Fraction(f.denominator, f.numerator);
    public static Fraction operator +(Fraction x, Fraction y) { 
        Fraction sum= new Fraction (x.numerator*y.denominator + y.numerator*x.denominator, x.denominator* y.denominator);
        return SimplifyFractin(sum);
    }
    public static Fraction operator -(Fraction x, Fraction y) {
        Fraction sum = new Fraction(x.numerator * y.denominator - y.numerator*x.denominator, x.denominator * y.denominator);
        return SimplifyFractin(sum);
    }

    public static Fraction operator *(Fraction x, Fraction y) {
        Fraction result = new Fraction(x.numerator * y.numerator, x.denominator* y.denominator);
        return SimplifyFractin(result);
    }
    public static Fraction operator /(Fraction x, Fraction y)
    {
        y = !y;
        Fraction result = new Fraction(x.numerator * y.numerator, x.denominator * y.denominator);
        return SimplifyFractin(result);
    }

    #region helper methods
    private static Fraction SimplifyFractin(Fraction f) {
        int x = f.numerator;
        int y = f.denominator;
        int greatestCommonDivisior = GetGreatestCommonDivisior(x,y);
        x *= greatestCommonDivisior;
        y *= greatestCommonDivisior;
        return new Fraction(x, y);
    }

    private static int GetGreatestCommonDivisior(int x, int y)
    {
        if (y == 0) {
            return x;
           
        }
        return GetGreatestCommonDivisior(y, x % y);
    }

    private static int GetSign(int numerator, int denomerator) { 
        int sign = 0;
        int x = Math.Sign(numerator);
        int y = Math.Sign(denomerator);

        if ((x < 0 && y < 0) || (x > 0 && y > 0)) sign = 1;
        if((x>0 && y<0)||(x<0&&y>0)) sign = -1;
        return sign;
    }
    #endregion
}