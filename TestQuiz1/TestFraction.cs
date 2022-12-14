using System.Diagnostics;
using NUnit.Framework;

namespace TestQuiz1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, 7)]
        [TestCase(2, 5)]
        [TestCase(3, 1)]
        [TestCase(1, -3)]
        [TestCase(0, 5)]
        [TestCase(-1, 0)]
        public void TestUnaryPlus1(int numerator, int denumerator)
        {
            Fraction f = new Fraction(1, 70);
            Fraction z = +(f);

            Assert.That(f.Numerator == z.Numerator && f.Denominator == z.Denominator);
        }

        [Test]
        public void TestUnaryPlusResultIsSimplified1()
        {
            Fraction f = new Fraction(12, 3);
            f = +f;
            Assert.That(f.Numerator == 4 && f.Denominator == 1, $"nomerator = {f.Numerator} denumerator ={f.Denominator}");
        }
        [Test]
        public void TestUnaryPlusResultIsSimplified2()
        {
            Fraction f = new Fraction(-12, 3);
            f = +f;
            Assert.That(f.Numerator == -4 && f.Denominator == 1);
        }
        [Test]
        public void TestUnaryPlusResultIsSimplified3()
        {
            Fraction f = new Fraction(-5, 25);
            f = +f;
            Assert.That(f.Numerator == -1 && f.Denominator == 5);
        }
        [Test]
        public void TestUnaryPlusResultIsSimplified4()
        {
            Fraction f = new Fraction(6, -15);
            f = +f;
            Assert.That(f.Numerator == -2 && f.Denominator == 5, $"nomerator = {f.Numerator} denumerator ={f.Denominator}");
        }

        [Test]
        public void TestUnaryPlusResultIsSimplified5()
        {
            Fraction f = new Fraction(-12 * 7 * 6 * 11, -12 * 5 * 6);
            f = +f;
            Assert.That(f.Numerator == 77 && f.Denominator == 5, $"nomerator = {f.Numerator} denumerator ={f.Denominator}");
        }
        [Test]
        [TestCase(2, 2)]
        [TestCase(-1, 3)]
        [TestCase(-4,-4)]
        [TestCase(125789,-98987)]
        [TestCase(1,1)]
        public void TestFractionInversion(int num, int den)
        {
            Fraction a = new Fraction(num, den);
            Fraction f = new Fraction(den, num);
            a = !a;

            Assert.That(a.Denominator == f.Denominator && f.Numerator == f.Numerator);
        }
    }
}