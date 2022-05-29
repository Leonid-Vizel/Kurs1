using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork10
{
    public class Book
    {
        public string name { get; private set; }
        public string author { get; private set; }
        public string publisher { get; private set; }

        public Book(string name, string author, string publisher)
        {
            this.name = name;
            this.author = author;
            this.publisher = publisher;
        }

        public static string GetName(Book book) => book.name;
        public static string GetAuthor(Book book) => book.author;
        public static string GetPublisher(Book book) => book.publisher;

        public override string ToString() => $"Название: {name} | Автор: {author} | Издательство: {publisher}";
    }
}
