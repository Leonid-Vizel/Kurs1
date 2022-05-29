using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork10
{
    public class BookContainer
    {
        public List<Book> books { get; private set; }

        public BookContainer()
        {
            books = new List<Book>();
        }

        public Book this[int index]
        {
            get => books[index];
            set => books[index] = value;
        }

        public void SortLambda(Func<Book,string> sortLambda) => books = books.OrderBy(sortLambda).ToList();

        public void SortDelegate(BookParamDelegate method) => books = books.OrderBy(x=>method.Invoke(x)).ToList();

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("Книги в контейнере:\n");
            if (books.Count > 0)
            {
                books.ForEach(x => builder.AppendLine(x.ToString()));
            }
            else
            {
                builder.Append("Пусто");
            }
            return builder.ToString();
        }
    }

    public delegate string BookParamDelegate(Book book);
}
