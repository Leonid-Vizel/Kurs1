using System;

namespace ClassWork11
{
    [DeveloperInfo("Vizel Leonid")]
    public class Rational
    {
        public long numerator { get; private set; }
        public long denominator { get; private set; }

        public Rational(long numerator, long denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Rational(Rational source) //Copy constructor
        {
            denominator = source.denominator;
            numerator = source.numerator;
        }

        public void Simplify()
        {
            long del = euclid(numerator,denominator);
            numerator /= del;
            denominator /= del;
        }

        private static long euclid(long a, long b) => b == 0 ? a : euclid(b, a % b);

        public override string ToString() => $"{numerator}/{denominator}";

        public static implicit operator Rational(long x) => new Rational(x, 1);
        public static implicit operator Rational(float x)
        {
            long denominator = 1;
            while (x % 1 != 0)
            {
                x *= 10;
                denominator *= 10;
            }
            return new Rational(Convert.ToInt64(x),denominator);
        }
        public static explicit operator float(Rational x) => (float)x.numerator / x.denominator;
        public static explicit operator long(Rational x) => x.numerator / x.denominator;
        public static Rational operator ++(Rational x)
        {
            x.numerator += x.denominator;
            return x;
        }
        public static Rational operator --(Rational x)
        {
            x.numerator -= x.denominator;
            return x;
        }
        public static Rational operator +(Rational x, Rational y)
        {

            if (x.denominator == y.denominator)
            {
                return new Rational(x.numerator + y.numerator, x.denominator);
            }
            else
            {
                Rational res = new Rational(x.numerator*y.denominator+y.numerator*x.denominator, x.denominator*y.denominator);
                res.Simplify();
                return res;
            }
        }
        public static Rational operator +(Rational x, long y) => new Rational(x.numerator + x.denominator * y, x.denominator);
        public static Rational operator -(Rational x, Rational y)
        {

            if (x.denominator == y.denominator)
            {
                return new Rational(x.numerator - y.numerator, x.denominator);
            }
            else
            {
                Rational res = new Rational(x.numerator * y.denominator - y.numerator * x.denominator, x.denominator * y.denominator);
                res.Simplify();
                return res;
            }
        }
        public static Rational operator -(Rational x, long y) => new Rational(x.numerator - x.denominator * y, x.denominator);
        public static Rational operator *(Rational x, Rational y) => new Rational(x.numerator*y.numerator,x.denominator*y.denominator);
        public static Rational operator *(Rational x, long y) => new Rational(x.numerator * y, x.denominator);
        public static Rational operator /(Rational x, Rational y) => new Rational(x.numerator * y.denominator, x.denominator * y.numerator);
        public static Rational operator /(Rational x, long y) => new Rational(x.numerator, x.denominator * y);
        public static float operator %(Rational x, Rational y) => (float)x % (float)y;
        public static bool operator <(Rational x, Rational y) => (float)x < (float)y;
        public static bool operator >(Rational x, Rational y) => (float)x > (float)y;
        public static bool operator <=(Rational x, Rational y) => (float)x <= (float)y;
        public static bool operator >=(Rational x, Rational y) => (float)x >= (float)y;
        public static bool operator ==(Rational x, Rational y) => ReferenceEquals(x, y);
        public static bool operator !=(Rational x, Rational y) => !(x == y);
        public override bool Equals(object obj)
        {
            if (obj is Rational)
            {
                Rational x = new Rational(obj as Rational);
                Rational y = new Rational(this);
                x.Simplify();
                y.Simplify();
                return x.numerator == y.numerator && x.denominator == y.denominator;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            Rational x = new Rational(this);
            x.Simplify();
            return (x.numerator, x.denominator).GetHashCode();
        }
    }
}
