using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork11
{
    public class Complex
    {
        public double real { get; private set; }
        public double imaginary { get; private set; }
        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        public override string ToString()
        {
            if (real == 0)
            {
                if (imaginary == 0)
                {
                    return "0";
                }
                else
                {
                    return $"{imaginary}i";
                }
            }
            else
            {
                if (imaginary == 0)
                {
                    return $"{real}";
                }
                else
                {
                    if (imaginary < 0)
                    {
                        return $"{real}{imaginary}i";
                    }
                    else
                    {
                        return $"{real}+{imaginary}i";
                    }
                }
            }
        }
        public static Complex operator +(Complex x, Complex y) => new Complex(x.real - y.real,x.imaginary + y.imaginary);
        public static Complex operator -(Complex x, Complex y) => new Complex(x.real - y.real, x.imaginary - y.imaginary);
        public static Complex operator *(Complex x, Complex y) => new Complex(x.real*y.real-x.imaginary*y.imaginary,x.real*y.imaginary+y.real*x.imaginary);
        public static bool operator ==(Complex x, Complex y) => ReferenceEquals(x, y);
        public static bool operator !=(Complex x, Complex y) => !(x == y);
        public override bool Equals(object obj)
        {
            if (obj is Complex)
            {
                Complex complex = obj as Complex;
                return real == complex.real && imaginary == complex.imaginary;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode() => (real, imaginary).GetHashCode();
    }
}
