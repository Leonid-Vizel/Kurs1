using System;
using System.Collections.Generic;

namespace ClassWork11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SimpleDelegate> dels = new List<SimpleDelegate>()
            {
                rationalTest1,
                rationalTest2,
                complexTest1,
                booksTest
            };
            foreach (SimpleDelegate del in dels)
            {
                del.Invoke();
                Console.WriteLine("_________________________");
            }
            Console.ReadKey();
        }

        private static void rationalTest1() => Console.WriteLine($"1.234 = {(Rational)1.234}");

        private static void rationalTest2()
        {
            Rational rat1 = new Rational(6, 12);
            Rational rat2 = new Rational(1, 2);
            Rational rat3 = new Rational(12, 6);
            Console.WriteLine($"Первое число: {rat1} Хеш-код: {rat1.GetHashCode()}");
            Console.WriteLine($"Второе число: {rat2} Хеш-код: {rat2.GetHashCode()}");
            Console.WriteLine($"Equals: {rat1.Equals(rat2)} | Равенство: {rat1 == rat2}");
            Console.WriteLine($"Третье число: {rat3} Хеш-код: {rat3.GetHashCode()}");
        }

        private static void complexTest1()
        {
            Complex comp1 = new Complex(3, -2);
            Complex comp2 = new Complex(1, 4);
            Console.WriteLine($"{comp1} + {comp2} = {comp1 + comp2}");
            Console.WriteLine($"({comp1})({comp2}) = {comp1 * comp2}");
        }

        private static void booksTest()
        {
            BookContainer container = new BookContainer();
            container.books.Add(new Book("a","b","c"));
            container.books.Add(new Book("b", "c", "a"));
            container.books.Add(new Book("c", "a", "b"));
            container.SortLambda(x=>x.author);
            Console.WriteLine(container);
            container.SortLambda(Book.GetPublisher);
            Console.WriteLine(container);
        }

        public delegate void SimpleDelegate();
    }
}
